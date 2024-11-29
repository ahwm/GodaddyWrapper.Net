using GodaddyWrapper.Requests;
using GodaddyWrapper.Responses;
using System;
using System.Collections.Generic;
using System.Text;
using System.Text.Json;
using System.Text.Json.Serialization;

namespace GodaddyWrapper.Serialization
{
#if NET8_0_OR_GREATER

    [JsonSourceGenerationOptions(GenerationMode = JsonSourceGenerationMode.Metadata,
        PropertyNameCaseInsensitive = true,
        PropertyNamingPolicy = JsonKnownNamingPolicy.CamelCase,
        NumberHandling = JsonNumberHandling.AllowReadingFromString,
        DefaultIgnoreCondition = JsonIgnoreCondition.WhenWritingNull)]
    //Requests
    [JsonSerializable(typeof(AbuseTicketCreate))]
    [JsonSerializable(typeof(AbuseTicketDetailRetrieve))]
    [JsonSerializable(typeof(AbuseTicketRetrieve))]
    [JsonSerializable(typeof(Address))]
    [JsonSerializable(typeof(AftermarketListingExpiryCreate))]
    [JsonSerializable(typeof(AgreementRetrieve))]
    [JsonSerializable(typeof(AuctionListingRemove))]
    [JsonSerializable(typeof(CertificateActionRetrieve))]
    [JsonSerializable(typeof(CertificateAddress))]
    [JsonSerializable(typeof(CertificateCallbackActionRegister))]
    [JsonSerializable(typeof(CertificateCallbackRetrieve))]
    [JsonSerializable(typeof(CertificateCallbackUnregister))]
    [JsonSerializable(typeof(CertificateCancel))]
    [JsonSerializable(typeof(CertificateContact))]
    [JsonSerializable(typeof(CertificateDetailRetrieve))]
    [JsonSerializable(typeof(CertificateDomainControlCheck))]
    [JsonSerializable(typeof(CertificateDownload))]
    [JsonSerializable(typeof(CertificateOrganizationCreate))]
    [JsonSerializable(typeof(CertificateReissue))]
    [JsonSerializable(typeof(CertificateRenew))]
    [JsonSerializable(typeof(CertificateRevoke))]
    [JsonSerializable(typeof(CertificatesCreate))]
    [JsonSerializable(typeof(CertificateSiteSealRetrieve))]
    [JsonSerializable(typeof(Consent))]
    [JsonSerializable(typeof(Contact))]
    [JsonSerializable(typeof(CountriesRetrieve))]
    [JsonSerializable(typeof(CountryDetailRetrieve))]
    [JsonSerializable(typeof(DNSRecord))]
    [JsonSerializable(typeof(DNSRecordCreateType))]
    [JsonSerializable(typeof(DNSRecordCreateTypeName))]
    [JsonSerializable(typeof(DNSRecordRetrieve))]
    [JsonSerializable(typeof(DomainAgreements))]
    [JsonSerializable(typeof(DomainAvailable))]
    [JsonSerializable(typeof(DomainAvailableBulk))]
    [JsonSerializable(typeof(DomainContacts))]
    [JsonSerializable(typeof(DomainDelete))]
    [JsonSerializable(typeof(DomainDetailRetrieve))]
    [JsonSerializable(typeof(DomainPurchase))]
    [JsonSerializable(typeof(DomainPurchaseSchema))]
    [JsonSerializable(typeof(DomainPurchaseWithoutPrivacy))]
    [JsonSerializable(typeof(DomainRenew))]
    [JsonSerializable(typeof(DomainRetrieve))]
    [JsonSerializable(typeof(DomainSuggest))]
    [JsonSerializable(typeof(DomainTransferIn))]
    [JsonSerializable(typeof(DomainUpdate))]
    [JsonSerializable(typeof(EmailPreferenceRetrieve))]
    [JsonSerializable(typeof(OrderDetailRetrieve))]
    [JsonSerializable(typeof(OrderRetrieve))]
    [JsonSerializable(typeof(PrivacyDelete))]
    [JsonSerializable(typeof(PrivacyPurchase))]
    [JsonSerializable(typeof(ShopperRetrieve))]
    [JsonSerializable(typeof(ShopperUpdate))]
    [JsonSerializable(typeof(SubaccountCreate))]
    [JsonSerializable(typeof(SubscriptionDelete))]
    [JsonSerializable(typeof(SubscriptionDetailRetrieve))]
    [JsonSerializable(typeof(SubscriptionRetrieve))]
    [JsonSerializable(typeof(TamperSignature))]
    [JsonSerializable(typeof(VerifyRegistrantEmail))]
    //Responses
    [JsonSerializable(typeof(AbuseTicketIdResponse))]
    [JsonSerializable(typeof(AbuseTicketListResponse))]
    [JsonSerializable(typeof(AbuseTicketResponse))]
    [JsonSerializable(typeof(AddressUsageDetailResponse))]
    [JsonSerializable(typeof(AftermarketListingActionResponse))]
    [JsonSerializable(typeof(BillToResponse))]
    [JsonSerializable(typeof(CertificateActionResponse))]
    [JsonSerializable(typeof(CertificateAddressResponse))]
    [JsonSerializable(typeof(CertificateBundleResponse))]
    [JsonSerializable(typeof(CertificateCallbackResponse))]
    [JsonSerializable(typeof(CertificateContactResponse))]
    [JsonSerializable(typeof(CertificateIdentifierResponse))]
    [JsonSerializable(typeof(CertificateOrganizationResponse))]
    [JsonSerializable(typeof(CertificateResponse))]
    [JsonSerializable(typeof(CertificateSiteSealResponse))]
    [JsonSerializable(typeof(ContactResponse))]
    [JsonSerializable(typeof(CountryResponse))]
    [JsonSerializable(typeof(CountrySummaryResponse))]
    [JsonSerializable(typeof(DiscountDetailItemResponse))]
    [JsonSerializable(typeof(DiscountDetailResponse))]
    [JsonSerializable(typeof(DNSRecordResponse))]
    [JsonSerializable(typeof(DomainAvailableBulkMixedResponse))]
    [JsonSerializable(typeof(DomainAvailableBulkResponse))]
    [JsonSerializable(typeof(DomainAvailableBulkResultResponse))]
    [JsonSerializable(typeof(DomainAvailableErrorResponse))]
    [JsonSerializable(typeof(DomainAvailableResponse))]
    [JsonSerializable(typeof(DomainDetailResponse))]
    [JsonSerializable(typeof(DomainPurchaseResponse))]
    [JsonSerializable(typeof(DomainRetrieveResponse))]
    [JsonSerializable(typeof(DomainSuggestionResponse))]
    [JsonSerializable(typeof(DomainSummaryResponse))]
    [JsonSerializable(typeof(EmailPreferenceResponse))]
    [JsonSerializable(typeof(ErrorFieldResponse))]
    [JsonSerializable(typeof(ErrorResponse))]
    [JsonSerializable(typeof(JsonDataTypeResponse))]
    [JsonSerializable(typeof(JsonPropertyResponse))]
    [JsonSerializable(typeof(JsonSchemaResponse))]
    [JsonSerializable(typeof(JurisdictionOfIncorporationResponse))]
    [JsonSerializable(typeof(LegalAgreementResponse))]
    [JsonSerializable(typeof(LineItemPricingResponse))]
    [JsonSerializable(typeof(LineItemResponse))]
    [JsonSerializable(typeof(LineItemSummaryResponse))]
    [JsonSerializable(typeof(ListingActionResponse))]
    [JsonSerializable(typeof(OrderFeeResponse))]
    [JsonSerializable(typeof(OrderListResponse))]
    [JsonSerializable(typeof(OrderPricingResponse))]
    [JsonSerializable(typeof(OrderResponse))]
    [JsonSerializable(typeof(OrderSummaryPricingResponse))]
    [JsonSerializable(typeof(OrderSummaryResponse))]
    [JsonSerializable(typeof(PaginationResponse))]
    [JsonSerializable(typeof(PaymentResponse))]
    [JsonSerializable(typeof(PEMCertificatesResponse))]
    [JsonSerializable(typeof(ProductGroupResponse))]
    [JsonSerializable(typeof(RealNameValidationResponse))]
    [JsonSerializable(typeof(ShopperIdResponse))]
    [JsonSerializable(typeof(ShopperResponse))]
    [JsonSerializable(typeof(StateResponse))]
    [JsonSerializable(typeof(SubjectAlternativeNameDetailsResponse))]
    [JsonSerializable(typeof(SubscriptionAddonResponse))]
    [JsonSerializable(typeof(SubscriptionBillingResponse))]
    [JsonSerializable(typeof(SubscriptionListResponse))]
    [JsonSerializable(typeof(SubscriptionProductResponse))]
    [JsonSerializable(typeof(SubscriptionRelationsResponse))]
    [JsonSerializable(typeof(SubscriptionResponse))]
    [JsonSerializable(typeof(TamperSignatureResponse))]
    [JsonSerializable(typeof(TldSummaryResponse))]
    [JsonSerializable(typeof(UsageDetailItemResponse))]
    [JsonSerializable(typeof(UsageSummaryResponse))]
    internal partial class JsonContext : JsonSerializerContext
    {
    }
#else
    internal partial class JsonContext 
    {
        public readonly static JsonSerializerOptions Options = new JsonSerializerOptions(JsonSerializerDefaults.Web)
        {
            DefaultIgnoreCondition = JsonIgnoreCondition.WhenWritingNull,
            PropertyNamingPolicy = JsonNamingPolicy.CamelCase,
        };

    }
#endif
}