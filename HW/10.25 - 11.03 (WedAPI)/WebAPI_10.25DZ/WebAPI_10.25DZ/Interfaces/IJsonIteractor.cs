using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WebAPI_10._25DZ.Interfaces
{
    public interface IJsonIteractor
    {
        void JsonWrite(IConfiguration config, Person person);
        void JsonWriteList(IConfiguration config, List<Person> personList);
        Person JsonRead(IConfiguration config);
        IEnumerable<Person> JsonReadList(IConfiguration config);
    }
}
