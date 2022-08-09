using POne.Core.CQRS;
using System;

namespace POne.Financial.Domain.Commands.Inputs.Entries
{
    public class UpdateEntryCommand : ICommand
    {
        public Guid Id { get; set; }
        public DateTime DueDate { get; set; }
        public string Currency { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }
        public Guid CategoryId { get; set; }
        public Guid? SubCategoryId { get; set; }
        public decimal Value { get; set; }
        public string BarCode { get; set; }
    }
}
