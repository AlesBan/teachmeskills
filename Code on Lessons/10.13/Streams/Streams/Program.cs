using System;
using System.IO;
using System.Runtime.Serialization;
using System.Runtime.Serialization.Formatters.Binary;
using System.Text;
using System.Xml.Serialization;
using Newtonsoft.Json;

namespace Streams
{
    class Program
    {
        static void Main(string[] args)
        {
            Person person = new Person(5, "eert");
            FileStream stream = File.Open("wewe.bin", FileMode.OpenOrCreate);

            Console.WriteLine(JsonConvert.SerializeObject(person));
            Console.WriteLine(JsonConvert.DeserializeObject<Person>(JsonConvert.SerializeObject(person)));
        }
    }
    [Serializable]
    public class Person
    {
        public int Age { get; set; }
        public string Name { get; set; }
        public Address address { get; set; }
        public Person()
        {

        }
        public Person(int age, string name)
        {
            Age = age;
            Name = name;
            address = new Address
            {
                Street = "dcedd",
                Country = "ededed"
            };


        }

        public override string ToString()
        {
            return $"{Name} {Age}";
        }


    }
    public class Address
    {
        public string Street { get; set; }
        public string Country { get; set; }
    }
}
