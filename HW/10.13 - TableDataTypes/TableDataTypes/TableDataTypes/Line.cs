using System;
using System.Collections.Generic;
using System.Text;

namespace TableDataTypes
{
    class Line<T, U, V>
    {
        public T TTypeVar { get; set; }
        public U UTypeVar { get; set; }
        public V VTypeVar { get; set; }
        public int Index { get; set; }
        public Line(T tTypeVar, U uTypeVar, V vTypeVar)
        {
            TTypeVar = tTypeVar;
            UTypeVar = uTypeVar;
            VTypeVar = vTypeVar;
        }
        public override string ToString()
        {
            return $"{TTypeVar} {UTypeVar} {VTypeVar}";
        }
        public void PrintLine(int Count)
        {
            int indentation = 2;
            int countLength = Count.ToString().Length;
            Console.Write($"{Index})");
            Console.CursorLeft = countLength + indentation;
            Console.Write(TTypeVar);
            Console.CursorLeft = LongestColumnLenght.LongestLenghtTColumn + countLength + indentation * 2;
            Console.Write(UTypeVar);
            Console.CursorLeft = LongestColumnLenght.LongestLenghtTColumn + LongestColumnLenght.LongestLenghtUColumn + countLength + indentation * 3;
            Console.Write(VTypeVar + "\n");
        }
    }
}
