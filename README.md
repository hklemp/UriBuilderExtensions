# UriBuilderExtensions

[![NuGet version (UriBuilderExtension)](https://img.shields.io/nuget/v/UriBuilderExtension.svg?style=flat-square)](https://www.nuget.org/packages/UriBuilderExtension/)

Extension for the .net UriBuilder to simply extend the query

## Basics:
* Add the nuget Package to your Project
* Add Using eg. `using UriBuilderExtension`;

## Usage
---
To add a query parameter use the method `SetQueryParam``
``` csharp
UriBuilder uriBuilder = new UriBuilder();
           uriBuilder.Scheme = "https";
           uriBuilder.Host = "www.google.com";
           uriBuilder.Path = "search";
           // The magic happens here  
           uriBuilder.SetQueryParam("q", "query+goes+here");
           // or 
           uriBuilder.SetQueryParam("p", new String[] {"here" ,"and+here"});
``` 
If you want to check is a parameter exsit in the query use 
```csharp
bool exsists = uriBuilder.HasQueryParam("p")
```

To get the value/values of a parameter use 
```csharp
var value = uriBuilder.GetQueryParamValue("p")
```

To get all parameter keys of the query use
```csharp
var value = uriBuilder.GetQueryParamKeys();
```

To Remove one parameter use
```csharp
uriBuilder.RemoveQueryParam("q");
```






