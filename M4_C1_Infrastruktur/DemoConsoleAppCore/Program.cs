using Microsoft.Extensions.Configuration;
using System;

namespace DemoConsoleAppCore
{
    class Program
    {
        static void Main(string[] args)
        {
            var bldr = new ConfigurationBuilder()
                .AddJsonFile("appsettings.json")
                .AddCommandLine(args);
            var config = bldr.Build();
            Console.WriteLine($"Config: Setting1 = {config["Setting1"]}");

            var settings = new Settings();
            ConfigurationBinder.Bind(config, settings);
            Console.WriteLine($"Binder: Setting1 = {settings.Setting1}, Setting2 = {settings.SubSettings.Setting2}");
        }

        #region Settings

        class Settings
        {
            public string Setting1 { get; set; }
            public SubSettings SubSettings { get; set; } = new SubSettings();
        }

        class SubSettings
        {
            public string Setting2 { get; set; }
        }

        #endregion
    }
}
