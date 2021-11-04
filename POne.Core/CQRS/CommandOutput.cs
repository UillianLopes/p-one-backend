using System.Linq;
using System.Net;
using System.Text.Json.Serialization;

namespace POne.Core.CQRS
{
    public class CommandOutput<T> : ICommandOuput<T> where T : class
    {
        protected CommandOutput(HttpStatusCode httpStausCode, string[] messages, T data, string uri = null)
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
        public T Data { get; private set; }

        public bool Success { get => new[] { HttpStatusCode.Created, HttpStatusCode.OK }.Contains(HttpStatusCode); }

        public static CommandOutput<T> Unauthorized(params string[] messagens) => new(HttpStatusCode.Unauthorized, messagens, null);

        public static CommandOutput<T> NotFound(params string[] messagens) => new(HttpStatusCode.NotFound, messagens, null);

        public static CommandOutput<T> Ok(T data, params string[] messagens) => new(HttpStatusCode.OK, messagens, data);

        public static CommandOutput<T> Ok(params string[] messagens) => Ok(null, messagens);

        public static CommandOutput<T> Created(string uri, T data, params string[] messagens) => new(HttpStatusCode.Created, messagens, data, uri);

        public static CommandOutput<T> BadRequest(T data, params string[] messagens) => new(HttpStatusCode.BadRequest, messagens, data);

    }

    public class CommandOutput : CommandOutput<object>
    {
        protected CommandOutput(HttpStatusCode httpStausCode, string[] messages, object data, string uri = null) : base(httpStausCode, messages, data, uri)
        {
        }
    }


}
