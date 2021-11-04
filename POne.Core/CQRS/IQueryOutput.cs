using System.Net;
using System.Text.Json.Serialization;

namespace POne.Core.CQRS
{
    public interface IQueryOutput
    {
        [JsonIgnore]
        HttpStatusCode HttpStatusCode { get; }

        [JsonIgnore]
        bool Success { get; }

        object Data { get; }

        string[] Messages { get; }
    }
}
