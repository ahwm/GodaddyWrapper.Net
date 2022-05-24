using GodaddyWrapper.Responses;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Runtime.Serialization;
using System.Threading.Tasks;

namespace GodaddyWrapper.Base
{
    [Serializable]
    public class GodaddyException : Exception
    {
        public HttpStatusCode StatusCode { get; private set; }
        public ErrorResponse ErrorResponse { get; private set; }

        public GodaddyException(HttpStatusCode statusCode, ErrorResponse errorResponse, string content) : base(String.IsNullOrWhiteSpace(content) ? $"{errorResponse.Code}: {errorResponse.Message}" : content)
        {
            StatusCode = statusCode;
            ErrorResponse = errorResponse;
        }

        protected GodaddyException(SerializationInfo info, StreamingContext context) : base(info, context)
        {
            StatusCode = (HttpStatusCode)info.GetValue("status", typeof(HttpStatusCode));
            ErrorResponse = (ErrorResponse)info.GetValue("error", typeof(ErrorResponse));
        }

        public new virtual void GetObjectData(SerializationInfo info, StreamingContext context)
        {
            info.AddValue("status", StatusCode);
            info.AddValue("error", ErrorResponse);
            base.GetObjectData(info, context);
        }
    }
}
