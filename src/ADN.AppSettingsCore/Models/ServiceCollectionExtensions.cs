using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Options;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ADN.AppSettingsCore
{
    /// <summary>
    /// Extensions for Microsoft.Extensions.DependencyInjection.IServiceCollection.
    /// </summary>
    public static class ServiceCollectionExtensions
    {
        /// <summary>
        /// Configure an overwritable configuration section of the JSON configuration provider.
        /// </summary>
        /// <typeparam name="T">The type of the element in the configuration section.</typeparam>
        /// <param name="services">Contract for a collection of service descriptors.</param>
        /// <param name="section">Configuration section of the JSON configuration provider.</param>
        /// <param name="file">Configuration file. Default: appsettings.json.</param>
        /// <example>
        /// <code lang="csharp">
        /// var builder = new ConfigurationBuilder()
        ///     .AddJsonFile("appsettings.json", optional: true, reloadOnChange: true);
        /// var configuration = builder.Build();
        /// 
        /// var services = new ServiceCollection();
        /// services.ConfigureWritable<Person>(configuration.GetSection("Person"));
        /// </code>
        /// </example>
        public static void ConfigureWritable<T>(
            this IServiceCollection services,
            IConfigurationSection section,
            string file = "appsettings.json") where T : class, new()
        {
            services.Configure<T>(section);
            services.AddTransient<IWritableOptions<T>>(provider =>
            {
                var environment = provider.GetService<IHostingEnvironment>();
                var options = provider.GetService<IOptionsMonitor<T>>();
                return new WritableOptions<T>(environment, options, section.Key, file);
            });
        }
    }
}
