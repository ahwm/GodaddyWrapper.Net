# GodaddyWrapper.Net

[![nuget](https://img.shields.io/nuget/vpre/GodaddyWrapper.svg)](https://www.nuget.org/packages/GodaddyWrapper)
[![build](https://github.com/ahwm/GodaddyWrapper.Net/actions/workflows/build.yml/badge.svg)](https://github.com/ahwm/GodaddyWrapper.Net/actions/workflows/build.yml)

## A Brief Intro

GodaddyWrapper.NET is a .NET Wrapper for calling GoDaddy REST API.

[Visit GoDaddy Rest API Docs](https://developer.godaddy.com/doc)

## Usage

.NET Framework

```cs
var client = new GoDaddyClient(new GoDaddyClientOptions { AccessKey = "{key}", SecretKey = "{secret}", IsTesting = true /* false to use production */ });

try
{
    var response = await client.CheckDomainAvailable(new DomainAvailable
    {
        domain = "google.com"
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

.NET Core/.NET 5+

Program.cs / Startup.cs

```cs
builder.Services.AddGoDaddy(configuration.GoDaddyAccessKey, configuration.GoDaddySecretKey, configuration.Sandbox);
```

Service Class (or controller)

```cs
public class GoDaddyDomainService(GoDaddyClient goDaddyClient)

try
{
    var response = await client.CheckDomainAvailable(new DomainAvailable
    {
        domain = "google.com"
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

## Version History

### 3.0.0-beta1

- Various dependency updates
- Eliminated new `HttpClient` instantiation for every API call

**⚠️Breaking Changes**

- Renamed `Client` to `GoDaddyClient`
- Constructor now takes `GoDaddyClientOptions` object (.NET Framework 4.6.2+ only)
- Dependency injection pattern with `builder.Services.AddGoDaddy()` registration

### 2.0.0

- Dropped explicit support for .NET Core 2.1
- Updated support to .NET Standard 2.0
- Added support for .NET 6

## Remark

As I have only used the domain features (Suggested Domain, Buy Domain, CheckAvailable, etc.), I haven't tested the other parts of it so feel free to leave an issue if you find something wrong (also welcome to make a pull request). Please provide as much info as you can.
