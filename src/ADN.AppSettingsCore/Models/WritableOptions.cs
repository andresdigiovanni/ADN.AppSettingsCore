using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Options;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;

namespace ADN.AppSettingsCore
{
    /// <summary>
    /// Class of access to a modifiable section of a JSON file.
    /// </summary>
    /// <typeparam name="T">The type of the element in the configuration section.</typeparam>
    public class WritableOptions<T> : IWritableOptions<T> where T : class, new()
    {
        private readonly IHostingEnvironment _environment;
        private readonly IOptionsMonitor<T> _options;
        private readonly string _section;
        private readonly string _file;

        public WritableOptions(
            IHostingEnvironment environment,
            IOptionsMonitor<T> options,
            string section,
            string file)
        {
            _environment = environment;
            _options = options;
            _section = section;
            _file = file;
        }

        /// <summary>
        /// Get the current value of the section.
        /// </summary>
        /// <example>
        /// <code lang="csharp">
        /// var sp = services.BuildServiceProvider();
        /// <![CDATA[var writableOptions = sp.GetService<IWritableOptions<Person>>();]]>
        /// var name = writableOptions.Value.Name;
        /// </code>
        /// </example>
        public T Value => _options.CurrentValue;

        /// <summary>
        /// Returns a configured TOptions instance with the given name.
        /// </summary>
        public T Get(string name) => _options.Get(name);

        /// <summary>
        /// Registers a listener to be called whenever a named TOptions changes.
        /// </summary>
        /// <param name="listener">The action to be invoked when TOptions has changed.</param>
        /// <returns>An IDisposable which should be disposed to stop listening for changes.</returns>
        /// <example>
        /// <code lang="csharp">
        /// var sp = services.BuildServiceProvider();
        /// <![CDATA[var writableOptions = sp.GetService<IWritableOptions<Person>>();]]>
        /// writableOptions.OnChange((opt, str) =>
        ///     OnChangePersonName(opt.Name)
        /// );
        /// </code>
        /// </example>
        public IDisposable OnChange(Action<T, string> listener)
        {
            return _options.OnChange(listener);
        }

        /// <summary>
        /// Update the current value of the section.
        /// </summary>
        /// <example>
        /// <code lang="csharp">
        /// var sp = services.BuildServiceProvider();
        /// <![CDATA[var writableOptions = sp.GetService<IWritableOptions<Person>>();]]>
        /// writableOptions.Update(opt => {
        ///     opt.Name = "Luke";
        /// });
        /// </code>
        /// </example>
        public void Update(Action<T> applyChanges)
        {
            var fileProvider = _environment.ContentRootFileProvider;
            var fileInfo = fileProvider.GetFileInfo(_file);
            var physicalPath = fileInfo.PhysicalPath;

            var jObject = JsonConvert.DeserializeObject<JObject>(File.ReadAllText(physicalPath));
            var sectionObject = jObject.TryGetValue(_section, out JToken section) ?
                JsonConvert.DeserializeObject<T>(section.ToString()) : (Value ?? new T());

            applyChanges(sectionObject);

            jObject[_section] = JObject.Parse(JsonConvert.SerializeObject(sectionObject));
            File.WriteAllText(physicalPath, JsonConvert.SerializeObject(jObject, Formatting.Indented));
        }
    }
}
