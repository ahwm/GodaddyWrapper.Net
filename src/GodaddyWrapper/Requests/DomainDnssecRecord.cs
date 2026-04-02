namespace GodaddyWrapper.Requests
{
    public class DomainDnssecRecord
    {
        public string Algorithm { get; set; }
        public int? KeyTag { get; set; }
        public string DigestType { get; set; }
        public string Digest { get; set; }
        public int? Flags { get; set; }
        public string PublicKey { get; set; }
        public int? MaxSignatureLife { get; set; }
    }
}
