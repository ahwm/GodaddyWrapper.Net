GodaddyWrapper.Net
======================

A Brief Intro
-------------------

GodaddyWrapper.NET is a .NET Core Wrapper for calling GoDaddy REST API.

[Visit Godaddy Rest API Docs](https://developer.godaddy.com/doc)

Pre-release version in Nuget
[Visit Nuget](https://www.nuget.org/packages/GodaddyWrapper/)


Usage
-------------------

```cs
var client = new Client("{key}", "{secret}");
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

