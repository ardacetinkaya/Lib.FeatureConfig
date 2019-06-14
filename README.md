# Lib.FeatureConfig

[![Build status](https://miyop.visualstudio.com/Lib/_apis/build/status/Lib-FeatureConfig)](https://miyop.visualstudio.com/Lib/_build/latest?definitionId=1)

[![NuGet version (Lib.FeatureConfig)](https://img.shields.io/nuget/v/Lib.FeatureConfig.svg)](https://www.nuget.org/packages/Lib.FeatureConfig/)

## Overview

Feature toggling helps to deliver new features/functions to users quickly without need to change any code. With just small configuration change it helps to reflect change in a feature. Also feature toggling helps A/B testing of an application. 
Fore more info about feature toggle, check;
- https://martinfowler.com/articles/feature-toggles.html
- https://en.wikipedia.org/wiki/Feature_toggle

Lib.FeatureConfig is a simple(I mean very very simple) service extension for ASP.NET Core applications. It also provides enabling feature for a limited date.

## Usage
1. Add Lib.FeatureConfig Nuget package to ASP.NET Core project. https://www.nuget.org/packages/Lib.FeatureConfig/ 
```cmd
dotnet add package Lib.FeatureConfig --version 1.0.3
```

2. **AddFeatures()** service extension to _services_ within ConfigureServices method in Startup.cs
```csharp
        public void ConfigureServices(IServiceCollection services)
        {
            ...
            ..
            .
            services.AddFeatures();

            services.AddRazorPages()
                .AddNewtonsoftJson();
        }
```

3. Add feature(s) info to appsettings.json file as;

```json
  "Features": [
    {
      "Name": "Mars",
      "StartDate": null,
      "EndDate": null
    }
  ]
```
If StartDate and EndDate is given the feature is set to be enabled within that period. If only StartDate is present, it means that the feature is enabled begining from that date. If only EndDate is present, the feature is enabled until that date.

4. Add IFeatureService instance to API Controller or Razor Page with built-in DI(Dependency Injection) in ASP.NET Core. And check if a feature is enabled or not with _IsEnabled([featureName])_ method.

```csharp
    public class IndexModel : PageModel
    {
        IFeatureService _features;

        public string Planet { get; set; } = "World";
        public IndexModel(IFeatureService features)
        {
            _features = features;
        }
        public void OnGet()
        {
            var test = _features.IsEnabled("Mars");
            if (test)
            {
                Planet = "Mars";
            }
        }
    }
```

5. Feel free to fork, open issue or copy all content 😊


* _This repository is also created to demostrate/present manage a project in GitHub, .NET Core development, Azure DevOps pipeline, Nuget.org package management and some development aspects for development teams. If you have any questions or feedbacks, feel free open an issue_
