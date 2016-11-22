using GodaddyWrapper.Responses;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Threading.Tasks;

namespace GodaddyWrapper.Base
{
    public class GodaddyException : Exception
    {
        public HttpStatusCode StatusCode { get; private set; }
        public ErrorResponse ErrorResponse { get; private set; }

        public GodaddyException(HttpStatusCode statusCode, ErrorResponse errorResponse, string content) : base(content)
        {
            StatusCode = statusCode;
            ErrorResponse = errorResponse;
        }

    }
}
