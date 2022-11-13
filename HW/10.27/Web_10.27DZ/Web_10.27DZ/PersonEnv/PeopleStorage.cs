using Microsoft.Extensions.Configuration;
using PersonEnv;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Web_10._27DZ.DIEnv;
using Web_10._27DZ.Interfaces;

namespace Web_10._27DZ.PersonEnv
{
    public class PeopleStorage : IPeopleStorage
    {
        public List<Person> InnerCol { get; set; }

        public PeopleStorage(IJsonIteractor jsonIteractor, IConfiguration configuration)
        {
            InnerCol = new List<Person>();
            InnerCol = jsonIteractor.JsonReadList(configuration);
        }

        public int Count
        {
            get { return InnerCol.Count; }
        }

        public void Add(Person item)
        {
            InnerCol.Add(item);
        }

        public void Clear()
        {
            InnerCol.Clear();
        }

        public bool Contains(Guid id)
        {
            bool found = false;

            foreach (Person it in InnerCol)
            {
                if (it.id == id)
                {
                    found = true;
                }
                
            }
            return found;
        }

        public void Remove(Person item)
        {
            for (int i = 0; i < InnerCol.Count; i++)
            {
                if (InnerCol[i].id == item.id)
                {
                    InnerCol.RemoveAt(i);
                    break;
                }
            }
        }

        public void UpDate(Guid id, Person item)
        {
            foreach (Person person in InnerCol.Where(x => x.id == id).ToList())
            {
                InnerCol[InnerCol.IndexOf(person)] = item;
            }
        }

        public void Save(DI dI)
        {
            dI.jsonIteractor.JsonWriteList(dI.configuration, InnerCol);
        }
    }
}
