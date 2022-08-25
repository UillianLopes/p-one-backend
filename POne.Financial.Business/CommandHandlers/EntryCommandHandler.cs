using POne.Core.Contracts;
using POne.Core.CQRS;
using POne.Core.Enums;
using POne.Core.Extensions;
using POne.Financial.Domain.Commands.Inputs.Entries;
using POne.Financial.Domain.Commands.Outputs.Entries;
using POne.Financial.Domain.Contracts;
using POne.Financial.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace POne.Financial.Business.CommandHandlers
{
    public class EntryCommandHandler : ICommandHandler<BuildEntryRecurrenceCommand>,
        ICommandHandler<CreateEntryCommand>,
        ICommandHandler<DeleteEntryCommand>,
        ICommandHandler<DeleteEntriesCommand>,
        ICommandHandler<PayEntryCommand>,
        ICommandHandler<UpdateEntryCommand>
    {
        private readonly IAuthenticatedUser _authenticatedUser;
        private readonly IEntryRepository _entryRepository;
        private readonly ICategoryRepository _categoryRepository;
        private readonly ISubCategoryRepository _subCategoryRepository;
        private readonly IWalletRepository _balanceRepository;

        public EntryCommandHandler(IAuthenticatedUser authenticatedUser, IEntryRepository entryRepository, ICategoryRepository categoryRepository, ISubCategoryRepository subCategoryRepository, IWalletRepository balanceRepository)
        {
            _authenticatedUser = authenticatedUser;
            _entryRepository = entryRepository;
            _categoryRepository = categoryRepository;
            _subCategoryRepository = subCategoryRepository;
            _balanceRepository = balanceRepository;
        }

        private static IEnumerable<ProcessEntryRecurrencyItem> CreateEntries(BuildEntryRecurrenceCommand request)
        {
            var firstDueDate = request.DueDate;
            var value = request.ValueDistribuition switch
            {
                EntryValueDistribuition.Divide => request.Value / request.Times,
                _ => request.Value
            };

            for (var index = 0; index < request.Times; index++)
            {

                var dueDate = request.Recurrence switch
                {
                    EntryRecurrence.Every15Days => firstDueDate.AddDays(index * 15),
                    EntryRecurrence.Every30Days => firstDueDate.AddDays(index * 30),
                    EntryRecurrence.EveryExactNumberOfDays => firstDueDate.AddDays(index * request.IntervalInDays),
                    EntryRecurrence.EveryLastMonthDay => firstDueDate.AddMonths(index).GoToLastDayOfMonth(),
                    EntryRecurrence.EverySpecificDayOfMonth => firstDueDate.AddMonths(index).GoToThatDay(request.Day),
                    _ => firstDueDate
                };

                yield return new()
                {
                    Index = index + 1,
                    Value = Math.Round(value, 2),
                    DueDate = dueDate
                };
            }
        }

        public async Task<ICommandOuput> Handle(BuildEntryRecurrenceCommand request, CancellationToken cancellationToken)
        {
            return await Task.Run(() =>
            {
                var entries = CreateEntries(request)
                    .ToList();

                return ProcessEntryRecurrencyOutput.Ok(entries, "");
            });
        }

        public async Task<ICommandOuput> Handle(CreateEntryCommand request, CancellationToken cancellationToken)
        {
            if (await _categoryRepository.FindByIdAync(request.CategoryId, cancellationToken) is not Category category)
                return CommandOutput.NotFound("PONE.MESSAGES.CATEGORY_NOT_FOUND");

            SubCategory subCategory = null;

            if (request.SubCategoryId is Guid subCategoryId)
                subCategory = await _subCategoryRepository.FindByIdAync(subCategoryId, cancellationToken);

            if (!request.Recurrences.Any())
            {
                var entry = new Entry(
                    _authenticatedUser.Id,
                    _authenticatedUser.AccountId,
                    null, 1, 1,
                    request.Type,
                    request.Value,
                    request.DueDate,
                    request.Title,
                    request.BarCode,
                    request.Description,
                    category,
                    subCategory,
                    request.Currency
                );

                await _entryRepository.CreateAync(entry, cancellationToken);
                return CommandOutput.Created("/entries", entry.Id, "PONE.MESSAGES.ENTRIES_CREATED");
            }

            var entryIds = new List<Guid>();
            var recurrenceId = Guid.NewGuid();

            foreach (var item in request.Recurrences)
            {
                var entry = new Entry(
                    _authenticatedUser.Id,
                    _authenticatedUser.AccountId,
                    recurrenceId,
                    item.Index,
                    request.Recurrences.Count,
                    request.Type,
                    item.Value,
                    item.DueDate,
                    request.Title,
                    item.BarCode,
                    request.Description,
                    category,
                    subCategory,
                    request.Currency
                );

                await _entryRepository.CreateAync(entry, cancellationToken);
                entryIds.Add(entry.Id);
            }

            return CommandOutput.Created("/entries", entryIds, "PONE.MESSAGES.ENTRIES_CREATED");
        }

        public async Task<ICommandOuput> Handle(DeleteEntryCommand request, CancellationToken cancellationToken)
        {
            if (await _entryRepository.FindByIdAync(request.Id, cancellationToken) is not Entry entry)
                return CommandOutput.NotFound("@PONE.MESSAGES.ENTRY_NOT_FOUND");

            entry.RevertPayments();

            _entryRepository.Delete(entry);

            return CommandOutput.Ok("@PONE.MESSAGES.ENTRY_DELETED");
        }

        public async Task<ICommandOuput> Handle(DeleteEntriesCommand request, CancellationToken cancellationToken)
        {
            if (await _entryRepository.FindByIdsAync(request.Ids, cancellationToken) is not List<Entry> entries || entries.Count == 0)
                return CommandOutput.NotFound("@PONE.MESSAGES.ENTRIES_NOT_FOUND");

            foreach(var entry in entries)
                entry.RevertPayments();

            _entryRepository.DeleteRange(entries.ToArray());

            return CommandOutput.Ok("@PONE.MESSAGES.ENTRIES_DELETED");
        }

        public async Task<ICommandOuput> Handle(PayEntryCommand request, CancellationToken cancellationToken)
        {
            if (await _entryRepository.FindByIdAync(request.Id, cancellationToken) is not Entry entry)
                return CommandOutput.NotFound("@PONE.MESSAGES.ENTRY_NOT_FOUND");

            if (await _balanceRepository.FindByIdAync(request.BalanceId, cancellationToken) is not Wallet balance)
                return CommandOutput.NotFound("@PONE.MESSAGES.BALANCE_NOT_FOUND");

            entry.Pay(balance, request.Value, request.Fees, request.Fine);

            return CommandOutput.Ok("@PONE.MESSAGES.ENTRY_PAID");
        }

        public async Task<ICommandOuput> Handle(UpdateEntryCommand request, CancellationToken cancellationToken)
        {
            if (await _entryRepository.FindByIdAync(request.Id, cancellationToken) is not Entry entry)
                return CommandOutput.NotFound("@PONE.MESSAGES.ENTRY_NOT_FOUND");

            if (await _categoryRepository.FindByIdAync(request.CategoryId, cancellationToken) is not Category category)
                return CommandOutput.NotFound("PONE.MESSAGES.CATEGORY_NOT_FOUND");

            SubCategory subCategory = null;

            if (request.SubCategoryId is Guid subCategoryId)
                subCategory = await _subCategoryRepository.FindByIdAync(subCategoryId, cancellationToken);

            entry.Update(
                request.Title,
                request.Description,
                request.BarCode,
                request.Currency,
                request.Value,
                request.DueDate,
                category,
                subCategory
            );

            return CommandOutput.Ok("@PONE.MESSAGES.ENTRY_UPDATED_WITH_SUCESSS");
        }
    }
}
