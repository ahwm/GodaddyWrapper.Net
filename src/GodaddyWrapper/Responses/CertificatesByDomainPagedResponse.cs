using System;
using System.Collections.Generic;

namespace GodaddyWrapper.Responses
{
    public class CertificatesByDomainPagedResponse
    {
        public string Domain { get; set; }
        public string Guid { get; set; }
        public int MaxDomains { get; set; }
        public List<string> AllowedDomains { get; set; }
        public DateTime? SubscriptionStartDate { get; set; }
        public DateTime? SubscriptionEndDate { get; set; }
        public string SubscriptionStatus { get; set; }
        public int CurrentPage { get; set; }
        public int PageSize { get; set; }
        public int Total { get; set; }
        public List<CertificateDetailsResponse> Data { get; set; }
    }
}
