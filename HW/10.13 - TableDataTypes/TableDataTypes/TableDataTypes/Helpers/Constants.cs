using System;
using System.Collections.Generic;
using System.Text;
using TableDataTypes.Person;

namespace TableDataTypes.Helpers
{
    static class Constants
    {
        public const string LoggerFilePath = "Logger.txt";
        public const string DefaultPeopleFilePath = "People.txt";
        public static readonly Type[] DataTypes = new Type[] { typeof(string), typeof(bool), typeof(int), typeof(Address) };
        public const string OutPut = "OutPut";
        public static readonly string[] AvaliableOptions = new string[] 
        { 
            "Add line", "OutPut", "Set pagination", "Exit", "Next page", "Previous page", "Go to", "Read new file", "Delete item"
        };
        public static readonly List<Line<string, int, Address>> DefaultLines = new List<Line<string, int, Address>>
        {
            new Line<string, int, Address>("1111", 5, new Address("sadsf", "eqresrdg", "fadsgfnc")),
            new Line<string, int, Address>("2222", 7, new Address("fdvcx ", "grbsrgb", "jhgfe")),
            new Line<string, int, Address>("3333", 34, new Address("dfbgxf ", "eavrs", "fv")),
            new Line<string, int, Address>("4444", 12, new Address("mthnfgb", "aebsb", "bvc")),
            new Line<string, int, Address>("55555", 32, new Address("umtnhf", "urmndghgb", "mnbv")),
            new Line<string, int, Address>("66666", 42, new Address("beadf", "btrb", "mnbvcefe")),
            new Line<string, int, Address>("777", 5, new Address("sadsf", "eqresrdg", "fadsgfnc")),
            new Line<string, int, Address>("8888", 7, new Address("fdvcx ", "grbsrgb", "jhgfe")),
            new Line<string, int, Address>("9999", 34, new Address("dfbgxf ", "eavrs", "fv")),
            new Line<string, int, Address>("100000", 12, new Address("mthnfgb", "aebsb", "bvc")),
            new Line<string, int, Address>("111111", 32, new Address("umtnhf", "urmndghgb", "mnbv")),
        };
    }
}
