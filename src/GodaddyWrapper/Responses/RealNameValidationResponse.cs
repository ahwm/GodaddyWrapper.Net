using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace GodaddyWrapper.Responses
{
    public class RealNameValidationResponse
    {
        /// <summary>
        /// 'APPROVED', 'PENDING', 'PENDING_ASSOCIATION_WITH_DOMAIN', 'PENDING_SUBMISSION_TO_VERIFICATION_SERVICE', 'PENDING_VERIFICATION_SERVICE_REPLY', 'PENDING_SUBMISSION_TO_REGISTRY', 'PENDING_REGISTRY_REPLY', 'PENDING_DOMAIN_UPDATE', 'REJECTED'
        /// </summary>
        public string Status { get; set; }
    }
}
