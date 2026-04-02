using System;
using System.ComponentModel.DataAnnotations;

namespace GodaddyWrapper.Requests
{
    public class ConsentRenew
    {
        [Required]
        public long Price { get; set; }
        [Required]
        public string Currency { get; set; }
        public bool? RegistryPremiumPricing { get; set; }
        [Required]
        public string AgreedBy { get; set; }
        [Required]
        public DateTime AgreedAt { get; set; }
    }
}
