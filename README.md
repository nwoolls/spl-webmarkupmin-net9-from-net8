# README

This repository functions to reproduce an error on startup with WebMarkupMin 2.18+, specifically when the WebMarkupMin NuGet package is referenced from a .NET 8 classlib, which is in turn consumed by a .NET 9 project.

## Steps to reproduce

1. Clone this repository
2. Run the application - no error on startup is seen
3. Open `ClassLib.csproj` and change the version of `WebMarkupMin.AspNetCore8` to `2.18.1`
4. Open `WebApplicationBuilderExtensions.cs` and update the using statements accordingly (see comments in file)
5. Run the application - an error on startup is seen:

```
System.TypeLoadException: Could not load type 'WebMarkupMin.AspNet.Common.Compressors.CommonCompressionSettingsBase' from assembly 'WebMarkupMin.AspNet.Common, Version=2.18.0.0, Culture=neutral, PublicKeyToken=99472178d266584b'.
```