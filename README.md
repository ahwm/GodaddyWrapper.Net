# GodaddyWrapper.Net

[![nuget](https://img.shields.io/nuget/vpre/GodaddyWrapper.svg)](https://www.nuget.org/packages/GodaddyWrapper)
[![build](https://github.com/ahwm/GodaddyWrapper.Net/actions/workflows/build.yml/badge.svg)](https://github.com/ahwm/GodaddyWrapper.Net/actions/workflows/build.yml)

## A Brief Intro

GodaddyWrapper.NET is a .NET Wrapper for calling GoDaddy REST API.

[Visit GoDaddy Rest API Docs](https://developer.godaddy.com/doc)

## Authentication

Authentication uses a GoDaddy [Personal Access Token (PAT)](https://developer.godaddy.com/personal-access-token), sent as an `Authorization: Bearer <token>` header. The legacy `sso-key` key/secret model is no longer supported. All calls target the production endpoint (`https://api.godaddy.com`). Documentation vaguely indicates that the ote test environment might be discontinued.

## Usage

### .NET Framework (non-DI)

```cs
var options = new GoDaddyClientOptions 
{
    PersonalAccessToken = "{pat}"
};
var client = new GoDaddyClient(options);
// or simply: var client = new GoDaddyClient("{pat}");

try
{
    var response = await client.CheckDomainAvailableV3(new DomainAvailableV3
    {
        Domain = "google.com"
    });
}
catch (GodaddyException ex) 
{
    //Godaddy Error Message from the Godaddy API
    Console.WriteLine(ex.ErrorResponse.Message);
    //Error Code
    Console.WriteLine(ex.StatusCode);
}
```

### Dependency injection (.NET Framework 4.6.2+ and .NET Core/.NET 5+)

Program.cs / Startup.cs

```cs
builder.Services.AddGoDaddy(configuration.GoDaddyPersonalAccessToken);
// or configure via a delegate:
// builder.Services.AddGoDaddy(o => o.PersonalAccessToken = configuration.GoDaddyPersonalAccessToken);
```

Service Class (or controller) — inject the `IGoDaddyClient` interface

```cs
public class GoDaddyDomainService(IGoDaddyClient goDaddyClient)

try
{
    var response = await goDaddyClient.CheckDomainAvailableV3(new DomainAvailableV3
    {
        Domain = "google.com"
    });
}
catch (GodaddyException ex) 
{
    //Godaddy Error Message from the Godaddy API
    Console.WriteLine(ex.ErrorResponse.Message);
    //Error Code
    Console.WriteLine(ex.StatusCode);
}
```

### Registering a domain (v3 quote → execute)

v3 writes are asynchronous: registration returns an operation you can poll to completion.

```cs
var registration = await goDaddyClient.RegisterDomainWithQuoteAsync(
    new RegistrationQuoteCreate { Domain = "example.com", Period = 1 });

if (registration.OperationId is not null)
{
    var operation = await goDaddyClient.WaitForDomainOperation(registration.OperationId);
    Console.WriteLine(operation.Status); // COMPLETED / FAILED
}
```

## Version History

### 5.0.0

- Switched to GoDaddy Personal Access Token (Bearer) authentication; removed the legacy `sso-key` key/secret model
- Adopted the Domains **v3** API as the primary domains surface (availability, suggestions, quote → register, domain read, nameservers, zone-based DNS, async operation polling)
- Unified dependency injection across .NET Framework 4.6.2 and .NET Standard 2.0
- Added the `IGoDaddyClient` interface for injection/mocking
- Production endpoint only (removed the OTE/`IsTesting` test endpoint)

#### ⚠️Breaking Changes

- `GoDaddyClientOptions` now exposes only `PersonalAccessToken` (removed `AccessKey`, `SecretKey`, `IsTesting`); `AddGoDaddy(...)` takes a PAT
- v1 domain availability, suggestions, purchase, DNS-record, and domain-detail methods were replaced by their v3 equivalents (`CheckDomainAvailableV3`, `SuggestDomainsV3`, the v3 quote/register flow, zone-based DNS, `GetDomainV3`)
- v2 registration methods (`RegisterDomainV2`, `GetRegisterDomainSchemaV2`, `ValidateRegisterDomainV2`) were removed in favor of v3 registration
- Renamed `RetrieveDomainPurhcaseSchema` to `RetrieveDomainPurchaseSchema`

### 4.0.0

- GoDaddy V2 APIs
- GoDaddy ANS API
- Dependency updates

### 3.4.0

- Updated dependencies

### 3.3.0

- Fixed NameServers property on DomainUpdate request

### 3.2.0

- Dependency updates

### 3.1.0

- JSON Updates ([#48](https://github.com/ahwm/GodaddyWrapper.Net/pull/48) by [@dlmelendez](https://github.com/dlmelendez))

### 3.0.0

- Various dependency updates
- Eliminated new `HttpClient` instantiation for every API call

#### ⚠️Breaking Changes

- Renamed `Client` to `GoDaddyClient`
- Constructor now takes `GoDaddyClientOptions` object (.NET Framework 4.6.2+ only)
- Dependency injection pattern with `builder.Services.AddGoDaddy()` registration

### 2.0.0

- Dropped explicit support for .NET Core 2.1
- Updated support to .NET Standard 2.0
- Added support for .NET 6

## Notes

As I have only used the domain features (Suggested Domain, Buy Domain, CheckAvailable, etc.), I haven't tested the other parts of it so feel free to leave an issue if you find something wrong (also welcome to make a pull request). Please provide as much info as you can.

APIs that require a ShopperId require an [API Reseller plan](https://www.godaddy.com/help/what-is-an-api-reseller-plan-5939) and [Good as Gold account](https://www.godaddy.com/help/what-is-good-as-gold-3359)
