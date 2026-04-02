using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace GodaddyWrapper.Requests
{
    public class ConsentV2
    {
        public List<string> AgreementKeys { get; set; }
        public long? Price { get; set; }
        public string Currency { get; set; }
        public bool? RegistryPremiumPricing { get; set; }
        [Required]
        public string AgreedBy { get; set; }
        [Required]
        public DateTime AgreedAt { get; set; }
        public string ClaimToken { get; set; }
    }
}
