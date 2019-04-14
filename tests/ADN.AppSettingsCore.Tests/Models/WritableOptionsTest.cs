using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.IO;
using System.Text;
using System.Threading;
using Xunit;

namespace ADN.AppSettingsCore.Tests
{
    public class WritableOptionsTest
    {
        private bool _isOnChangeRaised;

        [Fact]
        public void Value()
        {
            InitializeSettingsFile();

            var writableOptions = GetWritableOptions();
            var name = writableOptions.Value.Name;

            Assert.Equal("Michael", name);
        }

        [Fact]
        public void Update()
        {
            InitializeSettingsFile();

            var writableOptions = GetWritableOptions();
            writableOptions.Update(opt => {
                opt.Name = "Luke";
            });

            // This time is necessary to update correctly the values
            Thread.Sleep(300);
            var name = writableOptions.Value.Name;

            Assert.Equal("Luke", name);
        }

        [Fact]
        public void OnChange()
        {
            InitializeSettingsFile();
            _isOnChangeRaised = false;

            var writableOptions = GetWritableOptions();
            writableOptions.OnChange((opt, str) =>
                OnChangeWritableOptions()
            );

            writableOptions.Update(opt => {
                opt.Name = "Luke";
            });

            // This time is necessary to update correctly the values
            Thread.Sleep(300);

            Assert.True(_isOnChangeRaised);
        }

        private void OnChangeWritableOptions()
        {
            _isOnChangeRaised = true;
        }

        private void InitializeSettingsFile()
        {
            var settings = new JObject
            {
                ["Person"] = new JObject
                {
                    ["Name"] = "Michael"
                }
            };
            File.WriteAllText("appsettings.json", settings.ToString());
        }

        private IWritableOptions<Person> GetWritableOptions()
        {
            var builder = new ConfigurationBuilder()
                .AddJsonFile("appsettings.json", optional: true, reloadOnChange: true);
            var configuration = builder.Build();

            var services = new ServiceCollection();
            services.ConfigureWritable<Person>(configuration.GetSection("Person"));
            services.AddSingleton<IHostingEnvironment, MockHostingEnvironment>();

            var sp = services.BuildServiceProvider();
            var writableOptions = sp.GetService<IWritableOptions<Person>>();

            return writableOptions;
        }
    }
}
