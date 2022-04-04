using POne.Core.CQRS;
using System;

namespace POne.Financial.Domain.Commands.Inputs.Wallets
{
    public class DeleteWalletCommand : ICommand
    {
        public Guid Id { get; set; }
    }
}
