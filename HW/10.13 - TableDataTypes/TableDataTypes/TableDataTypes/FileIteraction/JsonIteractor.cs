using TableDataTypes.Helpers;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.IO;
using System.Text;
using TableDataTypes.Person;
using TableDataTypes.FileIteraction;

namespace TableDataTypes.JsonIteraction
{
    static class JsonIteractor
    {
        public static void JsonWrite(Table<string, int, Address> table)
        {
            FileStream fileStream = File.Open(Constants.DefaultPeopleFilePath, FileMode.OpenOrCreate);
            fileStream.SetLength(0);
            StreamWriter writer = new StreamWriter(fileStream);
            string strJson = JsonConvert.SerializeObject(table);
            writer.WriteLine(strJson);
            writer.Flush();
            fileStream.Close();
        }
        public static void JsonWriteLog(Logger logger)
        {
            FileStream fileStream = File.Open(Constants.LoggerFilePath, FileMode.Append);
            StreamWriter writer = new StreamWriter(fileStream);
            string strJson = JsonConvert.SerializeObject(logger);
            fileStream.Seek(fileStream.Length, SeekOrigin.Begin);
            writer.WriteLine(strJson);
            writer.Flush();
            fileStream.Close();
        }
        public static Table<string, int, Address> JsonRead()
        {
            FileStream fileStream = File.Open(Constants.DefaultPeopleFilePath, FileMode.OpenOrCreate);
            StreamReader reader = new StreamReader(fileStream);
            Table<string, int, Address> table = JsonConvert.DeserializeObject<Table<string, int, Address>>(reader.ReadToEnd());
            fileStream.Close();
            return table;
        }
        public static Table<string, int, Address> JsonRead(string filePath)
        {
            FileStream fileStream = File.Open(filePath, FileMode.OpenOrCreate);
            StreamReader reader = new StreamReader(fileStream);
            Table<string, int, Address> table = JsonConvert.DeserializeObject<Table<string, int, Address>>(reader.ReadToEnd());
            fileStream.Close();
            return table;
        }
    }
}
