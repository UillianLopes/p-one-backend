using POne.Core.CQRS;
using System;

namespace POne.Financial.Domain.Commands.Inputs.Wallets
{

    public class TransferSubject
    {
        public Guid WalletId { get; set; }
        public Guid CategoryId { get; set; }
        public Guid? SubCategoryId { get; set; }
    }

    public class TransferCommand : ICommand
    {
        public string Title { get; set; }
        public string Description { get; set; }
        public DateTime DueDate { get; set; }
        public decimal Value { get; set; }
        public TransferSubject Origin { get; set; }
        public TransferSubject Destination { get; set; }
    }
}
