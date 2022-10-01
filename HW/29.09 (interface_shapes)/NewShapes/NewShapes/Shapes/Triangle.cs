using NewShapes.Interfaces;
using System;
using System.Collections.Generic;
using System.Text;

namespace NewShapes
{
    class Triangle : IPrintTable, IGetNewShape
    {
        public char Symble { get; set; }
        public (int, int) StartIndex { get; set; }
        public int Length { get; set; }
        public Triangle(int length, char symble, (int, int) startIndex)
        {
            Symble = symble;
            StartIndex = startIndex;
            Length = length;
        }
        public int PrintAndReturnMaxHeight()
        {
            var (left, top) = StartIndex;
            Console.CursorTop = top;
            try
            {
                for (int i = 1; i <= Length; i++)
                {
                    Console.CursorLeft = left;
                    for (int j = 1; j <= Length - i; j++)
                    {
                        Console.Write(" ");
                    }
                    for (int k = 1; k <= i; k++)
                    {
                        Console.Write(Symble);
                    }
                    for (int l = i - 1; l >= 1; l--)
                    {
                        Console.Write(Symble);
                    }
                    Console.Write("\n");
                }
            }
            catch
            {

            }
            return Console.CursorTop;
        }
        public IPrintTable GetNewShape()
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
            return new Triangle(length, symble, startIndex);
        }
    }
}
