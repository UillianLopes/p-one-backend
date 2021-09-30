using System.Linq;
using System.Net;
using System.Text.Json.Serialization;

namespace POne.Core.CQRS
{
    public class CommandOutput : ICommandOuput
    {
        private CommandOutput(HttpStatusCode httpStausCode, string[] messages, object data, string uri = null)
        {
            HttpStatusCode = httpStausCode;
            Messages = messages;
            Data = data;
            Uri = uri;
        }

        [JsonIgnore]
        public string Uri { get; private set; }

        [JsonIgnore]
        public HttpStatusCode HttpStatusCode { get; private set; }

        public string[] Messages { get; private set; }
        public object Data { get; private set; }

        public bool Success { get => new[] { HttpStatusCode.Created, HttpStatusCode.OK }.Contains(HttpStatusCode); }


        public static CommandOutput Unauthorized(params string[] messagens) => new(HttpStatusCode.Unauthorized, messagens, null);

        public static CommandOutput NotFound(params string[] messagens) => new(HttpStatusCode.NotFound, messagens, null);

        public static CommandOutput Ok(object data, params string[] messagens) => new(HttpStatusCode.OK, messagens, data);

        public static CommandOutput Created(string uri, object data, params string[] messagens) => new(HttpStatusCode.Created, messagens, data, uri);

        public static CommandOutput BadRequest(object data, params string[] messagens) => new(HttpStatusCode.BadRequest, messagens, data);



    }
}
