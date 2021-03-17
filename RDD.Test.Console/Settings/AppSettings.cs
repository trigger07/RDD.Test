
namespace RDD.Test.Console.Settings
{
    using Microsoft.Extensions.Configuration;

    public class AppSettings
    {
        public string FileName { get; set; }
        public int ColumnsLength { get; set; }
        public string ResultFileName { get; set; }
        public static AppSettings LoadAppSettings()
        {
            IConfigurationRoot configRoot = new ConfigurationBuilder()
                .AddJsonFile("Settings/settings.json")
                .Build();
            AppSettings appSettings = configRoot.Get<AppSettings>();
            return appSettings;
        }
    }
}
