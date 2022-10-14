using System;
using System.Collections.Generic;
using System.Text;
using TableDataTypes.Person;

namespace TableDataTypes.Helpers
{
    static class Constants
    {
        public static readonly Type[] DataTypes = new Type[] { typeof(string), typeof(bool), typeof(int),typeof(Address) };
        public const string OutPut = "OutPut";
    }
}
