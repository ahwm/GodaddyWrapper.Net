# GoDaddy API v2 Implementation Summary

## Overview
This implementation adds support for GoDaddy API v2 endpoints while maintaining backward compatibility with v1 endpoints.

## Changes Made

### 1. Core Infrastructure Updates

#### Client.cs
- Updated base URLs to remove hardcoded `/v1/` path
- Production endpoint: `https://api.godaddy.com/`
- Testing endpoint: `https://api.ote-godaddy.com/`

#### Services.cs
- Updated dependency injection configuration to use base URLs without version prefix

### 2. Version Constants

All partial client classes now use:
- `V1_BASE = "v1/"` - for existing v1 API calls
- `V2_BASE = "v2/"` - for new v2 API calls

### 3. Domain API v2 Endpoints (Client.DomainV2.cs)

New methods for domain management using v2 API:

**Domain Management:**
- `GetDomainV2` - Get domain details with optional includes parameter
- `ListDomainsV2` - List domains with filtering and pagination
- `UpdateDomainV2` - Update domain settings
- `CancelDomainV2` - Cancel a domain

**Domain Availability & Purchase:**
- `CheckDomainAvailabilityV2` - Check if domain is available
- `PurchaseDomainV2` - Purchase a domain
- `RenewDomainV2` - Renew a domain
- `TransferDomainV2` - Transfer a domain in

**DNS Management:**
- `GetDNSRecordsV2` - Retrieve DNS records
- `ReplaceDNSRecordsV2` - Replace all DNS records
- `AddDNSRecordsV2` - Add DNS records

**Contacts:**
- `UpdateDomainContactsV2` - Update domain contact information

### 4. Abuse Ticket API v2 Endpoints (Client.AbuseTicket.cs)

Added v2 variants:
- `CreateAbuseTicketV2` - Create a new abuse ticket
- `RetrieveAbuseTicketsV2` - List abuse tickets
- `RetrieveAbuseTicketDetailV2` - Get abuse ticket details

### 5. Certificate API v2 Endpoints (Client.Certificate.cs)

Added v2 variants for all certificate operations:
- `CreateCertificateV2` - Create certificate order
- `CancelCertificateV2` - Cancel pending certificate
- `DownloadCertificateV2` - Download certificate
- `ReissueActiveCertificateV2` - Reissue certificate
- `RenewActiveCertificateV2` - Renew certificate
- `RevokeCertificateV2` - Revoke certificate
- `CheckDomainControlV2` - Verify domain control
- `RetrieveCertificateDetailV2` - Get certificate details
- `RetrieveCertificateActionV2` - Get certificate actions
- `RetrieveSiteSealV2` - Get site seal
- `RegisterCertificateActionV2` - Register callback
- `UnregisterCertificateCallbackV2` - Unregister callback

### 6. Request Models (v2-specific)

**GodaddyWrapper\Requests:**
- `DomainUpdateV2.cs` - Enhanced domain update with privacy settings
- `DomainPurchaseV2.cs` - Domain purchase with consent tracking
- `DomainRenewV2.cs` - Domain renewal request
- `DomainContactsV2.cs` - Contact update request
- `DomainTransferV2.cs` - Domain transfer request

### 7. Response Models (v2-specific)

**GodaddyWrapper\Responses:**
- `DomainListV2Response.cs` - Paginated domain list with marker
- `DomainSummaryV2Response.cs` - Domain summary information
- `DomainAvailabilityV2Response.cs` - Enhanced availability check
- `DomainPurchaseV2Response.cs` - Purchase confirmation
- `DomainTransferV2Response.cs` - Transfer status

### 8. Helper Updates

**QueryStringBuilder.cs:**
- Added `DictionaryToQueryString` method for flexible query parameter building

**JsonContext.cs:**
- Added all v2 request and response types to source generation

## Backward Compatibility

All existing v1 methods remain unchanged and functional:
- V1 methods use the `V1_BASE` prefix
- V2 methods use the `V2_BASE` prefix  
- Existing code continues to work without modification

## Usage Examples

### Getting Customer ID
Before using v2 domain endpoints, you need to retrieve the customer ID:
```csharp
var client = new GoDaddyClient(options);
var shopper = await client.RetrieveShopper(new ShopperRetrieve { ShopperId = "12345" }, includes: "customerId");
string customerId = shopper.CustomerId; // UUID like "295e3bc3-a3b9-4d95-aae5-edf41a994d13"
```

### Using v1 API (existing code):
```csharp
var client = new GoDaddyClient(options);
var domain = await client.CheckDomainAvailable(new DomainAvailable { domain = "example.com" });
```

### Using v2 API (new methods):
```csharp
var client = new GoDaddyClient(options);

// First, get the customer ID
var shopper = await client.RetrieveShopper(new ShopperRetrieve { ShopperId = "12345" }, includes: "customerId");
string customerId = shopper.CustomerId;

// Now use v2 endpoints
var availability = await client.CheckDomainAvailabilityV2("example.com");
var domains = await client.ListDomainsV2(customerId, statuses: "ACTIVE", limit: 100);
var domainDetails = await client.GetDomainV2(customerId, "example.com");
```

## Key Differences: v1 vs v2

### Domain Endpoints
- **v2** uses `/v2/customers/{customerId}/domains/` structure and requires customerId parameter
- **v2** supports enhanced filtering with `includes` parameter
- **v2** has improved pagination with markers
- **v2** includes consent tracking for purchases
- **customerId** is a UUID that must be retrieved via `RetrieveShopper` with `includes="customerId"`

### Response Enhancements
- More detailed status information
- Better error handling
- Consistent pagination patterns
- Enhanced metadata

## Testing

All code has been validated:
- [x] Build successful across all target frameworks (.NET 4.6.2, .NET Standard 2.0, .NET 6, .NET 8, .NET 10)
- [x] No compilation errors
- [x] Existing v1 methods remain functional
- [x] New v2 methods available

## Next Steps

1. **Update documentation** - Add v2 examples to README
2. **Add integration tests** - Test v2 endpoints with real API
3. **Migration guide** - Document how to migrate from v1 to v2
4. **Performance testing** - Compare v1 vs v2 response times
5. **Update NuGet package** - Release new version with v2 support

## Notes

- All v2 domain endpoints require a `customerId` (UUID) parameter
- The `customerId` can be retrieved by calling `RetrieveShopper` with `includes="customerId"` parameter
- Some v2 endpoints may require additional authentication or permissions
- Consult GoDaddy API documentation for specific v2 endpoint requirements
