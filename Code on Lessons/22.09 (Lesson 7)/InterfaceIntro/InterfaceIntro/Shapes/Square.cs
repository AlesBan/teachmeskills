using System;
using System.Collections.Generic;
using System.Text;

namespace InterfaceIntro.Shapes
{
    class Square : IPrintTable
    {
        public char Symble { get; set; }
        public (int, int) StartIndex { get; set; }
        public int Length { get; set; }
        public Square(int length, char symble, (int, int) startIndex)
        {
            Symble = symble;
            StartIndex = startIndex;
            Length = length;
        }
        public int PrintAndReturnMaxHeight()
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
            return Console.CursorTop;
        }
        public static Square GetNewSquare()
        {
            int length;
            char symble;
            (int, int) startIndex;

            Console.WriteLine("Enter length");
            length = GetShapeValues.GetPositiveIntNum();

            Console.WriteLine("Enter symble");
            symble = GetShapeValues.GetSymble();

            Console.WriteLine("Enter startIndexes");
            startIndex = GetShapeValues.GetCenterOrStartPosition();
            return new Square(length, symble, startIndex);
        }
    }
}
