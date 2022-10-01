
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
        public int PrintAndReturnMaxHeight()
        {
            ShapeColorAttribute shapeColor = (ShapeColorAttribute)Attribute.GetCustomAttribute(typeof(Rectangle), typeof(ShapeColorAttribute));
            foreach (var color in Interaction.colors)
            {
                if (color.ToString() == shapeColor.Color)
                {
                    ConsoleColor BorderColor = color;
                    Console.ForegroundColor = BorderColor;
                }
            }
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
        public IPrintTable GetNewShape()
        {
            int length, height;
            char symble;
            (int, int) startIndex;

            Console.WriteLine("Enter length");
            length = GetShapeValues.GetPositiveIntNum();

            Console.WriteLine("Enter height");
            height = GetShapeValues.GetPositiveIntNum();

            Console.WriteLine("Enter symble");
            symble = GetShapeValues.GetSymble();

            Console.WriteLine("Enter startIndexes");
            startIndex = GetShapeValues.GetCenterOrStartPosition();
            return new Rectangle(length, height, symble, startIndex);
        }
    }
}
