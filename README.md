GodaddyWrapper.Net
======================

A Brief Intro
-------------------

GodaddyWrapper.NET is a .NET Core Wrapper for calling GoDaddy REST API.

[Visit Godaddy Rest API Docs](https://developer.godaddy.com/doc)


Usage
-------------------

```cs
var client = new Client("{key}", "{secret}");
try
{
    var test = await client.CheckDomainAvailable(new GodaddyWrapper.Requests.DomainAvailable
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

