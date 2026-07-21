using System.Collections.Generic;

namespace GodaddyWrapper.Responses
{
    /// <summary>
    /// The settings a v3 quote resolved for the registration (from the supplied profile/defaults).
    /// </summary>
    public class ResolvedSettingsResponse
    {
        /// <summary>
        /// Whether privacy will be enabled.
        /// </summary>
        public bool? Privacy { get; set; }

        /// <summary>
        /// Whether auto-renew will be enabled.
        /// </summary>
        public bool? AutoRenew { get; set; }

        /// <summary>
        /// Nameservers that will be assigned.
        /// </summary>
        public List<string> NameServers { get; set; }
    }
}
