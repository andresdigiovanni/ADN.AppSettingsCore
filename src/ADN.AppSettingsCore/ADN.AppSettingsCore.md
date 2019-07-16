# ADN.AppSettingsCore

# Content

- [IWritableOptions<T>](#T:ADN.AppSettingsCore.IWritableOptions`1)

  - [OnChange(System.Action{`0,System.String})](#IWritableOptions<T>.OnChange(System.Action{`0,System.String}))

  - [Update(System.Action{`0})](#IWritableOptions<T>.Update(System.Action{`0}))

- [ServiceCollectionExtensions](#T:ADN.AppSettingsCore.ServiceCollectionExtensions)

  - [ConfigureWritable`<T>(services, section, file)](#ServiceCollectionExtensions.ConfigureWritable`<T>(services,section,file))

- [WritableOptions<T>](#T:ADN.AppSettingsCore.WritableOptions`1)

  - [Get(System.String)](#WritableOptions<T>.Get(System.String))

  - [OnChange(System.Action{`0,System.String})](#WritableOptions<T>.OnChange(System.Action{`0,System.String}))

  - [Update(System.Action{`0})](#WritableOptions<T>.Update(System.Action{`0}))

  - [.WritableOptions`1.Value](#P:ADN.AppSettingsCore.WritableOptions`1.Value)

<a name='T:ADN.AppSettingsCore.IWritableOptions`1'></a>


## IWritableOptions<T>

Class of access to a modifiable section of a JSON file.

<a name='IWritableOptions<T>.OnChange(System.Action{`0,System.String})'></a>


### OnChange(System.Action{`0,System.String})

Registers a listener to be called whenever a named TOptions changes.


#### Parameters

| Name | Description |
| ---- | ----------- |
| listener | *Unknown type*<br>The action to be invoked when TOptions has changed. |


#### Returns

An IDisposable which should be disposed to stop listening for changes.

<a name='IWritableOptions<T>.Update(System.Action{`0})'></a>


### Update(System.Action{`0})

Update the current value of the section.

<a name='T:ADN.AppSettingsCore.ServiceCollectionExtensions'></a>


## ServiceCollectionExtensions

Extensions for Microsoft.Extensions.DependencyInjection.IServiceCollection.

<a name='ServiceCollectionExtensions.ConfigureWritable`<T>(services,section,file)'></a>


### ConfigureWritable`<T>(services, section, file)

Configure an overwritable configuration section of the JSON configuration provider.


#### Parameters

| Name | Description |
| ---- | ----------- |
| services | *Microsoft.Extensions.DependencyInjection.IServiceCollection*<br>Contract for a collection of service descriptors. |

#### Parameters

| section | *Microsoft.Extensions.Configuration.IConfigurationSection*<br>Configuration section of the JSON configuration provider. |

#### Parameters

| file | *System.String*<br>Configuration file. Default: appsettings.json. |


#### Example

```csharp
var builder = new ConfigurationBuilder()
.AddJsonFile("appsettings.json", optional: true, reloadOnChange: true);
var configuration = builder.Build();

var services = new ServiceCollection();
services.ConfigureWritable<Person>(configuration.GetSection("Person"));```

<a name='T:ADN.AppSettingsCore.WritableOptions`1'></a>


## WritableOptions<T>

Class of access to a modifiable section of a JSON file.

<a name='WritableOptions<T>.Get(System.String)'></a>


### Get(System.String)

Returns a configured TOptions instance with the given name.

<a name='WritableOptions<T>.OnChange(System.Action{`0,System.String})'></a>


### OnChange(System.Action{`0,System.String})

Registers a listener to be called whenever a named TOptions changes.


#### Parameters

| Name | Description |
| ---- | ----------- |
| listener | *Unknown type*<br>The action to be invoked when TOptions has changed. |


#### Returns

An IDisposable which should be disposed to stop listening for changes.


#### Example

```csharp
var sp = services.BuildServiceProvider();
var writableOptions = sp.GetService<IWritableOptions<Person>>();
writableOptions.OnChange((opt, str) =>
OnChangePersonName(opt.Name)
);
```

<a name='WritableOptions<T>.Update(System.Action{`0})'></a>


### Update(System.Action{`0})

Update the current value of the section.


#### Example

```csharp
var sp = services.BuildServiceProvider();
var writableOptions = sp.GetService<IWritableOptions<Person>>();
writableOptions.Update(opt => {
opt.Name = "Luke";
});
```

<a name='P:ADN.AppSettingsCore.WritableOptions`1.Value'></a>


### .WritableOptions`1.Value

Get the current value of the section.


#### Example

```csharp
var sp = services.BuildServiceProvider();
var writableOptions = sp.GetService<IWritableOptions<Person>>();
var name = writableOptions.Value.Name;
```

