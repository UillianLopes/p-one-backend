using POne.Core.CQRS;
using System;

namespace POne.Identity.Business.Commands.Inputs.Profiles
{
    public class UpdateProfileCommand : ICommand
    {
        public Guid Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
    }
}
