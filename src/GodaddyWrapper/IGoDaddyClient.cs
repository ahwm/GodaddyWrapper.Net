using GodaddyWrapper.Requests;
using GodaddyWrapper.Responses;
using System;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;

namespace GodaddyWrapper
{
    /// <summary>
    /// Abstraction over <see cref="GoDaddyClient"/> to enable injection and mocking.
    /// </summary>
    public interface IGoDaddyClient
    {
        // ----- Domains (v1) -----
        Task<DomainAvailableBulkResultResponse> BulkCheckDomainAvailable(DomainAvailableBulk request);
        Task<bool> CancelDomain(DomainDelete request, string XShopperId = null);
        Task<bool> CancelPrivacy(PrivacyDelete request, string XShopperId = null);
        Task<DomainPurchaseResponse> PurchasePrivacy(PrivacyPurchase request, string domain, string XShopperId = null);
        Task<JsonPropertyResponse> RetrieveDomainPurchaseSchema(DomainPurchaseSchema request);
        Task<DomainPurchaseResponse> RenewDomain(DomainRenew request, string domain, string XShopperId = null);
        Task<List<LegalAgreementResponse>> RetrieveDomainAgreements(DomainAgreements request, string XMarketId);
        Task<List<DomainRetrieveResponse>> RetrieveDomainList(DomainRetrieve request, string XShopperId = null);
        Task<List<TldSummaryResponse>> RetrieveTldSummary();
        Task<DomainTransferIn> TransferDomain(DomainTransferIn request, string domain, string XShopperId = null);
        Task<bool> UpdateDomain(DomainUpdate request, string domain, string XShopperId = null);
        Task<bool> UpdateDomainContacts(DomainContacts request, string domain, string XShopperId = null);
        Task<bool> VerifyRegistrantEmail(VerifyRegistrantEmail request, string XShopperId = null);

        // ----- Domains (v3) -----
        Task<DomainAvailableV3Response> CheckDomainAvailableV3(DomainAvailableV3 request);
        Task<DomainSuggestionsV3Response> SuggestDomainsV3(DomainSuggestV3 request);
        Task<RegistrationQuoteResponse> CreateRegistrationQuote(RegistrationQuoteCreate request);
        Task<DomainRegistrationResponse> RegisterDomainV3(DomainRegistrationCreate request, string idempotencyKey = null);
        Task<DomainRegistrationResponse> RegisterDomainWithQuoteAsync(RegistrationQuoteCreate quote, IEnumerable<string> agreementTypes = null, string idempotencyKey = null);
        Task<DomainRegistrationResponse> GetRegistrationStatus(string registrationId);
        Task<DomainDetailV3Response> GetDomainV3(string domain);
        Task<DomainOperationResponse> UpdateNameServersV3(string domain, List<string> nameServers, string idempotencyKey = null);
        Task<DNSRecordPageResponse> RetrieveDNSRecordsV3(string zone, DNSRecordRetrieveV3 request = null);
        Task<List<DNSRecordResponseV3>> AddDNSRecordsV3(string zone, List<DNSRecordV3> records);
        Task<bool> ReplaceDNSRecordsV3(string zone, List<DNSRecordV3> records);
        Task<bool> DeleteDNSRecordV3(string zone, string recordId);
        Task<DomainOperationResponse> GetDomainOperation(string operationId);
        Task<DomainOperationResponse> WaitForDomainOperation(string operationId, TimeSpan? pollInterval = null, TimeSpan? timeout = null, CancellationToken cancellationToken = default);

        // ----- Domains (v2) -----
        Task<DomainDetailV2Response> GetDomainDetailV2(string customerId, string domain);
        Task<DomainChangeOfRegistrantResponse> GetChangeOfRegistrant(string customerId, string domain);
        Task DeleteChangeOfRegistrant(string customerId, string domain);
        Task UpdateDnssecRecords(string customerId, string domain, List<DomainDnssecRecord> records);
        Task DeleteDnssecRecords(string customerId, string domain);
        Task UpdateNameServersV2(string customerId, string domain, DomainNameServerUpdateV2 request);
        Task<DomainPrivacyForwardingResponse> GetPrivacyForwarding(string customerId, string domain);
        Task UpdatePrivacyForwarding(string customerId, string domain, DomainPrivacyForwardingUpdate request);
        Task RedeemDomainV2(string customerId, string domain, DomainRedeemV2 request);
        Task RenewDomainV2(string customerId, string domain, DomainRenewV2 request);
        Task TransferDomainInV2(string customerId, string domain, DomainTransferInV2 request);
        Task ValidateTransferDomainInV2(string customerId, string domain, DomainTransferInV2 request);
        Task<DomainTransferStatusResponse> GetTransferStatus(string customerId, string domain);
        Task AcceptTransferIn(string customerId, string domain, DomainTransferAuthCode request);
        Task CancelTransferIn(string customerId, string domain);
        Task RestartTransferIn(string customerId, string domain);
        Task RetryTransferIn(string customerId, string domain, DomainTransferAuthCode request);
        Task TransferDomainOut(string customerId, string domain);
        Task AcceptTransferOut(string customerId, string domain);
        Task RejectTransferOut(string customerId, string domain);
        Task<DomainForwardingResponse> GetDomainForwarding(string customerId, string fqdn);
        Task CreateDomainForwarding(string customerId, string fqdn, DomainForwardingCreate request);
        Task UpdateDomainForwarding(string customerId, string fqdn, DomainForwardingCreate request);
        Task DeleteDomainForwarding(string customerId, string fqdn);
        Task<List<DomainActionResponse>> GetDomainActions(string customerId, string domain);
        Task<DomainActionResponse> GetDomainAction(string customerId, string domain, string type);
        Task CancelDomainAction(string customerId, string domain, string type);
        Task<DomainNotificationResponse> GetDomainNotifications(string customerId);
        Task GetDomainNotificationOptIn(string customerId);
        Task UpdateDomainNotificationOptIn(string customerId);
        Task<JsonSchemaResponse> GetDomainNotificationSchema(string customerId, string type);
        Task AcknowledgeDomainNotification(string customerId, string notificationId);
        Task<List<MaintenanceResponse>> GetDomainMaintenances();
        Task<MaintenanceDetailResponse> GetDomainMaintenance(string maintenanceId);
        Task<UsageMonthlyResponse> GetDomainUsage(string yyyymm);
        Task UpdateDomainContactsV2(string customerId, string domain, DomainContactsUpdateV2 request);
        Task RegenerateAuthCodeV2(string customerId, string domain);

        // ----- Certificates (v1) -----
        Task CancelCertificate(CertificateCancel request);
        Task CheckDomainControl(CertificateDomainControlCheck request);
        Task<CertificateIdentifierResponse> CreateCertificate(CertificatesCreate request, string XMarketId = null);
        Task<CertificateBundleResponse> DownloadCertificate(CertificateDownload request);
        Task ReissueActiveCertificate(CertificateReissue request, string certificateId);
        Task RenewActiveCertificate(CertificateRenew request, string certificateId);
        Task<List<CertificateActionResponse>> RetrieveCertificateAction(CertificateActionRetrieve request);
        Task RegisterCertificateAction(CertificateCallbackActionRegister request, string certificateId);
        Task<CertificateIdentifierResponse> RetrieveCertificateDetail(CertificateDetailRetrieve request);
        Task<CertificateSiteSealResponse> RetrieveSiteSeal(CertificateSiteSealRetrieve request, string certificateId);
        Task RevokeActiveCertificate(CertificateRevoke request, string certificateId);
        Task UnregisterCertificateCallback(CertificateCallbackUnregister request);

        // ----- Certificates (v2) -----
        Task<List<CertificateResponse>> GetCertificatesByEntitlement(CertificatesByEntitlementRetrieve request);
        Task<SubscriptionCertificateIdentifierResponse> CreateSubscriptionCertificate(SubscriptionCertificateCreate request, string xMarketId = null);
        Task ReissueActiveCertificateV2(string certificateId, CertificateReissueV2 request);
        Task<CertificateBundleResponse> DownloadCertificateByEntitlement(CertificateDownloadByEntitlementRetrieve request);
        Task<CertificateSummariesV2Response> GetCustomerCertificates(string customerId, CustomerCertificatesRetrieve request);
        Task<CertificateDetailV2Response> GetCustomerCertificateDetail(string customerId, string certificateId);
        Task<List<DomainVerificationSummaryResponse>> GetCertificateDomainVerifications(string customerId, string certificateId);
        Task<DomainVerificationDetailResponse> GetCertificateDomainVerificationDetail(string customerId, string certificateId, string domain);
        Task<ExternalAccountBindingResponse> GetAcmeExternalAccountBinding(string customerId);
        Task<CertificatesByDomainPageResponse> SearchCertificateSubscriptions(CertificateSubscriptionsSearch request);
        Task<CertificatesByDomainPagedResponse> GetCertificateSubscription(string guid, CertificateSubscriptionsSearch request);

        // ----- Abuse Tickets (v1) -----
        Task<AbuseTicketIdResponse> CreateAbuseTicket(AbuseTicketCreate request);
        Task<AbuseTicketListResponse> RetrieveAbuseTickets(AbuseTicketRetrieve request);
        Task<AbuseTicketResponse> RetrieveAbuseTicketDetail(AbuseTicketDetailRetrieve request);

        // ----- Abuse Tickets (v2) -----
        Task<AbuseTicketIdResponse> CreateAbuseTicketV2(AbuseTicketCreateV2 request);
        Task<AbuseTicketListResponse> RetrieveAbuseTicketsV2(AbuseTicketRetrieve request);
        Task<AbuseTicketV2Response> RetrieveAbuseTicketDetailV2(string ticketId);

        // ----- Aftermarket -----
        Task<AftermarketListingActionResponse> AddExpiryAuction(List<AftermarketListingExpiryCreate> request);
        Task<ListingActionResponse> RemoveAuctionListings(AgreementRetrieve request);

        // ----- Agreements -----
        Task<List<LegalAgreementResponse>> RetrieveAgreements(AgreementRetrieve request, string XPrivateLabelId = null, string XMarketId = null);

        // ----- Countries -----
        Task<CountrySummaryResponse> RetrieveCountries(CountriesRetrieve request);
        Task<CountryResponse> RetrieveCountryDetail(CountryDetailRetrieve request, string CountryKey);

        // ----- Orders -----
        Task<OrderListResponse> RetrieveOrderList(OrderRetrieve request, string XShopperId, string XMarketId);
        Task<OrderResponse> RetrieveSpecificOrder(OrderDetailRetrieve request, string XShopperId, string XMarketId);

        // ----- Shoppers -----
        Task<ShopperIdResponse> CreateSubaccount(SubaccountCreate request);
        Task<ShopperResponse> RetrieveShopper(ShopperRetrieve request);
        Task<ShopperIdResponse> UpdateShopper(ShopperUpdate request, string shopperId);

        // ----- Subscriptions -----
        Task<bool> CancelSubscription(SubscriptionDelete request, string XShopperId = null);
        Task<SubscriptionListResponse> RetrieveSubscriptions(SubscriptionRetrieve request, string XShopperId = null, string XMarketId = null);
        Task<List<ProductGroupResponse>> RetrieveSubscriptionProductGroups(string XShopperId = null, string XMarketId = null);
        Task<SubscriptionResponse> RetrieveSubscriptionDetails(SubscriptionDetailRetrieve request, string XShopperId = null, string XMarketId = null);

        // ----- ANS / Agents -----
        Task<AgentSearchResponse> SearchAgents(AgentSearch request);
        Task<AgentRegistrationPendingResponse> RegisterAgent(AgentRegister request);
        Task<AgentResolutionResponse> ResolveAgent(AgentCapabilityRequest request);
        Task<AgentDetailsResponse> GetAgent(string agentId);
        Task<AgentRevocationResponse> RevokeAgent(string agentId, AgentRevoke request);
        Task<AgentStatusResponse> VerifyAgentAcme(string agentId);
        Task<AgentStatusResponse> VerifyAgentDns(string agentId);
        Task<List<AgentCertificateResponse>> GetAgentIdentityCertificates(string agentId);
        Task<AgentCsrSubmissionResponse> SubmitAgentIdentityCsr(string agentId, AgentCsrSubmit request);
        Task<List<AgentCertificateResponse>> GetAgentServerCertificates(string agentId);
        Task<AgentCsrSubmissionResponse> SubmitAgentServerCsr(string agentId, AgentCsrSubmit request);
        Task<AgentCsrStatusResponse> GetAgentCsrStatus(string agentId, string csrId);
        Task<AgentEventPageResponse> GetAgentEvents(AgentEventsRetrieve request);
    }
}
