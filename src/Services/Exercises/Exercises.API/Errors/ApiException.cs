namespace Exercises.API.Errors
{
    public class ApiException
    {
        public ApiException(int statusCode, string message = null, string? details = null)
        {
            StatusCode = statusCode;
            Message = message;
            Details = details;
            Errors = null;
        }

        public ApiException(int statusCode, IDictionary<string, string[]> errors, string message = null, string? details = null)
        {
            StatusCode = statusCode;
            Errors= errors;
            Message = message;
            Details = details;
        }

        public int StatusCode { get; set; }
        public string Message { get; set; }
        public string? Details { get; set; }
        public IDictionary<string, string[]>? Errors { get; set; }
    }
}
