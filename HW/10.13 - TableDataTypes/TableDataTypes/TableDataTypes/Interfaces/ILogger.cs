using System;
using System.Collections.Generic;
using System.Text;

namespace TableDataTypes.Interfaces
{
    interface ILogger
    {
        public DateTime Date { get; set; }
        public string ActionName { get; set; }
        void Log();
    }
}
