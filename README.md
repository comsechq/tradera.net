tradera.net
===========

.NET wrapper to access the Tradera Web API

# Introcution

This is .NET .dll you can refer to in your projects if you want to use the [Tradera](http://en.wikipedia.org/wiki/Tradera) [Web API](https://api.tradera.com/v3/) and don't want to add a [Service Reference](http://msdn.microsoft.com/en-us/library/bb628649.aspx).

The only thing this project does is add a Service Reference to:

1. https://api.tradera.com/v3/publicservice.asmx?WSDL. 
2. https://api.tradera.com/v3/restrictedservice.asmx?WSDL. 
3. https://api.tradera.com/v3/searchservice.asmx?WSDL. 
4. https://api.tradera.com/v3/buyerservice.asmx?WSDL. 

All the API code is then generated generated.

# Disclaimer

**WARNING:** This is a .NET wrapper automatically generated from tradera's WSDL. Use it at your own risk.

# Installation

## From Source

Clone this source source, compile, add a reference to `TraderaWebService.dll`.

## Using nuget

We've uploaded this class libary to [nuget](https://www.nuget.org/packages/tradera.net/)!

In Visual Studio, type the following commmand in the `Package Manager Console`:

    Install-Package tradera.net
