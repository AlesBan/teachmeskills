using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Web_10._27DZ.Interfaces
{
    public interface IPerson
    {
        public string Name { get; set; }
        public int Age { get; set; }
        public string ToString();
    }
}
