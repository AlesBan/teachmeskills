using InterfaceIntro.Shapes;
using System;
using System.Collections.Generic;
using System.Text;

namespace InterfaceIntro
{
    class GetShapeValues
    {
        protected GetShapeValues()
        {

        }
        public static Rectangle GetNewRectangle()
        {
            int length, height;
            char symble;
            (int, int) startIndex;

            Console.WriteLine("Enter length");
            length = GetPositiveIntNum();

            Console.WriteLine("Enter height");
            height = GetPositiveIntNum();

            Console.WriteLine("Enter symble");
            symble = GetSymble();

            Console.WriteLine("Enter startIndex");
            startIndex = GetCenterOrStartPosition();
            return new Rectangle(length, height, symble, startIndex);
        }
        public static Square GetNewSquare()
        {
            int length;
            char symble;
            (int, int) startIndex;

            Console.WriteLine("Enter length");
            length = GetPositiveIntNum();

            Console.WriteLine("Enter symble");
            symble = GetSymble();

            Console.WriteLine("Enter startIndex");
            startIndex = GetCenterOrStartPosition();
            return new Square(length, symble, startIndex);
        }
        public static Circle GetNewCircle()
        {
            int radius;
            char symble;
            (int, int) center;

            Console.WriteLine("Enter radius");
            radius = GetPositiveIntNum();

            Console.WriteLine("Enter symble");
            symble = GetSymble();

            Console.WriteLine("Enter center");
            center = GetCenterOrStartPosition();
            return new Circle(radius, symble, center);
        }
        public static (int, int) GetCenterOrStartPosition()
        {
            int x = 0, y = 0;
            while (x <= 0)
            {
                Console.WriteLine("Enter X Position");
                if (!int.TryParse(Console.ReadLine(), out x) || x <= 0)
                {
                    Console.WriteLine("Input is invalid\nTry again");
                }
            }
            while (y <= 0)
            {
                Console.WriteLine("Enter Y Position");
                if (!int.TryParse(Console.ReadLine(), out y) || y <= 0)
                {
                    Console.WriteLine("Input is invalid\nTry again");
                }
            }
            return (x + Console.CursorLeft, y + Console.CursorTop);

        }
        public static char GetSymble()
        {
            string str = Console.ReadLine();
            while (str.Length != 1)
            {
                Console.WriteLine("Input is invalid\nTry again");
                str = Console.ReadLine();
            }
            return str[0];
        }
        public static int GetPositiveIntNum()
        {
            int num = 0;
            while (num <= 0)
            {
                Console.WriteLine("Write positive, greater than zero number");
                if (!int.TryParse(Console.ReadLine(), out num) || num <= 0)
                {
                    Console.WriteLine("Input is invalid\nTry again");
                }
            }
            return num;

        }
    }
}
