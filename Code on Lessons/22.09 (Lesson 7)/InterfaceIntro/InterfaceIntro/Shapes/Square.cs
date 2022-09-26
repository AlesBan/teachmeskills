using System;
using System.Collections.Generic;
using System.Text;

namespace InterfaceIntro.Shapes
{
    class Square : Shape
    {
        public Square(int length, char symble, (int, int) startIndex) : base(length, symble, startIndex)
        {
            Symble = symble;
            StartIndex = startIndex;
            Length = length;
        }
        public override void Print()
        {
            var (left, top) = StartIndex;
            Console.CursorTop = top;
            for (int i = 0; i < Length; i++)
            {
                Console.CursorLeft = left;
                for (int j = 0; j < Length; j++)
                {
                    Console.Write(Symble + " ");
                }
                Console.Write("\n");
            }
        }
    }
}
