using System.ComponentModel.DataAnnotations;

namespace GodaddyWrapper.Requests
{
    public class DomainTransferInV2
    {
        public string AuthCode { get; set; }
        public int? Period { get; set; }
        public bool? RenewAuto { get; set; }
        public bool? Privacy { get; set; }
        public string IdentityDocumentId { get; set; }
        public ConsentV2 Consent { get; set; }
    }
}
