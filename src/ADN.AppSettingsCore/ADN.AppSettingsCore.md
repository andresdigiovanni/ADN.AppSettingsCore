<a name='assembly'></a>
# ADN.AppSettingsCore

## Contents

- [IWritableOptions\`1](#T-ADN-AppSettingsCore-IWritableOptions`1 'ADN.AppSettingsCore.IWritableOptions`1')
  - [OnChange(listener)](#M-ADN-AppSettingsCore-IWritableOptions`1-OnChange-System-Action{`0,System-String}- 'ADN.AppSettingsCore.IWritableOptions`1.OnChange(System.Action{`0,System.String})')
  - [Update()](#M-ADN-AppSettingsCore-IWritableOptions`1-Update-System-Action{`0}- 'ADN.AppSettingsCore.IWritableOptions`1.Update(System.Action{`0})')
- [ServiceCollectionExtensions](#T-ADN-AppSettingsCore-ServiceCollectionExtensions 'ADN.AppSettingsCore.ServiceCollectionExtensions')
  - [ConfigureWritable\`\`1(services,section,file)](#M-ADN-AppSettingsCore-ServiceCollectionExtensions-ConfigureWritable``1-Microsoft-Extensions-DependencyInjection-IServiceCollection,Microsoft-Extensions-Configuration-IConfigurationSection,System-String- 'ADN.AppSettingsCore.ServiceCollectionExtensions.ConfigureWritable``1(Microsoft.Extensions.DependencyInjection.IServiceCollection,Microsoft.Extensions.Configuration.IConfigurationSection,System.String)')
- [WritableOptions\`1](#T-ADN-AppSettingsCore-WritableOptions`1 'ADN.AppSettingsCore.WritableOptions`1')
  - [Value](#P-ADN-AppSettingsCore-WritableOptions`1-Value 'ADN.AppSettingsCore.WritableOptions`1.Value')
  - [Get()](#M-ADN-AppSettingsCore-WritableOptions`1-Get-System-String- 'ADN.AppSettingsCore.WritableOptions`1.Get(System.String)')
  - [OnChange(listener)](#M-ADN-AppSettingsCore-WritableOptions`1-OnChange-System-Action{`0,System-String}- 'ADN.AppSettingsCore.WritableOptions`1.OnChange(System.Action{`0,System.String})')
  - [Update()](#M-ADN-AppSettingsCore-WritableOptions`1-Update-System-Action{`0}- 'ADN.AppSettingsCore.WritableOptions`1.Update(System.Action{`0})')

<a name='T-ADN-AppSettingsCore-IWritableOptions`1'></a>
## IWritableOptions\`1 `type`

##### Namespace

ADN.AppSettingsCore

##### Summary

Class of access to a modifiable section of a JSON file.

##### Generic Types

| Name | Description |
| ---- | ----------- |
| T | The type of the element in the configuration section. |

<a name='M-ADN-AppSettingsCore-IWritableOptions`1-OnChange-System-Action{`0,System-String}-'></a>
### OnChange(listener) `method`

##### Summary

Registers a listener to be called whenever a named TOptions changes.

##### Returns

An IDisposable which should be disposed to stop listening for changes.

##### Parameters

| Name | Type | Description |
| ---- | ---- | ----------- |
| listener | [System.Action{\`0,System.String}](http://msdn.microsoft.com/query/dev14.query?appId=Dev14IDEF1&l=EN-US&k=k:System.Action 'System.Action{`0,System.String}') | The action to be invoked when TOptions has changed. |

<a name='M-ADN-AppSettingsCore-IWritableOptions`1-Update-System-Action{`0}-'></a>
### Update() `method`

##### Summary

Update the current value of the section.

##### Parameters

This method has no parameters.

<a name='T-ADN-AppSettingsCore-ServiceCollectionExtensions'></a>
## ServiceCollectionExtensions `type`

##### Namespace

ADN.AppSettingsCore

##### Summary

Extensions for Microsoft.Extensions.DependencyInjection.IServiceCollection.

<a name='M-ADN-AppSettingsCore-ServiceCollectionExtensions-ConfigureWritable``1-Microsoft-Extensions-DependencyInjection-IServiceCollection,Microsoft-Extensions-Configuration-IConfigurationSection,System-String-'></a>
### ConfigureWritable\`\`1(services,section,file) `method`

##### Summary

Configure an overwritable configuration section of the JSON configuration provider.

##### Parameters

| Name | Type | Description |
| ---- | ---- | ----------- |
| services | [Microsoft.Extensions.DependencyInjection.IServiceCollection](#T-Microsoft-Extensions-DependencyInjection-IServiceCollection 'Microsoft.Extensions.DependencyInjection.IServiceCollection') | Contract for a collection of service descriptors. |
| section | [Microsoft.Extensions.Configuration.IConfigurationSection](#T-Microsoft-Extensions-Configuration-IConfigurationSection 'Microsoft.Extensions.Configuration.IConfigurationSection') | Configuration section of the JSON configuration provider. |
| file | [System.String](http://msdn.microsoft.com/query/dev14.query?appId=Dev14IDEF1&l=EN-US&k=k:System.String 'System.String') | Configuration file. Default: appsettings.json. |

##### Generic Types

| Name | Description |
| ---- | ----------- |
| T | The type of the element in the configuration section. |

##### Example

```csharp
var builder = new ConfigurationBuilder()
    .AddJsonFile("appsettings.json", optional: true, reloadOnChange: true);
var configuration = builder.Build();
var services = new ServiceCollection();
```

<a name='T-ADN-AppSettingsCore-WritableOptions`1'></a>
## WritableOptions\`1 `type`

##### Namespace

ADN.AppSettingsCore

##### Summary

Class of access to a modifiable section of a JSON file.

##### Generic Types

| Name | Description |
| ---- | ----------- |
| T | The type of the element in the configuration section. |

<a name='P-ADN-AppSettingsCore-WritableOptions`1-Value'></a>
### Value `property`

##### Summary

Get the current value of the section.

##### Example

```csharp
var sp = services.BuildServiceProvider();
```

<a name='M-ADN-AppSettingsCore-WritableOptions`1-Get-System-String-'></a>
### Get() `method`

##### Summary

Returns a configured TOptions instance with the given name.

##### Parameters

This method has no parameters.

<a name='M-ADN-AppSettingsCore-WritableOptions`1-OnChange-System-Action{`0,System-String}-'></a>
### OnChange(listener) `method`

##### Summary

Registers a listener to be called whenever a named TOptions changes.

##### Returns

An IDisposable which should be disposed to stop listening for changes.

##### Parameters

| Name | Type | Description |
| ---- | ---- | ----------- |
| listener | [System.Action{\`0,System.String}](http://msdn.microsoft.com/query/dev14.query?appId=Dev14IDEF1&l=EN-US&k=k:System.Action 'System.Action{`0,System.String}') | The action to be invoked when TOptions has changed. |

##### Example

```csharp
var sp = services.BuildServiceProvider();
```

<a name='M-ADN-AppSettingsCore-WritableOptions`1-Update-System-Action{`0}-'></a>
### Update() `method`

##### Summary

Update the current value of the section.

##### Parameters

This method has no parameters.

##### Example

```csharp
var sp = services.BuildServiceProvider();
```
