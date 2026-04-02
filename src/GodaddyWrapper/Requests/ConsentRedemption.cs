using System;
using System.ComponentModel.DataAnnotations;

namespace GodaddyWrapper.Requests
{
    public class ConsentRedemption
    {
        [Required]
        public long Price { get; set; }
        [Required]
        public long Fee { get; set; }
        [Required]
        public string Currency { get; set; }
        [Required]
        public string AgreedBy { get; set; }
        [Required]
        public DateTime AgreedAt { get; set; }
    }
}
