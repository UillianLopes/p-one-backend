using System.Net;
using System.Text.Json.Serialization;

namespace POne.Core.CQRS
{
    public interface ICommandOuput
    {
        [JsonIgnore]
        HttpStatusCode HttpStatusCode { get; }

        [JsonIgnore]
        string Uri { get; }

        [JsonIgnore]
        bool Success { get; }

        string[] Messages { get; }

        object Data { get; }

    }
}
