using System;
using System.Collections.Generic;

namespace GodaddyWrapper.Responses
{
    public class DomainDetailV2Response
    {
        public string DomainId { get; set; }
        public string Domain { get; set; }
        public string SubaccountId { get; set; }
        public string Status { get; set; }
        public DateTime? ExpiresAt { get; set; }
        public bool ExpirationProtected { get; set; }
        public bool HoldRegistrar { get; set; }
        public bool Locked { get; set; }
        public bool Privacy { get; set; }
        public DateTime? RegistrarCreatedAt { get; set; }
        public bool RenewAuto { get; set; }
        public DateTime? RenewDeadline { get; set; }
        public bool TransferProtected { get; set; }
        public DateTime? CreatedAt { get; set; }
        public DateTime? DeletedAt { get; set; }
        public DateTime? ModifiedAt { get; set; }
        public DateTime? TransferAwayEligibleAt { get; set; }
        public string AuthCode { get; set; }
        public List<string> NameServers { get; set; }
        public List<string> Hostnames { get; set; }
        public List<string> RegistryStatusCodes { get; set; }
        public DomainRenewalDetailsResponse Renewal { get; set; }
        public DomainContactsV2Response Contacts { get; set; }
        public List<DomainActionResponse> Actions { get; set; }
        public List<DomainDnssecRecordResponse> DnssecRecords { get; set; }
    }

    public class DomainRenewalDetailsResponse
    {
        public bool? Renewable { get; set; }
        public long? Price { get; set; }
        public string Currency { get; set; }
    }

    public class DomainContactsV2Response
    {
        public DomainContactResponse Registrant { get; set; }
        public DomainContactResponse Admin { get; set; }
        public DomainContactResponse Tech { get; set; }
        public DomainContactResponse Billing { get; set; }
    }

    public class DomainContactResponse
    {
        public string NameFirst { get; set; }
        public string NameMiddle { get; set; }
        public string NameLast { get; set; }
        public string Organization { get; set; }
        public string Email { get; set; }
        public string Phone { get; set; }
    }

    public class DomainDnssecRecordResponse
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
