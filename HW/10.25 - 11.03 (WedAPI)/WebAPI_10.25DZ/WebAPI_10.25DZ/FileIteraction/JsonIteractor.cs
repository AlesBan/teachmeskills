using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using WebAPI_10._25DZ.Interfaces;
using Newtonsoft.Json;
using WebAPI_10._25DZ.Helpers;

namespace WebAPI_10._25DZ.FileIteraction
{
    public static class JsonIteractor
    {
        public static void JsonWrite(IConfiguration config, Person person)
        {
            string FilePath = MyConfiguration.GetData(config, "FilePath");
            FileStream fileStream = File.Open(FilePath, FileMode.OpenOrCreate);
            StreamWriter streamWriter = new StreamWriter(fileStream);
            string jsonStr = JsonConvert.SerializeObject(person);
            streamWriter.WriteLine(jsonStr);
            streamWriter.Flush();
            fileStream.Close();
        }
        public static void JsonWriteList(IConfiguration config, List<Person> personList)
        {
            string FilePath = MyConfiguration.GetData(config, "FilePath");
            FileStream fileStream = File.Open(FilePath, FileMode.OpenOrCreate);
            StreamWriter streamWriter = new StreamWriter(fileStream);
            string jsonStr = JsonConvert.SerializeObject(personList);
            streamWriter.WriteLine(jsonStr);
            streamWriter.Flush();
            fileStream.Close();
        }
        public static Person JsonRead(IConfiguration config)
        {
            string FilePath = MyConfiguration.GetData(config, "FilePath");
            FileStream fileStream = File.Open(FilePath, FileMode.OpenOrCreate);
            StreamReader streamReader = new StreamReader(fileStream);
            Person person = JsonConvert.DeserializeObject<Person>(streamReader.ReadToEnd());
            fileStream.Close();
            return person;
        }
        public static IEnumerable<Person> JsonReadList(IConfiguration config)
        {
            string FilePath = MyConfiguration.GetData(config, "FilePath");
            FileStream fileStream = File.Open(FilePath, FileMode.OpenOrCreate);
            StreamReader reader = new StreamReader(fileStream);
            IEnumerable<Person> people = JsonConvert.DeserializeObject<IEnumerable<Person>>(reader.ReadToEnd());
            fileStream.Close();
            return people;
        }
    }
}
