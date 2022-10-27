using InterfaceIntro.Interfaces;
using System;
using System.Collections.Generic;
using System.Text;

namespace InterfaceIntro.Shapes
{
    [ShapeColor("DarkRed")]
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
        public int PrintAndReturnMaxHeight(PrinterConsole printer)
        {
            ShapeColorAttribute shapeColor = (ShapeColorAttribute)Attribute.GetCustomAttribute(typeof(Circle), typeof(ShapeColorAttribute));
            foreach (var color in Interaction.colors)
            {
                if (color.ToString() == shapeColor.Color)
                {
                    ConsoleColor BorderColor = color;
                    printer.Color(BorderColor);
                }
            }
            var (CenterX, CenterY) = Center;
            int x = -Radius;
            while (x < Radius + 1)
            {
                var y = (int)Math.Floor(Math.Sqrt(Radius * Radius - (x * x)));
                WriteSymleInCurrentPlace(x + CenterX, y + CenterY, printer.WriteChar);
                y = -y;
                WriteSymleInCurrentPlace(x + CenterX, y + CenterY, printer.WriteChar);
                x++;
            }
            return CenterY + 2 * Radius;
        }
        public void WriteSymleInCurrentPlace(int xp, int yp, Action<char> Write)
        {
            try
            {
                Console.SetCursorPosition(xp, yp);
                Write(Symble);
            }
            catch
            {
                //
            }
        }
        public IPrintTable GetNewShape(PrinterConsole printer)
        {
            int radius;
            char symble;
            (int, int) center;

            printer.WriteLine("Enter radius");
            radius = GetShapeValues.GetPositiveIntNum(printer);

            printer.WriteLine("Enter symble");
            symble = GetShapeValues.GetSymble(printer);

            printer.WriteLine("Enter center");
            center = GetShapeValues.GetCenterOrStartPosition(printer);
            return new Circle(radius, symble, center);
        }
    }
}
