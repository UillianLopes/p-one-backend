using POne.Domain.Commands.Inputs;
using POne.Financial.Domain.Contracts.Facades;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Net.Http.Json;
using System.Threading;
using System.Threading.Tasks;

namespace POne.Financial.Api.Facades
{
    public class NotifierApiFacade : INotifierApiFacade
    {
        private readonly HttpClient _httpClient;
        private readonly IdentityApiFacade _identityApiFacade;

        public NotifierApiFacade(IHttpClientFactory _httpClientFactory, IdentityApiFacade identityApiFacade)
        {
            _httpClient = _httpClientFactory.CreateClient("POne.Notifier.Api.Client");
            _identityApiFacade = identityApiFacade;
        }


        public async Task NotifyAsync(CreateNotificationCommand command, CancellationToken cancellationToken)
        {
            var accessToken = await _identityApiFacade
                .GetAccessTokenAsync(cancellationToken);

            var requestContent = JsonContent.Create(command);

            _httpClient.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", accessToken);

            var response = await _httpClient.PostAsync(
                "/Notification", 
                requestContent,
                cancellationToken
           );

            if (response.IsSuccessStatusCode)
            {
                var responseConent = await response.Content.ReadAsStringAsync();

            }
        }
    }
}
