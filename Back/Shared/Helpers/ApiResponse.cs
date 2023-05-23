using Microsoft.AspNetCore.Mvc.ModelBinding;
using System.Net;
using System.Text.Json.Serialization;


namespace Shared.Helpers
{
    public interface IApiResponse
    {
        HttpStatusCode Status { get; }
        public IEnumerable<KeyValuePair<string, string?>>? Messages { get; }
    }
    public interface IApiResponse<T> : IApiResponse
    {
        T? Result { get; }
    }

    public class ApiResponse : IApiResponse
    {
        public HttpStatusCode Status { get; set; }

        [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
        public IEnumerable<KeyValuePair<string, string?>>? Messages { get; set; }

        [JsonConstructor]
        public ApiResponse()
        {
        }
        protected ApiResponse(HttpStatusCode status, IEnumerable<KeyValuePair<string, string?>>? messages)
        {
            Status = status;
            Messages = messages;
        }

        public static IApiResponse Success(string? message = null)
        {
            return new ApiResponse(HttpStatusCode.OK,
                   message == null ? null : new List<KeyValuePair<string, string?>>()
                   {
                       new KeyValuePair<string, string?>("OK", message)
                   });
        }

        public static IApiResponse BadRequest(string message)
        {
            return new ApiResponse(HttpStatusCode.BadRequest, new List<KeyValuePair<string, string?>>()
            {
                new KeyValuePair<string, string?>("BadRequest",message)
            });
        }
        public static IApiResponse BadRequest(IEnumerable<KeyValuePair<string, string?>> messages)
        {
            return new ApiResponse(HttpStatusCode.BadRequest, messages);
        }

        public static IApiResponse BadRequest(ModelStateDictionary modelState)
        {
            var messages = modelState.Where(x => x.Value != null)
                                     .SelectMany(x => x.Value.Errors.Select(e => new KeyValuePair<string, string?>(x.Key, e.ErrorMessage)));

            return BadRequest(messages);
        }

        public static IApiResponse Error(string message)
        {
            return new ApiResponse(HttpStatusCode.InternalServerError, new List<KeyValuePair<string, string?>>()
            {
                new KeyValuePair<string, string?>("InternalServerError",message)
            });
        }
    }

    public class ApiResponse<T> : ApiResponse, IApiResponse<T>
    {
        public T? Result { get; set; }

        [JsonConstructor]
        public ApiResponse()
        {
        }
        protected ApiResponse(T? result, HttpStatusCode status, IEnumerable<KeyValuePair<string, string?>>? messages) : base(status, messages)
        {
            Result = result;
        }

        public static IApiResponse<T> Success(T? result, string? message = null)
        {
            return new ApiResponse<T>(result, HttpStatusCode.OK,
                   message == null ? null : new List<KeyValuePair<string, string?>>()
                   {
                       new KeyValuePair<string, string?>("OK", message)
                   });
        }
    }
}
