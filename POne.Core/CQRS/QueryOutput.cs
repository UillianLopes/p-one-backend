using System.Linq;
using System.Net;
using System.Text.Json.Serialization;

namespace POne.Core.CQRS
{
    public class QueryOutput : IQueryOutput
    {
        private QueryOutput(HttpStatusCode httpStatusCode, string[] messages, object data)
        {
            Data = data;
            Messages = messages;
            HttpStatusCode = httpStatusCode;
        }

        public object Data { get; private set; }
        public int? Ammount { get; set; }

        public string[] Messages { get; private set; }

        [JsonIgnore]
        public HttpStatusCode HttpStatusCode { get; private set; }

        [JsonIgnore]
        public bool Success => new[] { HttpStatusCode.OK }.Contains(HttpStatusCode);

        public static QueryOutput Unauthorized(params string[] messagens) => new(HttpStatusCode.Unauthorized, messagens, null);

        public static QueryOutput NotFound(params string[] messagens) => new(HttpStatusCode.NotFound, messagens, null);

        public static QueryOutput Ok(object data) => new(HttpStatusCode.OK, null, data);

        public static QueryOutput Ok(object data, params string[] messagens) => new(HttpStatusCode.OK, messagens, data);

        public static QueryOutput Ok(params string[] messagens) => Ok(null, messagens);

        public static QueryOutput BadRequest(object data, params string[] messagens) => new(HttpStatusCode.BadRequest, messagens, data);
    }
}
