using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Web_10._27DZ.Interfaces;

namespace Web_10._27DZ.PersonEnv
{
    public class PersonDto : IPersonDto
    {
        public string Name { get; set; }
        public int Age { get; set; }
    }
}
