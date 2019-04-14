using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.FileProviders;
using System;
using System.Collections.Generic;
using System.IO;
using System.Text;

namespace ADN.AppSettingsCore.Tests
{
    public class MockHostingEnvironment : IHostingEnvironment
    {
        public string EnvironmentName
        {
            get => throw new NotImplementedException();
            set => throw new NotImplementedException();
        }

        public string ApplicationName
        {
            get => throw new NotImplementedException();
            set => throw new NotImplementedException();
        }
        public string WebRootPath { get; set; } = Path.Combine(Environment.CurrentDirectory, "wwwroot");
        public IFileProvider WebRootFileProvider
        {
            get => throw new NotImplementedException();
            set => throw new NotImplementedException();
        }

        public string ContentRootPath { get; set; } = Environment.CurrentDirectory;

        public IFileProvider ContentRootFileProvider
        {
            get => new PhysicalFileProvider(Directory.GetCurrentDirectory());
            set => throw new NotImplementedException();
        }
    }
}
