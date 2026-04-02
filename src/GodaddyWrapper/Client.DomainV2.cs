using GodaddyWrapper.Helper;
using GodaddyWrapper.Requests;
using GodaddyWrapper.Responses;
using System.Collections.Generic;
using System.Net.Http.Json;
using System.Threading.Tasks;

namespace GodaddyWrapper
{
    public partial class GoDaddyClient
    {
        /// <summary>
        /// Retrieve domain detail for a customer (v2)
        /// </summary>
        /// <param name="customerId"></param>
        /// <param name="domain"></param>
        /// <returns></returns>
        public async Task<DomainDetailV2Response> GetDomainDetailV2(string customerId, string domain)
        {
            var response = await httpClient.GetAsync($"../v2/customers/{customerId}/domains/{domain}");
            await CheckResponseMessageIsValid(response);
            return await response.Content.ReadAsAsync<DomainDetailV2Response>(JsonSettings);
        }

        /// <summary>
        /// Get change of registrant info for a domain (v2)
        /// </summary>
        /// <param name="customerId"></param>
        /// <param name="domain"></param>
        /// <returns></returns>
        public async Task<DomainChangeOfRegistrantResponse> GetChangeOfRegistrant(string customerId, string domain)
        {
            var response = await httpClient.GetAsync($"../v2/customers/{customerId}/domains/{domain}/changeOfRegistrant");
            await CheckResponseMessageIsValid(response);
            return await response.Content.ReadAsAsync<DomainChangeOfRegistrantResponse>(JsonSettings);
        }

        /// <summary>
        /// Delete a pending change of registrant for a domain (v2)
        /// </summary>
        /// <param name="customerId"></param>
        /// <param name="domain"></param>
        /// <returns></returns>
        public async Task DeleteChangeOfRegistrant(string customerId, string domain)
        {
            var response = await httpClient.DeleteAsync($"../v2/customers/{customerId}/domains/{domain}/changeOfRegistrant");
            await CheckResponseMessageIsValid(response);
        }

        /// <summary>
        /// Update DNSSEC records for a domain (v2)
        /// </summary>
        /// <param name="customerId"></param>
        /// <param name="domain"></param>
        /// <param name="records"></param>
        /// <returns></returns>
        public async Task UpdateDnssecRecords(string customerId, string domain, List<DomainDnssecRecord> records)
        {
            var response = await httpClient.PatchAsJsonAsync($"../v2/customers/{customerId}/domains/{domain}/dnssecRecords", records, JsonSettings);
            await CheckResponseMessageIsValid(response);
        }

        /// <summary>
        /// Delete DNSSEC records for a domain (v2)
        /// </summary>
        /// <param name="customerId"></param>
        /// <param name="domain"></param>
        /// <returns></returns>
        public async Task DeleteDnssecRecords(string customerId, string domain)
        {
            var response = await httpClient.DeleteAsync($"../v2/customers/{customerId}/domains/{domain}/dnssecRecords");
            await CheckResponseMessageIsValid(response);
        }

        /// <summary>
        /// Update name servers for a domain (v2)
        /// </summary>
        /// <param name="customerId"></param>
        /// <param name="domain"></param>
        /// <param name="request"></param>
        /// <returns></returns>
        public async Task UpdateNameServersV2(string customerId, string domain, DomainNameServerUpdateV2 request)
        {
            var response = await httpClient.PutAsJsonAsync($"../v2/customers/{customerId}/domains/{domain}/nameServers", request, JsonSettings);
            await CheckResponseMessageIsValid(response);
        }

        /// <summary>
        /// Get privacy forwarding settings for a domain (v2)
        /// </summary>
        /// <param name="customerId"></param>
        /// <param name="domain"></param>
        /// <returns></returns>
        public async Task<DomainPrivacyForwardingResponse> GetPrivacyForwarding(string customerId, string domain)
        {
            var response = await httpClient.GetAsync($"../v2/customers/{customerId}/domains/{domain}/privacy/forwarding");
            await CheckResponseMessageIsValid(response);
            return await response.Content.ReadAsAsync<DomainPrivacyForwardingResponse>(JsonSettings);
        }

        /// <summary>
        /// Update privacy forwarding settings for a domain (v2)
        /// </summary>
        /// <param name="customerId"></param>
        /// <param name="domain"></param>
        /// <param name="request"></param>
        /// <returns></returns>
        public async Task UpdatePrivacyForwarding(string customerId, string domain, DomainPrivacyForwardingUpdate request)
        {
            var response = await httpClient.PatchAsJsonAsync($"../v2/customers/{customerId}/domains/{domain}/privacy/forwarding", request, JsonSettings);
            await CheckResponseMessageIsValid(response);
        }

        /// <summary>
        /// Redeem an expired domain (v2)
        /// </summary>
        /// <param name="customerId"></param>
        /// <param name="domain"></param>
        /// <param name="request"></param>
        /// <returns></returns>
        public async Task RedeemDomainV2(string customerId, string domain, DomainRedeemV2 request)
        {
            CheckRequestValid(request);
            var response = await httpClient.PostAsJsonAsync($"../v2/customers/{customerId}/domains/{domain}/redeem", request, JsonSettings);
            await CheckResponseMessageIsValid(response);
        }

        /// <summary>
        /// Renew a domain (v2)
        /// </summary>
        /// <param name="customerId"></param>
        /// <param name="domain"></param>
        /// <param name="request"></param>
        /// <returns></returns>
        public async Task RenewDomainV2(string customerId, string domain, DomainRenewV2 request)
        {
            CheckRequestValid(request);
            var response = await httpClient.PostAsJsonAsync($"../v2/customers/{customerId}/domains/{domain}/renew", request, JsonSettings);
            await CheckResponseMessageIsValid(response);
        }

        /// <summary>
        /// Initiate an inbound domain transfer (v2)
        /// </summary>
        /// <param name="customerId"></param>
        /// <param name="domain"></param>
        /// <param name="request"></param>
        /// <returns></returns>
        public async Task TransferDomainInV2(string customerId, string domain, DomainTransferInV2 request)
        {
            var response = await httpClient.PostAsJsonAsync($"../v2/customers/{customerId}/domains/{domain}/transfer", request, JsonSettings);
            await CheckResponseMessageIsValid(response);
        }

        /// <summary>
        /// Validate an inbound domain transfer request (v2)
        /// </summary>
        /// <param name="customerId"></param>
        /// <param name="domain"></param>
        /// <param name="request"></param>
        /// <returns></returns>
        public async Task ValidateTransferDomainInV2(string customerId, string domain, DomainTransferInV2 request)
        {
            var response = await httpClient.PostAsJsonAsync($"../v2/customers/{customerId}/domains/{domain}/transfer/validate", request, JsonSettings);
            await CheckResponseMessageIsValid(response);
        }

        /// <summary>
        /// Get transfer status for a domain (v2)
        /// </summary>
        /// <param name="customerId"></param>
        /// <param name="domain"></param>
        /// <returns></returns>
        public async Task<DomainTransferStatusResponse> GetTransferStatus(string customerId, string domain)
        {
            var response = await httpClient.GetAsync($"../v2/customers/{customerId}/domains/{domain}/transfer");
            await CheckResponseMessageIsValid(response);
            return await response.Content.ReadAsAsync<DomainTransferStatusResponse>(JsonSettings);
        }

        /// <summary>
        /// Accept an inbound domain transfer (v2)
        /// </summary>
        /// <param name="customerId"></param>
        /// <param name="domain"></param>
        /// <param name="request"></param>
        /// <returns></returns>
        public async Task AcceptTransferIn(string customerId, string domain, DomainTransferAuthCode request)
        {
            CheckRequestValid(request);
            var response = await httpClient.PostAsJsonAsync($"../v2/customers/{customerId}/domains/{domain}/transferInAccept", request, JsonSettings);
            await CheckResponseMessageIsValid(response);
        }

        /// <summary>
        /// Cancel an inbound domain transfer (v2)
        /// </summary>
        /// <param name="customerId"></param>
        /// <param name="domain"></param>
        /// <returns></returns>
        public async Task CancelTransferIn(string customerId, string domain)
        {
            var response = await httpClient.PostAsync($"../v2/customers/{customerId}/domains/{domain}/transferInCancel", null);
            await CheckResponseMessageIsValid(response);
        }

        /// <summary>
        /// Restart an inbound domain transfer (v2)
        /// </summary>
        /// <param name="customerId"></param>
        /// <param name="domain"></param>
        /// <returns></returns>
        public async Task RestartTransferIn(string customerId, string domain)
        {
            var response = await httpClient.PostAsync($"../v2/customers/{customerId}/domains/{domain}/transferInRestart", null);
            await CheckResponseMessageIsValid(response);
        }

        /// <summary>
        /// Retry an inbound domain transfer (v2)
        /// </summary>
        /// <param name="customerId"></param>
        /// <param name="domain"></param>
        /// <param name="request"></param>
        /// <returns></returns>
        public async Task RetryTransferIn(string customerId, string domain, DomainTransferAuthCode request)
        {
            CheckRequestValid(request);
            var response = await httpClient.PostAsJsonAsync($"../v2/customers/{customerId}/domains/{domain}/transferInRetry", request, JsonSettings);
            await CheckResponseMessageIsValid(response);
        }

        /// <summary>
        /// Initiate an outbound domain transfer (v2)
        /// </summary>
        /// <param name="customerId"></param>
        /// <param name="domain"></param>
        /// <returns></returns>
        public async Task TransferDomainOut(string customerId, string domain)
        {
            var response = await httpClient.PostAsync($"../v2/customers/{customerId}/domains/{domain}/transferOut", null);
            await CheckResponseMessageIsValid(response);
        }

        /// <summary>
        /// Accept an outbound domain transfer (v2)
        /// </summary>
        /// <param name="customerId"></param>
        /// <param name="domain"></param>
        /// <returns></returns>
        public async Task AcceptTransferOut(string customerId, string domain)
        {
            var response = await httpClient.PostAsync($"../v2/customers/{customerId}/domains/{domain}/transferOutAccept", null);
            await CheckResponseMessageIsValid(response);
        }

        /// <summary>
        /// Reject an outbound domain transfer (v2)
        /// </summary>
        /// <param name="customerId"></param>
        /// <param name="domain"></param>
        /// <returns></returns>
        public async Task RejectTransferOut(string customerId, string domain)
        {
            var response = await httpClient.PostAsync($"../v2/customers/{customerId}/domains/{domain}/transferOutReject", null);
            await CheckResponseMessageIsValid(response);
        }

        /// <summary>
        /// Get forwarding configuration for a domain (v2)
        /// </summary>
        /// <param name="customerId"></param>
        /// <param name="fqdn"></param>
        /// <returns></returns>
        public async Task<DomainForwardingResponse> GetDomainForwarding(string customerId, string fqdn)
        {
            var response = await httpClient.GetAsync($"../v2/customers/{customerId}/domains/forwards/{fqdn}");
            await CheckResponseMessageIsValid(response);
            return await response.Content.ReadAsAsync<DomainForwardingResponse>(JsonSettings);
        }

        /// <summary>
        /// Create domain forwarding (v2)
        /// </summary>
        /// <param name="customerId"></param>
        /// <param name="fqdn"></param>
        /// <param name="request"></param>
        /// <returns></returns>
        public async Task CreateDomainForwarding(string customerId, string fqdn, DomainForwardingCreate request)
        {
            CheckRequestValid(request);
            var response = await httpClient.PostAsJsonAsync($"../v2/customers/{customerId}/domains/forwards/{fqdn}", request, JsonSettings);
            await CheckResponseMessageIsValid(response);
        }

        /// <summary>
        /// Update domain forwarding (v2)
        /// </summary>
        /// <param name="customerId"></param>
        /// <param name="fqdn"></param>
        /// <param name="request"></param>
        /// <returns></returns>
        public async Task UpdateDomainForwarding(string customerId, string fqdn, DomainForwardingCreate request)
        {
            CheckRequestValid(request);
            var response = await httpClient.PutAsJsonAsync($"../v2/customers/{customerId}/domains/forwards/{fqdn}", request, JsonSettings);
            await CheckResponseMessageIsValid(response);
        }

        /// <summary>
        /// Delete domain forwarding (v2)
        /// </summary>
        /// <param name="customerId"></param>
        /// <param name="fqdn"></param>
        /// <returns></returns>
        public async Task DeleteDomainForwarding(string customerId, string fqdn)
        {
            var response = await httpClient.DeleteAsync($"../v2/customers/{customerId}/domains/forwards/{fqdn}");
            await CheckResponseMessageIsValid(response);
        }

        /// <summary>
        /// Get all actions for a domain (v2)
        /// </summary>
        /// <param name="customerId"></param>
        /// <param name="domain"></param>
        /// <returns></returns>
        public async Task<List<DomainActionResponse>> GetDomainActions(string customerId, string domain)
        {
            var response = await httpClient.GetAsync($"../v2/customers/{customerId}/domains/{domain}/actions");
            await CheckResponseMessageIsValid(response);
            return await response.Content.ReadAsAsync<List<DomainActionResponse>>(JsonSettings);
        }

        /// <summary>
        /// Get a specific action for a domain (v2)
        /// </summary>
        /// <param name="customerId"></param>
        /// <param name="domain"></param>
        /// <param name="type"></param>
        /// <returns></returns>
        public async Task<DomainActionResponse> GetDomainAction(string customerId, string domain, string type)
        {
            var response = await httpClient.GetAsync($"../v2/customers/{customerId}/domains/{domain}/actions/{type}");
            await CheckResponseMessageIsValid(response);
            return await response.Content.ReadAsAsync<DomainActionResponse>(JsonSettings);
        }

        /// <summary>
        /// Cancel a specific action for a domain (v2)
        /// </summary>
        /// <param name="customerId"></param>
        /// <param name="domain"></param>
        /// <param name="type"></param>
        /// <returns></returns>
        public async Task CancelDomainAction(string customerId, string domain, string type)
        {
            var response = await httpClient.DeleteAsync($"../v2/customers/{customerId}/domains/{domain}/actions/{type}");
            await CheckResponseMessageIsValid(response);
        }

        /// <summary>
        /// Get domain notifications for a customer (v2)
        /// </summary>
        /// <param name="customerId"></param>
        /// <returns></returns>
        public async Task<DomainNotificationResponse> GetDomainNotifications(string customerId)
        {
            var response = await httpClient.GetAsync($"../v2/customers/{customerId}/domains/notifications");
            await CheckResponseMessageIsValid(response);
            return await response.Content.ReadAsAsync<DomainNotificationResponse>(JsonSettings);
        }

        /// <summary>
        /// Get notification opt-in settings for a customer (v2)
        /// </summary>
        /// <param name="customerId"></param>
        /// <returns></returns>
        public async Task GetDomainNotificationOptIn(string customerId)
        {
            var response = await httpClient.GetAsync($"../v2/customers/{customerId}/domains/notifications/optIn");
            await CheckResponseMessageIsValid(response);
        }

        /// <summary>
        /// Update notification opt-in settings for a customer (v2)
        /// </summary>
        /// <param name="customerId"></param>
        /// <returns></returns>
        public async Task UpdateDomainNotificationOptIn(string customerId)
        {
            var response = await httpClient.PutAsync($"../v2/customers/{customerId}/domains/notifications/optIn", null);
            await CheckResponseMessageIsValid(response);
        }

        /// <summary>
        /// Get notification schema for a given type (v2)
        /// </summary>
        /// <param name="customerId"></param>
        /// <param name="type"></param>
        /// <returns></returns>
        public async Task<JsonSchemaResponse> GetDomainNotificationSchema(string customerId, string type)
        {
            var response = await httpClient.GetAsync($"../v2/customers/{customerId}/domains/notifications/schemas/{type}");
            await CheckResponseMessageIsValid(response);
            return await response.Content.ReadAsAsync<JsonSchemaResponse>(JsonSettings);
        }

        /// <summary>
        /// Acknowledge a domain notification (v2)
        /// </summary>
        /// <param name="customerId"></param>
        /// <param name="notificationId"></param>
        /// <returns></returns>
        public async Task AcknowledgeDomainNotification(string customerId, string notificationId)
        {
            var response = await httpClient.PostAsync($"../v2/customers/{customerId}/domains/notifications/{notificationId}/acknowledge", null);
            await CheckResponseMessageIsValid(response);
        }

        /// <summary>
        /// Register a domain for a customer (v2)
        /// </summary>
        /// <param name="customerId"></param>
        /// <param name="request"></param>
        /// <returns></returns>
        public async Task RegisterDomainV2(string customerId, DomainPurchaseV2 request)
        {
            CheckRequestValid(request);
            var response = await httpClient.PostAsJsonAsync($"../v2/customers/{customerId}/domains/register", request, JsonSettings);
            await CheckResponseMessageIsValid(response);
        }

        /// <summary>
        /// Get domain registration schema for a TLD (v2)
        /// </summary>
        /// <param name="customerId"></param>
        /// <param name="tld"></param>
        /// <returns></returns>
        public async Task<JsonSchemaResponse> GetRegisterDomainSchemaV2(string customerId, string tld)
        {
            var response = await httpClient.GetAsync($"../v2/customers/{customerId}/domains/register/schema/{tld}");
            await CheckResponseMessageIsValid(response);
            return await response.Content.ReadAsAsync<JsonSchemaResponse>(JsonSettings);
        }

        /// <summary>
        /// Validate a domain registration request (v2)
        /// </summary>
        /// <param name="customerId"></param>
        /// <param name="request"></param>
        /// <returns></returns>
        public async Task ValidateRegisterDomainV2(string customerId, DomainPurchaseV2 request)
        {
            CheckRequestValid(request);
            var response = await httpClient.PostAsJsonAsync($"../v2/customers/{customerId}/domains/register/validate", request, JsonSettings);
            await CheckResponseMessageIsValid(response);
        }

        /// <summary>
        /// Get scheduled maintenances for domains (v2)
        /// </summary>
        /// <returns></returns>
        public async Task<List<MaintenanceResponse>> GetDomainMaintenances()
        {
            var response = await httpClient.GetAsync($"../v2/domains/maintenances");
            await CheckResponseMessageIsValid(response);
            return await response.Content.ReadAsAsync<List<MaintenanceResponse>>(JsonSettings);
        }

        /// <summary>
        /// Get details for a specific domain maintenance (v2)
        /// </summary>
        /// <param name="maintenanceId"></param>
        /// <returns></returns>
        public async Task<MaintenanceDetailResponse> GetDomainMaintenance(string maintenanceId)
        {
            var response = await httpClient.GetAsync($"../v2/domains/maintenances/{maintenanceId}");
            await CheckResponseMessageIsValid(response);
            return await response.Content.ReadAsAsync<MaintenanceDetailResponse>(JsonSettings);
        }

        /// <summary>
        /// Get domain API usage for a month (v2)
        /// </summary>
        /// <param name="yyyymm">Year and month in format yyyy-mm</param>
        /// <returns></returns>
        public async Task<UsageMonthlyResponse> GetDomainUsage(string yyyymm)
        {
            var response = await httpClient.GetAsync($"../v2/domains/usage/{yyyymm}");
            await CheckResponseMessageIsValid(response);
            return await response.Content.ReadAsAsync<UsageMonthlyResponse>(JsonSettings);
        }

        /// <summary>
        /// Update contacts for a domain (v2)
        /// </summary>
        /// <param name="customerId"></param>
        /// <param name="domain"></param>
        /// <param name="request"></param>
        /// <returns></returns>
        public async Task UpdateDomainContactsV2(string customerId, string domain, DomainContactsUpdateV2 request)
        {
            var response = await httpClient.PatchAsJsonAsync($"../v2/customers/{customerId}/domains/{domain}/contacts", request, JsonSettings);
            await CheckResponseMessageIsValid(response);
        }

        /// <summary>
        /// Regenerate authorization code for a domain (v2)
        /// </summary>
        /// <param name="customerId"></param>
        /// <param name="domain"></param>
        /// <returns></returns>
        public async Task RegenerateAuthCodeV2(string customerId, string domain)
        {
            var response = await httpClient.PostAsync($"../v2/customers/{customerId}/domains/{domain}/regenerateAuthCode", null);
            await CheckResponseMessageIsValid(response);
        }
    }
}
