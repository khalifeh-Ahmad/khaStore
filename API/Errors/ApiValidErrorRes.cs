using System.Collections.Generic;

namespace API.Errors
{
    public class ApiValidErrorRes : ApiResponse
    {
        public ApiValidErrorRes() : base(400)
        {
        }

        public IEnumerable<string> Errors { get; set; }
    }
}