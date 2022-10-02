using InterfaceIntro;
using InterfaceIntro.Interfaces;
using InterfaceIntro.Shapes;
using System;
using System.Collections.Generic;
using System.Text;

namespace NewShapes
{
    class Triangle : Shape, IPrintTable, IGetNewShape
    {
        public (int, int) StartIndex { get; set; }
        public int Length { get; set; }
        public Triangle()
        {

        }
        public Triangle(int length, char symble, (int, int) startIndex)
        {
            Symble = symble;
            StartIndex = startIndex;
            Length = length;
        }
        public int PrintAndReturnMaxHeight(Printer printer)
        {
            var (left, top) = StartIndex;
            printer.SetCursorTop(top);
            try
            {
                for (int i = 1; i <= Length; i++)
                {
                    printer.SetCursorLeft(left);
                    for (int j = 1; j <= Length - i; j++)
                    {
                        printer.WriteStr(" ");
                    }
                    for (int k = 1; k <= i; k++)
                    {
                        printer.WriteChar(Symble);
                    }
                    for (int l = i - 1; l >= 1; l--)
                    {
                        printer.WriteChar(Symble);
                    }
                    printer.WriteStr("\n");
                }
            }
            catch
            {
                //
            }
            return Length * 2;
        }
        public IPrintTable GetNewShape(Printer printer)
        {
            int length;
            char symble;
            (int, int) startIndex;

            Console.WriteLine("Enter length");
            length = GetShapeValues.GetPositiveIntNum(printer);

            Console.WriteLine("Enter symble");
            symble = GetShapeValues.GetSymble(printer);

            Console.WriteLine("Enter startIndexes");
            startIndex = GetShapeValues.GetCenterOrStartPosition(printer);
            return new Triangle(length, symble, startIndex);
        }
    }
}
