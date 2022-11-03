using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Web_10._27DZ.Interfaces;

namespace Web_10._27DZ.PersonEnv
{
    public class PeopleStorage : IPeopleStorage
    {
        public List<IPerson> innerCol { get; set; }

        public PeopleStorage()
        {
            innerCol = new List<IPerson>();
        }

        public int Count
        {
            get { return innerCol.Count; }
        }

        public void Add(IPerson item)
        {
            if (!Contains(item))
            {
                innerCol.Add(item);
            }
           
        }

        public void Clear()
        {
            innerCol.Clear();
        }

        public bool Contains(IPerson item)
        {
            bool found = false;

            foreach (IPerson it in innerCol.Where(x => x.Equals(item)))
            {
                found = true;
            }
            return found;
        }

        public void Remove(IPerson item)
        {

            for (int i = 0; i < innerCol.Count; i++)
            {
                IPerson curPerson = innerCol[i];
                if (new PesonSameDimensions().Equals(curPerson, item))
                {
                    innerCol.RemoveAt(i);
                    break;
                }
            }
        }

        public void UpDate(int index, IPerson item)
        {
            for (int i = 0; i < innerCol.Count; i++)
            {
                if (i == index)
                {
                    innerCol[i] = item;
                }
            }
        }
    }
}
