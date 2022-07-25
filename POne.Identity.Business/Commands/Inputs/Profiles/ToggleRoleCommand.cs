using POne.Core.CQRS;
using System;

namespace POne.Identity.Business.Commands.Inputs.Profiles
{
    public class ToggleRoleCommand : ICommand
    {
        public Guid ProfileId { get; set; }
        public string Key { get; set; }
    }
}
