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

namespace WebAPI_10._25DZ.DIEnv
{
    public class JsonIteractor : IJsonIteractor
    {
        private string _filePath { get; set; }
        public JsonIteractor(IConfiguration config)
        {
            _filePath = MyConfiguration.GetData(config, "FilePath");
        }
        public void JsonWrite(IConfiguration config, Person person)
        {
            FileStream fileStream = File.Open(_filePath, FileMode.OpenOrCreate);
            StreamWriter streamWriter = new StreamWriter(fileStream);
            string jsonStr = JsonConvert.SerializeObject(person);
            streamWriter.WriteLine(jsonStr);
            streamWriter.Flush();
            fileStream.Close();
        }
        public void JsonWriteList(IConfiguration config, List<Person> personList)
        {
            FileStream fileStream = File.Open(_filePath, FileMode.OpenOrCreate);
            fileStream.SetLength(0);
            StreamWriter streamWriter = new StreamWriter(fileStream);
            string jsonStr = JsonConvert.SerializeObject(personList);
            streamWriter.WriteLine(jsonStr);
            streamWriter.Flush();
            fileStream.Close();
        }
        public Person JsonRead(IConfiguration config)
        {
            FileStream fileStream = File.Open(_filePath, FileMode.OpenOrCreate);
            StreamReader streamReader = new StreamReader(fileStream);
            Person person = JsonConvert.DeserializeObject<Person>(streamReader.ReadToEnd());
            fileStream.Close();
            return person;
        }
        public List<Person> JsonReadList(IConfiguration config)
        {
            FileStream fileStream = File.Open(_filePath, FileMode.OpenOrCreate);
            StreamReader reader = new StreamReader(fileStream);
            List<Person> people = JsonConvert.DeserializeObject<List<Person>>(reader.ReadToEnd());
            fileStream.Close();
            return people;
        }
    }
}
