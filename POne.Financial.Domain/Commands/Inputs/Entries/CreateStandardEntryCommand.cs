using POne.Core.CQRS;
using POne.Core.Enums;
using System;

namespace POne.Financial.Domain.Commands.Inputs.Entries
{



    public abstract class CreateEntryCommand : ICommand
    {
        public EntryOperation Operation { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }
        public Guid CategoryId { get; set; }
        public Guid? SubCategoryId { get; set; }
        public DateTime DueDate { get; set; }
        public decimal Value { get; set; }
        public string BarCode { get; set; }
        public string Currency { get; set; }
        public Guid? WalletId { get; set; }
    }

    public class CreateStandardEntryCommand : CreateEntryCommand
    {
        public bool Paid { get; set; }
        public decimal Fine { get; set; } = 0.00m;
        public decimal Fees { get; set; } = 0.00m;
        public decimal PaidValue { get; set; } = 0.00m;

    }
}
