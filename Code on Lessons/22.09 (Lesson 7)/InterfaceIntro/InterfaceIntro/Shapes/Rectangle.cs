
using InterfaceIntro.Interfaces;
using System;
using System.Collections.Generic;
using System.Text;

namespace InterfaceIntro.Shapes
{
    [ShapeColor("Yellow")]
    class Rectangle : Shape, IPrintTable, IGetNewShape
    {
        public (int, int) StartIndex { get; set; }
        public int Length { get; set; }
        public int Height { get; set; }
        public Rectangle()
        {

        }
        public Rectangle(int length, int height, char symble, (int, int) startIndex) 
        {
            Symble = symble;
            StartIndex = startIndex;
            Length = length;
            Height = height;
        }
        public int PrintAndReturnMaxHeight(Printer printer)
        {
            ShapeColorAttribute shapeColor = (ShapeColorAttribute)Attribute.GetCustomAttribute(typeof(Rectangle), typeof(ShapeColorAttribute));
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
            for (int i = 0; i < Height; i++)
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
        public IPrintTable GetNewShape(Printer printer)
        {
            int length, height;
            char symble;
            (int, int) startIndex;

            printer.WriteLine("Enter length");
            length = GetShapeValues.GetPositiveIntNum(printer);

            printer.WriteLine("Enter height");
            height = GetShapeValues.GetPositiveIntNum(printer);

            printer.WriteLine("Enter symble");
            symble = GetShapeValues.GetSymble(printer);

            printer.WriteLine("Enter startIndexes");
            startIndex = GetShapeValues.GetCenterOrStartPosition(printer);
            return new Rectangle(length, height, symble, startIndex);
        }
    }
}
