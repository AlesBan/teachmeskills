
using System;
using System.Collections.Generic;
using System.Text;

namespace InterfaceIntro.Shapes
{
    class Rectangle : IPrintTable
    {
        public char Symble { get; set; }
        public (int, int) StartIndex { get; set; }
        public int Length { get; set; }
        public int Height { get; set; }
        public Rectangle(int length, int height, char symble, (int, int) startIndex) 
        {
            Symble = symble;
            StartIndex = startIndex;
            Length = length;
            Height = height;
        }
        public int PrintAndReturnMaxHeight()
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
            return Console.CursorTop;
        }
    }
}
