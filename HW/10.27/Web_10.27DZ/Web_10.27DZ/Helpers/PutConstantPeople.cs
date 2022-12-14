using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebAPI_10._25DZ.DI;

namespace Web_10._27DZ.Helpers
{
    public static class PutConstantPeople
    {
        public static void PutDefaultPeople(IConfiguration config, JsonIteractor jsonIteractor)
        {
            jsonIteractor.JsonWriteList(config, Constants.people);
        }
    }
}
