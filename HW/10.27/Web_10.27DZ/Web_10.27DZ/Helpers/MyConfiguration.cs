using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Web_10._27DZ.Helpers
{
    public static class MyConfiguration
    {
        public static string GetData(IConfiguration config, string key)
        {
            return config.GetValue<string>(key);
        }
    }
}
