using System;
using System.Collections.Generic;
using System.Text;

namespace TableDataTypes
{
    public class Line<T, U, V>
    {
        public T TTypeVar { get; set; }
        public U UTypeVar { get; set; }
        public V VTypeVar { get; set; }
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
        public void PrintLine()
        {
            Console.Write(TTypeVar);
            Console.CursorLeft = LongestColumnLenght.LongestLenghtTColumn + 2;
            Console.Write(UTypeVar);
            Console.CursorLeft = LongestColumnLenght.LongestLenghtTColumn + LongestColumnLenght.LongestLenghtUColumn + 4;
            Console.Write(VTypeVar + "\n");
        }
    }
}
