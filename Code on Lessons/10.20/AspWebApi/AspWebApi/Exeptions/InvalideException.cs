using System;
using System.Collections.Generic;
using System.Text;

namespace TableDataTypes.Exeptions
{
    public class InvalideInputException : Exception
    {
        public InvalideInputException() { }
        public InvalideInputException(string message) : base(message) { }
    }
}
