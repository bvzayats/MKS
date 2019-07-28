using System.IO;
using Microsoft.Extensions.Configuration;

namespace NedoNet.API.Helpers {
    public static class ConnectionStringHelper {
        public static string ConnectionString = GetConnectionStringFromAppsettingsJson();

        private static string GetConnectionStringFromAppsettingsJson() {
            var configurationBuilder = new ConfigurationBuilder()

                .SetBasePath(Directory.GetCurrentDirectory())
                .AddJsonFile("appsettings.json");


            var configurationRoot = configurationBuilder.Build();
            return configurationRoot.GetConnectionString( "DefaultConnection" );
        }
    }
}