using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WebAPI_25_10
{
    public class ComplexSetting
    {
        public const string ConfigPath = "ComplexSettings";
        public string Inner { get; set; }
        public InnerComplexSettings InnerComplex { get; set; }


    }
    public class InnerComplexSettings
    {
        public string Inner { get; set; }
        public string InnerSecond { get; set; }
    }
    
}
