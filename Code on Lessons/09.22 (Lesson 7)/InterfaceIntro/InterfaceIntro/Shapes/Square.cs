using InterfaceIntro.Interfaces;
using System;
using System.Collections.Generic;
using System.Text;

namespace InterfaceIntro.Shapes
{
    [ShapeColor("Green")]
    class Square : Shape,IPrintTable, IGetNewShape
    {
        public (int, int) StartIndex { get; set; }
        public int Length { get; set; }
        public Square()
        {

        }
        public Square(int length, char symble, (int, int) startIndex)
        {
            Symble = symble;
            StartIndex = startIndex;
            Length = length;
        }
        public int PrintAndReturnMaxHeight(PrinterConsole printer)
        {
            ShapeColorAttribute shapeColor = (ShapeColorAttribute)Attribute.GetCustomAttribute(typeof(Square), typeof(ShapeColorAttribute));
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
            for (int i = 0; i < Length; i++)
            {
                printer.SetCursorLeft(left);
                for (int j = 0; j < Length; j++)
                {
                    printer.WriteStr(Symble + " ");
                }
                printer.WriteStr("\n");
            }
            return printer.CursorTop();
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
            return new Square(length, symble, startIndex);
        }
    }
}
