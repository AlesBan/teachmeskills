using System;
using System.Collections.Generic;
using System.Text;
using TableDataTypes.Person;

namespace TableDataTypes.Helpers
{
    static class Constants
    {
        public static readonly Type[] DataTypes = new Type[] { typeof(string), typeof(bool), typeof(int), typeof(Address) };
        public const string OutPut = "OutPut";
        public static readonly List<Line<string, int, Address>> DefaultLines = new List<Line<string, int, Address>>
        {
            new Line<string, int, Address>("fdsargstr", 5, new Address("sadsf", "eqresrdg", "fadsgfnc")),
            new Line<string, int, Address>("egtrhyt", 7, new Address("fdvcx ", "grbsrgb", "jhgfe")),
            new Line<string, int, Address>("yujtnhdbgf", 34, new Address("dfbgxf ", "eavrs", "fv")),
            new Line<string, int, Address>("vfdxgb", 12, new Address("mthnfgb", "aebsb", "bvc")),
            new Line<string, int, Address>("erghtrj5e", 32, new Address("umtnhf", "urmndghgb", "mnbv")),
            new Line<string, int, Address>("ynbnrth", 42, new Address("beadf", "btrb", "mnbvcefe")),
        };
    }
}
