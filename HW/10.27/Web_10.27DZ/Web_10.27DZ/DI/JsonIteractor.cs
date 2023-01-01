using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using Web_10._27DZ.Interfaces;
using Newtonsoft.Json;
using Web_10._27DZ.Helpers;
using Web_10._27DZ;
using PersonEnv;

namespace WebAPI_10._25DZ.DI
{
    public class JsonIteractor : IJsonIteractor
    {
        public void JsonWrite(IConfiguration config, Person person)
        {
            string FilePath = MyConfiguration.GetData(config, "FilePath");
            FileStream fileStream = File.Open(FilePath, FileMode.OpenOrCreate);
            StreamWriter streamWriter = new StreamWriter(fileStream);
            string jsonStr = JsonConvert.SerializeObject(person);
            streamWriter.WriteLine(jsonStr);
            streamWriter.Flush();
            fileStream.Close();
        }
        public void JsonWriteList(IConfiguration config, List<Person> personList)
        {
            string FilePath = MyConfiguration.GetData(config, "FilePath");
            FileStream fileStream = File.Open(FilePath, FileMode.OpenOrCreate);
            StreamWriter streamWriter = new StreamWriter(fileStream);
            string jsonStr = JsonConvert.SerializeObject(personList);
            streamWriter.WriteLine(jsonStr);
            streamWriter.Flush();
            fileStream.Close();
        }
        public Person JsonRead(IConfiguration config)
        {
            string FilePath = MyConfiguration.GetData(config, "FilePath");
            FileStream fileStream = File.Open(FilePath, FileMode.OpenOrCreate);
            StreamReader streamReader = new StreamReader(fileStream);
            Person person = JsonConvert.DeserializeObject<Person>(streamReader.ReadToEnd());
            fileStream.Close();
            return person;
        }
        public List<IPerson> JsonReadList(IConfiguration config)
        {
            string FilePath = MyConfiguration.GetData(config, "FilePath");
            FileStream fileStream = File.Open(FilePath, FileMode.OpenOrCreate);
            StreamReader reader = new StreamReader(fileStream);
            List<IPerson> people = JsonConvert.DeserializeObject<List<IPerson>>(reader.ReadToEnd());
            fileStream.Close();
            return people;
        }
    }
}
