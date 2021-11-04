using POne.Core.CQRS;
using System;

namespace POne.Financial.Domain.Commands.Inputs.Balances
{
    public class DeleteBalanceCommand : ICommand
    {
        public Guid Id { get; set; }
    }
}
