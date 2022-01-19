[![Build Status](https://travis-ci.com/SamhammerAG/Samhammer.Web.Common.svg?branch=master)](https://travis-ci.com/SamhammerAG/Samhammer.Web.Common)

## Samhammer.Web.Common

This is a collection of tools to make creation of web projects simpler.
It provides functionality that can be used in every web API project that is built with ASP.NET Core.

#### How to add this to your project:
- reference this package to your project: https://www.nuget.org/packages/Samhammer.Web.Common/

## Available Features

#### Version endpoint
If it is enabled you get an endpoint "/version" and "/api/version" that returns a json with the version number of the entry assembly and the hosting environment.

Add the following to the method Configure of your Startup.cs to enable it:
```csharp
app.UseVersion();
```

#### Ping endpoint
If it is enabled you get an endpoint "/ping" that just returns "OK".

Add the following to the method Configure of your Startup.cs to enable it:
```csharp
app.UsePing();
```

#### HttpClient with self signed certificates
If it is enabled you get an http client that also accepts untrusted certificates.

Add the following extension to your IWebHostBuilder in Program.cs:
```csharp
.AddUnsignedHttpClient()
```

Afterwards you can create a specific http client by using the following code:
```csharp
var client = HttpClientFactory.CreateClient(HttpClientNames.UnsignedHttpClient);
```

Furthermore you can allow self  signed certs for an existing http client with the following block added to your IHttpClientBuilder:

```csharp
.AddAllowUnsignedPrimaryHandler()
```

#### Exception handling
If you don't want to get error messages in your json api you can enable a default exception handler.

Add the following to the method Configure of your Startup.cs to enable it:
```csharp
app.UseDefaultExceptionHandler();
```

## Contribute

#### How to publish package
- Create a tag and let the github action do the publishing for you
