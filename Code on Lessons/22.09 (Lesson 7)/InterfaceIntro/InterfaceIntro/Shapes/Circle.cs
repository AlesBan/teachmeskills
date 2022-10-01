using InterfaceIntro.Interfaces;
using System;
using System.Collections.Generic;
using System.Text;

namespace InterfaceIntro.Shapes
{
    [ShapeColor("Dark Red")]
    class Circle : Shape, IPrintTable, IGetNewShape
    {
        public (int, int) Center { get; set; }
        public int Radius { get; set; }
        public Circle()
        {

        }
        public Circle(int radius, char symble, (int, int) center)
        {
            Symble = symble;
            Center = center;
            Radius = radius;
        }
        public int PrintAndReturnMaxHeight()
        {
            ShapeColorAttribute shapeColor = (ShapeColorAttribute)Attribute.GetCustomAttribute(typeof(Circle), typeof(ShapeColorAttribute));
            foreach (var color in Interaction.colors)
            {
                if (color.ToString() == shapeColor.Color)
                {
                    ConsoleColor BorderColor = color;
                    Console.ForegroundColor = BorderColor;
                }
            }
            var (CenterX, CenterY) = Center;
            int x = -Radius;
            while (x < Radius + 1)
            {
                var y = (int)Math.Floor(Math.Sqrt(Radius * Radius - (x * x)));
                WriteSymleInCurrentPlace(x + CenterX, y + CenterY);
                y = -y;
                WriteSymleInCurrentPlace(x + CenterX, y + CenterY);
                x++;
            }
            return CenterY + 2 * Radius;
        }
        public void WriteSymleInCurrentPlace(int xp, int yp)
        {
            try
            {
                Console.SetCursorPosition(xp, yp);
                Console.Write(Symble);
            }
            catch
            {
                
            }
        }
        public IPrintTable GetNewShape()
        {
            int radius;
            char symble;
            (int, int) center;

            Console.WriteLine("Enter radius");
            radius = GetShapeValues.GetPositiveIntNum();

            Console.WriteLine("Enter symble");
            symble = GetShapeValues.GetSymble();

            Console.WriteLine("Enter center");
            center = GetShapeValues.GetCenterOrStartPosition();
            return new Circle(radius, symble, center);
        }
    }
}
