using System;
using System.Collections.Generic;
using System.Text;

namespace Calculator
{
    class Expression
    {
        public string expression_str = string.Empty;
        public double result = default;
    }
    class Operation
    {
        public int priopity = default;
        public int numOfEntries = default;
        public string operation_str = string.Empty;
        public List<string> childrenStr;
        public int placeIndex_inEntered = default;
        public int placeIndex_inEnteredSB = default;
        public int length = default;
    }
    class Number
    {
        public double num = default;
        public int placeIndex = default;
    }
}
