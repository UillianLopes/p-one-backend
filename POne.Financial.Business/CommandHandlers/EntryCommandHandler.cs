using POne.Core.Contracts;
using POne.Core.Enums;
using POne.Core.Extensions;
using POne.Financial.Domain.Commands.Inputs.Entries;
using POne.Financial.Domain.Contracts;
using POne.Financial.Domain.Domain;
using System;
using System.Collections.Generic;
using System.Threading;

namespace POne.Financial.Business.CommandHandlers
{
    public class EntryCommandHandler
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

        private IEnumerable<Entry> CreateEntriesAsync(CreateEntryCommand command, Category category, SubCategory subCategory, CancellationToken cancellationToken)
        {
            Guid? recurrenceId = command.RecurrenceTimes > 1 ? Guid.NewGuid() : null;

            for (var i = 1; i <= command.RecurrenceTimes; i++)
            {
                DateTime? date = null;
                if (command.DueDate is DateTime dueDate)
                {
                    date = command.Recurrence switch
                    {
                        EntryRecurrence.None => dueDate,
                        EntryRecurrence.Every15Days => dueDate.AddDays(i * 15),
                        EntryRecurrence.Every30Days => dueDate.AddDays(i * 30),
                        EntryRecurrence.EveryExactNumberOfDays => dueDate.AddDays(i * command.RecurrenceDays.Value),
                        EntryRecurrence.EveryLastMonthDay => dueDate.AddMonths(i).GoToLastDayOfMonth(),
                        EntryRecurrence.EveveryDay => dueDate.AddMonths(i).GoToThatDay(command.RecurrenceDays.Value),
                        _ => null
                    };
                }

                yield return new Entry(
                   _authenticatedUser.Id,
                   recurrenceId, i,
                   command.Type,
                   command.Value,
                   date,
                   command.Title,
                   command.Description,
                   category,
                   subCategory
               );
            }
        }
        //public async Task<ICommandOuput> Handle(CreateEntryCommand request, CancellationToken cancellationToken)
        //{
        //    if (await _categoryRepository.FindByIdAync(request.CategoryId, cancellationToken) is not Category category)
        //        return CommandOutput.NotFound("PONE.MESSAGES.CATEGORY_NOT_FOUND");

        //    if (await _subCategoryRepository.FindByIdAync(request.CategoryId, cancellationToken) is not SubCategory subCategory)
        //        return CommandOutput.NotFound("PONE.MESSAGES.CATEGORY_NOT_FOUND");

        //}
    }
}
