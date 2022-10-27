using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebAPI_25_10.Interfaces;

namespace WebAPI_25_10
{
    public class HomeService : IHomeService
    {
        public string SaySMT()
        {
            return "Hello";
        }
    }
}
