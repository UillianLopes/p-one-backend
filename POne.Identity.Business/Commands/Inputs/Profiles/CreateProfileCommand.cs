using POne.Core.CQRS;

namespace POne.Identity.Business.Commands.Inputs.Profiles
{
    public class CreateProfileCommand : ICommand
    {
        public string Name { get; set; }
        public string Description { get; set; }
    }
}
