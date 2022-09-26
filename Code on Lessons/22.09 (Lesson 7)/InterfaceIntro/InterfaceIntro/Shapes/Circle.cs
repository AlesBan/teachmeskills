using System;
using System.Collections.Generic;
using System.Text;

namespace InterfaceIntro.Shapes
{
    class Circle : Shape
    {
        public Circle(int length,char symble, (int, int) startIndex) : base(length, symble, startIndex)
        {
            Symble = symble;
            StartIndex = startIndex;
            Length = length;
        }
        public override void Print()
        {
            var (left, top) = StartIndex;
            int indent = Length / 2 - 1; 
            Console.CursorTop = top;
            for (int i = 0; i < Length; i++)
            {
                if (i == 0 || i == Length - 1)
                {
                    Console.CursorLeft = left + Length / 2;
                    Console.Write(Symble);
                }
                else if(i < Length / 2)
                {
                    Console.CursorLeft = left + indent;
                    Console.Write(Symble);
                    Console.CursorLeft = left + indent + 2*i;
                    Console.Write(Symble);
                    indent--;
                }
                else
                {
                    Console.CursorLeft = left - indent;
                    Console.Write(Symble);
                    indent += 2;
                    Console.CursorLeft = left - indent;
                    Console.Write(Symble);
                    indent++;
                }
                

                Console.Write("\n");
            }
        }
    }
}
