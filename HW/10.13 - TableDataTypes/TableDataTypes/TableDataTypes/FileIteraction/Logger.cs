using System;
using System.Collections.Generic;
using System.Text;
using TableDataTypes.Interfaces;
using TableDataTypes.JsonIteraction;

namespace TableDataTypes.FileIteraction
{
    class Logger : ILogger
    {
        public DateTime Date { get; set; }
        public string ActionName { get; set; }
        public Logger(string actionName)
        {
            Date = DateTime.Now;
            ActionName = actionName;
        }
        public void Log()
        {
            JsonIteractor.JsonWriteLog(new Logger(ActionName));
        }
        public override string ToString()
        {
            return $"{Date} --- {ActionName}";
        }
    }
}
