namespace API.Errors
{
    public class ApiException : ApiResponse
    {
        public ApiException(int statusCode, string message = null, string dtls = null)
            : base(statusCode, message)
        {
            Details = dtls;
        }

        public string Details { get; set; }
    }
}