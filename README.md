tradera.net
===========

.NET wrapper to access the Tradera Web API

# Introduction

This is .NET standard library you can refer to in your projects if you want to use the [Tradera](http://en.wikipedia.org/wiki/Tradera) [Web API](https://api.tradera.com/v3/) and don't want to add a [Service Reference](http://msdn.microsoft.com/en-us/library/bb628649.aspx).

The only thing this project does is add a Service Reference to:

1. https://api.tradera.com/v3/buyerservice.asmx?WSDL.
1. https://api.tradera.com/v3/publicservice.asmx?WSDL.
1. https://api.tradera.com/v3/restrictedservice.asmx?WSDL.
1. https://api.tradera.com/v3/searchservice.asmx?WSDL.

All the API code is generated generated using the `dotnet-svcutil` CLI tool.

```
dotnet tool install --global dotnet-svcutil
```

The following commands will generate the code for the four tradera APIs and keep them in separate folders and namespaces

```
dotnet-svcutil https://api.tradera.com/v3/buyerservice.asmx -d BuyerService -n "*,TraderaWebService.BuyerService"
dotnet-svcutil https://api.tradera.com/v3/publicservice.asmx -d "PublicService" -n "*,TraderaWebService.PublicService"
dotnet-svcutil https://api.tradera.com/v3/restrictedservice.asmx -d RestrictedService -n "*,TraderaWebService.RestrictedService"
dotnet-svcutil https://api.tradera.com/v3/searchservice.asmx -d SearchService -n "*,TraderaWebService.SearchService"
```

To reflect any API change you can run these commands to _update_ the service references

```
cd "path to project"
dotnet-svcutil --update .\BuyerService
dotnet-svcutil --update .\PublicService
dotnet-svcutil --update .\RestrictedService
dotnet-svcutil --update .\SearchService
```

# Disclaimer

**WARNING:** This is a .NET wrapper automatically generated from tradera's WSDL. Use it at your own risk.

# Installation

## From Source

Clone this source source, compile, add a reference to `TraderaWebService.dll`.

## Using nuget

We've uploaded this class libary to [nuget](https://www.nuget.org/packages/tradera.net/)!

In Visual Studio, type the following commmand in the `Package Manager Console`:

```
Install-Package TraderaWebService -Pre
```