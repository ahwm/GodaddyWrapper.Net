using GodaddyWrapper.Requests;
using GodaddyWrapper.Responses;
using System;
using System.Collections.Generic;
using System.Text;
using System.Text.Json;
using System.Text.Json.Serialization;

namespace GodaddyWrapper.Serialization
{
#if NETSTANDARD

    [JsonSourceGenerationOptions(GenerationMode = JsonSourceGenerationMode.Metadata,
        PropertyNameCaseInsensitive = true,
        PropertyNamingPolicy = JsonKnownNamingPolicy.CamelCase,
        NumberHandling = JsonNumberHandling.AllowReadingFromString,
        DefaultIgnoreCondition = JsonIgnoreCondition.WhenWritingNull)]
    //Requests
    [JsonSerializable(typeof(AbuseTicketCreate))]
    [JsonSerializable(typeof(AbuseTicketRetrieve))]
    [JsonSerializable(typeof(AbuseTicketDetailRetrieve))]
    [JsonSerializable(typeof(List<AftermarketListingExpiryCreate>))]
    [JsonSerializable(typeof(AgreementRetrieve))]
    [JsonSerializable(typeof(CertificateCancel))]
    [JsonSerializable(typeof(CertificateDomainControlCheck))]
    [JsonSerializable(typeof(CertificatesCreate))]
    [JsonSerializable(typeof(CertificateDownload))]
    [JsonSerializable(typeof(CertificateReissue))]
    [JsonSerializable(typeof(CertificateRenew))]
    [JsonSerializable(typeof(CertificateActionRetrieve))]
    [JsonSerializable(typeof(CertificateCallbackActionRegister))]
    [JsonSerializable(typeof(CertificateDetailRetrieve))]
    [JsonSerializable(typeof(CertificateSiteSealRetrieve))]
    [JsonSerializable(typeof(CertificateRevoke))]
    [JsonSerializable(typeof(CertificateCallbackUnregister))]
    [JsonSerializable(typeof(CountriesRetrieve))]
    [JsonSerializable(typeof(CountryDetailRetrieve))]
    [JsonSerializable(typeof(List<DNSRecord>))]
    [JsonSerializable(typeof(DomainAvailableBulk))]
    [JsonSerializable(typeof(DomainDelete))]
    [JsonSerializable(typeof(PrivacyDelete))]
    [JsonSerializable(typeof(DomainAvailable))]
    [JsonSerializable(typeof(DomainPurchase))]
    [JsonSerializable(typeof(DomainPurchaseWithoutPrivacy))]
    [JsonSerializable(typeof(PrivacyPurchase))]
    [JsonSerializable(typeof(DomainPurchaseSchema))]
    [JsonSerializable(typeof(DomainRenew))]
    [JsonSerializable(typeof(List<DNSRecordCreateType>))]
    [JsonSerializable(typeof(List<DNSRecordCreateTypeName>))]
    [JsonSerializable(typeof(DomainAgreements))]
    [JsonSerializable(typeof(DomainRetrieve))]
    [JsonSerializable(typeof(DNSRecordRetrieve))]
    [JsonSerializable(typeof(DomainSuggest))]
    [JsonSerializable(typeof(DomainTransferIn))]
    [JsonSerializable(typeof(DomainUpdate))]
    [JsonSerializable(typeof(DomainContacts))]
    [JsonSerializable(typeof(VerifyRegistrantEmail))]
    [JsonSerializable(typeof(OrderRetrieve))]
    [JsonSerializable(typeof(OrderDetailRetrieve))]
    [JsonSerializable(typeof(SubaccountCreate))]
    [JsonSerializable(typeof(ShopperRetrieve))]
    [JsonSerializable(typeof(ShopperUpdate))]
    [JsonSerializable(typeof(SubscriptionDelete))]
    [JsonSerializable(typeof(SubscriptionRetrieve))]
    [JsonSerializable(typeof(SubscriptionDetailRetrieve))]
    //Responses
    [JsonSerializable(typeof(AbuseTicketIdResponse))]
    [JsonSerializable(typeof(AbuseTicketListResponse))]
    [JsonSerializable(typeof(AbuseTicketResponse))]
    [JsonSerializable(typeof(AftermarketListingActionResponse))]
    [JsonSerializable(typeof(ListingActionResponse))]
    [JsonSerializable(typeof(List<LegalAgreementResponse>))]
    [JsonSerializable(typeof(CertificateIdentifierResponse))]
    [JsonSerializable(typeof(CertificateBundleResponse))]
    [JsonSerializable(typeof(List<CertificateActionResponse>))]
    [JsonSerializable(typeof(CertificateSiteSealResponse))]
    [JsonSerializable(typeof(CountrySummaryResponse))]
    [JsonSerializable(typeof(CountryResponse))]
    [JsonSerializable(typeof(DomainAvailableBulkResultResponse))]
    [JsonSerializable(typeof(DomainAvailableResponse))]
    [JsonSerializable(typeof(DomainPurchaseResponse))]
    [JsonSerializable(typeof(JsonPropertyResponse))]
    [JsonSerializable(typeof(List<DomainRetrieveResponse>))]
    [JsonSerializable(typeof(DomainDetailResponse))]
    [JsonSerializable(typeof(List<DNSRecordResponse>))]
    [JsonSerializable(typeof(List<DomainSuggestionResponse>))]
    [JsonSerializable(typeof(List<TldSummaryResponse>))]
    [JsonSerializable(typeof(OrderListResponse))]
    [JsonSerializable(typeof(OrderResponse))]
    [JsonSerializable(typeof(ShopperIdResponse))]
    [JsonSerializable(typeof(ShopperResponse))]
    [JsonSerializable(typeof(SubscriptionListResponse))]
    [JsonSerializable(typeof(List<ProductGroupResponse>))]
    [JsonSerializable(typeof(SubscriptionResponse))]
    internal partial class JsonContext : JsonSerializerContext
    {
    }
#else
    internal partial class JsonContext 
    {
         public static class Default
         {
            public readonly static JsonSerializerOptions Options = new JsonSerializerOptions(JsonSerializerDefaults.Web)
            {
                DefaultIgnoreCondition = JsonIgnoreCondition.WhenWritingNull,
                PropertyNamingPolicy = JsonNamingPolicy.CamelCase,
            };
         }
    }
#endif
}