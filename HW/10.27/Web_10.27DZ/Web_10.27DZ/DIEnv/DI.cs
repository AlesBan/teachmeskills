using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Web_10._27DZ.Interfaces;

namespace Web_10._27DZ.DIEnv
{
    public class DI
    {
        public readonly IConfiguration configuration;
        public readonly IJsonIteractor jsonIteractor;
        public DI(IConfiguration configuration, IJsonIteractor jsonIteractor)
        {
            this.configuration = configuration;
            this.jsonIteractor = jsonIteractor;
        }
    }
}
