using POne.Core.Contracts;
using POne.Core.CQRS;
using POne.Core.Enums;
using POne.Core.Extensions;
using POne.Financial.Domain.Commands.Inputs.Entries;
using POne.Financial.Domain.Commands.Outputs.Entries;
using POne.Financial.Domain.Contracts;
using POne.Financial.Domain.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace POne.Financial.Business.CommandHandlers
{
    public class EntryCommandHandler : ICommandHandler<ProccessEntryRecurrenceCommand>,
        ICommandHandler<CreateEntryCommand>,
        ICommandHandler<DeleteEntryCommand>,
        ICommandHandler<DeleteEntriesCommand>
    {
        private readonly IAuthenticatedUser _authenticatedUser;
        private readonly IEntryRepository _entryRepository;
        private readonly ICategoryRepository _categoryRepository;
        private readonly ISubCategoryRepository _subCategoryRepository;

        public EntryCommandHandler(IAuthenticatedUser authenticatedUser, IEntryRepository entryRepository, ICategoryRepository categoryRepository, ISubCategoryRepository subCategoryRepository)
        {
            _authenticatedUser = authenticatedUser;
            _entryRepository = entryRepository;
            _categoryRepository = categoryRepository;
            _subCategoryRepository = subCategoryRepository;
        }

        private static IEnumerable<ProcessEntryRecurrencyItem> CreateEntries(ProccessEntryRecurrenceCommand request)
        {
            var firstDueDate = request.DueDate;
            var value = request.ValueDistribuition switch
            {
                EntryValueDistribuition.Divide => request.Value / request.RecurrenceTimes,
                _ => request.Value
            };

            for (var index = 0; index < request.RecurrenceTimes; index++)
            {
                
                var dueDate = request.Recurrence switch
                {
                    EntryRecurrence.Every15Days => firstDueDate.AddDays(index * 15),
                    EntryRecurrence.Every30Days => firstDueDate.AddDays(index * 30),
                    EntryRecurrence.EveryExactNumberOfDays => firstDueDate.AddDays(index * request.RecurrenceDays),
                    EntryRecurrence.EveryLastMonthDay => firstDueDate.AddMonths(index).GoToLastDayOfMonth(),
                    EntryRecurrence.EveveryDay => firstDueDate.AddMonths(index).GoToThatDay(request.RecurrenceDays),
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

        public async Task<ICommandOuput> Handle(ProccessEntryRecurrenceCommand request, CancellationToken cancellationToken)
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

            if (await _subCategoryRepository.FindByIdAync(request.SubCategoryId, cancellationToken) is not SubCategory subCategory)
                return CommandOutput.NotFound("PONE.MESSAGES.SUB_CATEGORY_NOT_FOUND");

            Guid? recurrenceId = request.Items.Count > 1 ? Guid.NewGuid() : null;

            var entryIds = new List<Guid>();

            foreach (var item in request.Items)
            {
                var entry = new Entry(_authenticatedUser.Id, recurrenceId, item.Index, request.Type, item.Value, item.DueDate, request.Title, request.Description, category, subCategory);
                await _entryRepository.CreateAync(entry, cancellationToken);
                entryIds.Add(entry.Id);
            }


            return CommandOutput.Created("/entries", entryIds, "PONE.MESSAGES.ENTRIES_CREATED");
        }

        public async Task<ICommandOuput> Handle(DeleteEntryCommand request, CancellationToken cancellationToken)
        {
            if (await _entryRepository.FindByIdAync(request.Id, cancellationToken) is not Entry category)
                return CommandOutput.NotFound("@PONE.MESSAGES.ENTRY_NOT_FOUND");

            _entryRepository.Delete(category);

            return CommandOutput.Ok("@PONE.MESSAGES.ENTRY_DELETED");
        }

        public async Task<ICommandOuput> Handle(DeleteEntriesCommand request, CancellationToken cancellationToken)
        {
            if (await _entryRepository.FindByIdsAync(request.Ids, cancellationToken) is not List<Entry> entries || entries.Count == 0)
                return CommandOutput.NotFound("@PONE.MESSAGES.ENTRIES_NOT_FOUND");

            _entryRepository.DeleteRange(entries.ToArray());

            return CommandOutput.Ok("@PONE.MESSAGES.ENTRIES_DELETED");
        }


    }
}
