using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WebAPI_10._25DZ.Interfaces
{
    interface IPerson
    {
        public string Name { get; set; }
        public int Age { get; set; }
        public string ToString();
    }
}
