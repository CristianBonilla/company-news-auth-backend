using System.Collections.Generic;

namespace Company.API
{
    public class AuthFailedResponse
    {
        public IEnumerable<string> Errors { get; set; }
    }
}
