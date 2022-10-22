using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.IO;
using System.Text;
using TableDataTypes.Person;

namespace TableDataTypes.JsonIteraction
{
    static class JsonIteractor
    {
        public static void JsonWrite(Table<string, int, Address> table)
        {
            FileStream stream = File.Open("People.txt", FileMode.OpenOrCreate);
            StreamWriter writer = new StreamWriter(stream);
            string strJson = JsonConvert.SerializeObject(table);
            writer.WriteLine(strJson);
            writer.Flush();
            stream.Close();
        }
        public static Table<string, int, Address> JsonRead()
        {
            FileStream stream = File.Open("People.txt", FileMode.OpenOrCreate);
            StreamReader reader = new StreamReader(stream);
            Table<string, int, Address> table = JsonConvert.DeserializeObject<Table<string, int, Address>>(reader.ReadToEnd());
            stream.Close();
            return table;
        }
    }
}
