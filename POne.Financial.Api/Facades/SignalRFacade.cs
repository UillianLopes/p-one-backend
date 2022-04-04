using Microsoft.AspNetCore.SignalR;
using POne.Financial.Domain.Contracts.Facades;

namespace POne.Financial.Api.Facades
{
    public class SignalRFacade : ISignalRFacade
    {
        private readonly IHubContext _context;

    }
}
