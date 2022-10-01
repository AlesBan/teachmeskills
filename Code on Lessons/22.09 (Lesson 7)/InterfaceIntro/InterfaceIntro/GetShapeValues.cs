using InterfaceIntro.Shapes;
using System;
using System.Collections.Generic;
using System.Reflection;
using System.Text;

namespace InterfaceIntro
{
    class GetShapeValues
    {
        protected GetShapeValues()
        {

        }
        public static IPrintTable GetNewShape(string className)
        {
            List<Type> types = ReflectionClass.ShapeClasses;

            foreach (Type type in types)
            {
                if (type.Name == $"{className}")
                {
                    var methods = type.GetMethods();
                    foreach (MethodInfo method in methods)
                    {
                        if (method.ReturnType.Name == "IPrintTable")
                        {
                            return (IPrintTable)method.Invoke(new GetShapeValues(), new object[] { });
                        }
                    }
                }
            }
            return null;
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
            return (x, y);
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
