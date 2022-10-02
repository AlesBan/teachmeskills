using InterfaceIntro.Shapes;
using System;
using System.Collections.Generic;
using System.Reflection;

namespace InterfaceIntro
{
    public class GetShapeValues
    {
        protected GetShapeValues()
        {

        }
        public static IPrintTable GetNewShape(string className, Printer printer)
        {
            foreach (Type type in ReflectionClass.ShapeClasses)
            {
                if (type.Name == $"{className}")
                {
                    foreach (MethodInfo method in type.GetMethods())
                    {
                        if (method.ReturnType.Name == "IPrintTable")
                        {
                            return (IPrintTable)method.Invoke(Activator.CreateInstance(type), new object[] { printer });
                        }
                    }
                }
            }
            return null;
        }

        public static (int, int) GetCenterOrStartPosition(Printer printer)
        {
            int x = 0, y = 0;
            while (x <= 0)
            {
                printer.WriteLine("Enter X Position");
                if (!int.TryParse(printer.ReadLine(), out x) || x <= 0)
                {
                    printer.WriteLine("Input is invalid\nTry again");
                }
            }
            while (y <= 0)
            {
                printer.WriteLine("Enter Y Position");
                if (!int.TryParse(printer.ReadLine(), out y) || y <= 0)
                {
                    printer.WriteLine("Input is invalid\nTry again");
                }
            }
            return (x, y);
        }
        public static char GetSymble(Printer printer)
        {
            string str = printer.ReadLine();
            while (str.Length != 1)
            {
                printer.WriteLine("Input is invalid\nTry again");
                str = printer.ReadLine();
            }
            return str[0];
        }
        public static int GetPositiveIntNum(Printer printer)
        {
            int num = 0;
            while (num <= 0)
            {
                printer.WriteLine("Write positive, greater than zero number");
                if (!int.TryParse(printer.ReadLine(), out num) || num <= 0)
                {
                    printer.WriteLine("Input is invalid\nTry again");
                }
            }
            return num;
        }
    }
}
