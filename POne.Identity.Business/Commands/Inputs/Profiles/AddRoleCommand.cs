using POne.Core.CQRS;
using System;

namespace POne.Identity.Business.Commands.Inputs.Profiles
{
    public class AddRoleCommand : ICommand
    {
        public AddRoleCommand(Guid profileId, string key)
        {
            ProfileId = profileId;
            Key = key;
        }

        public Guid ProfileId { get; set; }
        public string Key { get; set; }
    }
}
