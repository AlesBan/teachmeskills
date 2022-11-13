using Microsoft.Extensions.Configuration;
using PersonEnv;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Web_10._27DZ.DIEnv;

namespace Web_10._27DZ.Interfaces
{
    public interface IPeopleStorage
    {
        public List<Person> InnerCol { get; set; }
        public int Count { get; }
        public void Add(Person item);
        public void Clear();
        public bool Contains(Guid id);
        public void Remove(Person item);
        public void UpDate(Guid id, Person item);
        public void Save(DI dI);
    }
}
