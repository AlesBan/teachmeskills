using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebAPI_10._25DZ.Interfaces;

namespace WebAPI_10._25DZ.Helpers
{
    public static class MyConfiguration
    {
        public static string GetData(IConfiguration config, string key)
        {
            return config.GetValue<string>(key);
        }
    }
}
