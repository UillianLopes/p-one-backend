using POne.Core.CQRS;
using System;

namespace POne.Identity.Business.Commands.Inputs.Profiles
{
    public class RemoveRoleCommand : ICommand
    {
        public RemoveRoleCommand(Guid profileId, string key)
        {
            ProfileId = profileId;
            Key = key;
        }

        public Guid ProfileId { get; set; }
        public string Key { get; set; }
    }
}
