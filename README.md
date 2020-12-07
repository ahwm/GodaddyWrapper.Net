# GodaddyWrapper.Net

[![nuget](https://img.shields.io/nuget/vpre/GodaddyWrapper.svg)](https://www.nuget.org/packages/GodaddyWrapper)
[![Build status](https://ci.appveyor.com/api/projects/status/utayqebihtewq6kq/branch/master)](https://ci.appveyor.com/project/ahwm/godaddywrapper-net)

A Brief Intro
-------------------

GodaddyWrapper.NET is a .NET Wrapper for calling GoDaddy REST API.

[Visit GoDaddy Rest API Docs](https://developer.godaddy.com/doc)

Pre-release version in Nuget
[Visit Nuget](https://www.nuget.org/packages/GodaddyWrapper/)


Usage
-------------------

```cs
var client = new Client("{key}", "{secret}", "https://api.godaddy.com/api/v1/"); 
// Default is https://api.ote-godaddy.com/api/v1/ (Test link of Godaddy)
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

Remark
-------------------
As I only use the domain part (Suggested Domain, Buy Domain, CheckAvailable, etc.), I haven't tested the other parts of it so feel free to leave an issue if you find something wrong (also welcome to make a pull request). Please provide as much info as you can.
