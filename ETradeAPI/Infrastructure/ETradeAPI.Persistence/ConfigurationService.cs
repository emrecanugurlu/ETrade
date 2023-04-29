using Microsoft.Extensions.Configuration;
using Microsoft.IdentityModel.Protocols;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ETradeAPI.Persistence
{
    static class ConfigurationService
    {
        public static string GetConnectionString()
        {
            ConfigurationManager configurationManager = new();
            configurationManager.SetBasePath(Path.Combine(Directory.GetCurrentDirectory(),"../../Presentation/ETradeAPI.API"));
            configurationManager.AddJsonFile("appsettings.json");
            return configurationManager.GetConnectionString("MsSQLConnectionString")!;
        }
    }
}
