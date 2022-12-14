using Microsoft.Extensions.Configuration;
using PersonEnv;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Web_10._27DZ.Interfaces
{
    public interface IJsonIteractor
    {
        void JsonWrite(IConfiguration config, Person person);
        void JsonWriteList(IConfiguration config, List<Person> personList);
        Person JsonRead(IConfiguration config);
        List<IPerson> JsonReadList(IConfiguration config);
    }
}
