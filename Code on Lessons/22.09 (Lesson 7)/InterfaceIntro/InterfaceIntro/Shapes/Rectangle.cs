
using System;
using System.Collections.Generic;
using System.Text;

namespace InterfaceIntro.Shapes
{
    class Rectangle : Shape
    {
        public Rectangle(int length, int height, char symble, (int, int) startIndex) : base(length, height, symble, startIndex)
        {
            Symble = symble;
            StartIndex = startIndex;
            Length = length;
            Height = height;
        }
        public override void Print()
        {
            var (left, top) = StartIndex;
            Console.CursorTop = top;
            for (int i = 0; i < Height; i++)
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
