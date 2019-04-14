using Microsoft.Extensions.Options;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ADN.AppSettingsCore
{
    public interface IWritableOptions<out T> : IOptionsSnapshot<T> where T : class, new()
    {
        IDisposable OnChange(Action<T, string> listener);
        void Update(Action<T> applyChanges);
    }
}
