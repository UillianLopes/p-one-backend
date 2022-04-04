using POne.Core.CQRS;
using System;

namespace POne.Financial.Domain.Commands.Inputs.Wallets
{
    public class DeleteWalletsCommand : ICommand
    {
        public Guid[] Ids { get; set; }
    }
}
