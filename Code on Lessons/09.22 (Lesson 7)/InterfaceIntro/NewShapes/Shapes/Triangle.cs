using InterfaceIntro;
using InterfaceIntro.Interfaces;
using InterfaceIntro.Shapes;
using System;
using System.Collections.Generic;
using System.Text;

namespace NewShapes
{
    [ShapeColor("Pink")]
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
        public int PrintAndReturnMaxHeight(PrinterConsole printer)
        {
            ShapeColorAttribute shapeColor = (ShapeColorAttribute)Attribute.GetCustomAttribute(typeof(Triangle), typeof(ShapeColorAttribute));
            foreach (var color in Interaction.colors)
            {
                if (color.ToString() == shapeColor.Color)
                {
                    ConsoleColor BorderColor = color;
                    printer.Color(BorderColor);
                }
            }

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
        public IPrintTable GetNewShape(PrinterConsole printer)
        {
            int length;
            char symble;
            (int, int) startIndex;

            printer.WriteLine("Enter length");
            length = GetShapeValues.GetPositiveIntNum(printer);

            printer.WriteLine("Enter symble");
            symble = GetShapeValues.GetSymble(printer);

            printer.WriteLine("Enter startIndexes");
            startIndex = GetShapeValues.GetCenterOrStartPosition(printer);
            return new Triangle(length, symble, startIndex);
        }
    }
}
