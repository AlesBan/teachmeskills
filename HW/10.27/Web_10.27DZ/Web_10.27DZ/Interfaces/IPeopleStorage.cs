using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Web_10._27DZ.Interfaces
{
    public interface IPeopleStorage
    {
        public List<IPerson> innerCol { get; set; }
        public int Count { get; }
        public void Add(IPerson item);
        public void Clear();
        public bool Contains(IPerson item);
        public void Remove(IPerson item);
        public void UpDate(int index, IPerson item);
    }
}
