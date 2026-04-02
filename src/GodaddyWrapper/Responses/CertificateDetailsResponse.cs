using System;
using System.Collections.Generic;

namespace GodaddyWrapper.Responses
{
    public class CertificateDetailsResponse
    {
        public string CertificateId { get; set; }
        public string Domain { get; set; }
        public int? Period { get; set; }
        public DateTime? RequestDate { get; set; }
        public DateTime? CompletionDate { get; set; }
        public DateTime? RevocationDate { get; set; }
        public DateTime? ValidStartDate { get; set; }
        public DateTime? ValidEndDate { get; set; }
        public string Status { get; set; }
        public string Type { get; set; }
        public string ValidationType { get; set; }
        public List<string> Sans { get; set; }
        public string SerialNumber { get; set; }
        public int? SlotSize { get; set; }
    }
}
