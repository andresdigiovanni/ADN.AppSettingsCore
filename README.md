# Application Settings Utils Library for .NET Core

ADN.AppSettingsCore is a cross-platform open-source library that allows to modify the application settings (appsettings.json) in an easy way.

[![Build Status](https://travis-ci.org/andresdigiovanni/ADN.AppSettingsCore.svg?branch=master)](https://travis-ci.org/andresdigiovanni/ADN.AppSettingsCore)
[![NuGet](https://img.shields.io/nuget/v/ADN.AppSettingsCore.svg)](https://www.nuget.org/packages/ADN.AppSettingsCore/)
[![BCH compliance](https://bettercodehub.com/edge/badge/andresdigiovanni/ADN.AppSettingsCore?branch=master)](https://bettercodehub.com/)
[![Maintainability Rating](https://sonarcloud.io/api/project_badges/measure?project=andresdigiovanni_ADN.AppSettingsCore&metric=sqale_rating)](https://sonarcloud.io/dashboard?id=andresdigiovanni_ADN.AppSettingsCore)
[![Quality](https://sonarcloud.io/api/project_badges/measure?project=andresdigiovanni_ADN.AppSettingsCore&metric=alert_status)](https://sonarcloud.io/dashboard?id=andresdigiovanni_ADN.AppSettingsCore)
[![License: MIT](https://img.shields.io/badge/License-MIT-yellow.svg)](https://opensource.org/licenses/MIT)

## Basic usage

Update the current value of the section.

```csharp
var sp = services.BuildServiceProvider();
var writableOptions = sp.GetService<IWritableOptions<Person>>();

writableOptions.Update(opt => {
    opt.Name = "Anakin";
});

var name = writableOptions.Value.Name; // Anakin

writableOptions.OnChange((opt, str) =>
    OnChangePersonName(opt.Name)
);

writableOptions.Update(opt => {
    opt.Name = "Darth Vader";
});

// OnChangePersonName is call

name = writableOptions.Value.Name; // Darth Vader
```

## Installation

ADN.AppSettingsCore runs on Windows, Linux, and macOS.

Once you have an app, you can install the ADN.AppSettingsCore NuGet package from the NuGet package manager:

```
Install-Package ADN.AppSettingsCore
```

Or alternatively you can add the ADN.AppSettingsCore package from within Visual Studio's NuGet package manager.

## Examples

Please find examples and the documentation at the [wiki](https://github.com/andresdigiovanni/ADN.AppSettingsCore/wiki) of this repository.

## Contributing

We welcome contributions! Please review our [contribution guide](CONTRIBUTING.md).

## License

ADN.AppSettingsCore is licensed under the [MIT license](LICENSE).
