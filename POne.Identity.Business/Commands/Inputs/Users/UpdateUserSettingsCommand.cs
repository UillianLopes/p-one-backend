using POne.Core.CQRS;
using POne.Identity.Domain.Settings;

namespace POne.Identity.Business.Commands.Inputs.Users
{
    public record UpdateUserSettingsCommand : GeneralSettings, ICommand
    {
    }
}
