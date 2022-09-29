using System;
using System.Collections.Generic;
using System.Text;

namespace InterfaceIntro.Shapes
{
    class Circle : IPrintTable
    {
        public char Symble { get; set; }
        public (int, int) Center { get; set; }
        public int Radius { get; set; }
        public Circle(int radius, char symble, (int, int) center)
        {
            Symble = symble;
            Center = center;
            Radius = radius;
        }
        public int PrintAndReturnMaxHeight()
        {
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
    }
}
