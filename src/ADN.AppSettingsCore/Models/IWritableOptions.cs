using Microsoft.Extensions.Options;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ADN.AppSettingsCore
{
    /// <summary>
    /// Class of access to a modifiable section of a JSON file.
    /// </summary>
    /// <typeparam name="T">The type of the element in the configuration section.</typeparam>
    public interface IWritableOptions<out T> : IOptionsSnapshot<T> where T : class, new()
    {
        /// <summary>
        /// Registers a listener to be called whenever a named TOptions changes.
        /// </summary>
        /// <param name="listener">The action to be invoked when TOptions has changed.</param>
        /// <returns>An IDisposable which should be disposed to stop listening for changes.</returns>
        IDisposable OnChange(Action<T, string> listener);

        /// <summary>
        /// Update the current value of the section.
        /// </summary>
        void Update(Action<T> applyChanges);
    }
}
