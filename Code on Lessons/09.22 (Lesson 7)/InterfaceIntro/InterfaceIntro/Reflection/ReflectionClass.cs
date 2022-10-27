using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Text;

namespace InterfaceIntro.Shapes
{
    static class ReflectionClass
    {
        public static readonly List<Type> ShapeClasses = new List<Type>();
        public static List<Type> GetClasses(Action<string> WriteLine)
        {
            var files = Directory.GetFiles(Directory.GetCurrentDirectory(), "*dll");
            foreach (var file in files)
            {
                try
                {
                    ShapeClasses.AddRange(Assembly.LoadFrom(file).GetTypes().Where(t => t.IsClass && t.GetInterfaces().Any(x => x.Name == "IPrintTable")).ToList());
                }
                catch (Exception e)
                {
                    WriteLine(e.Message);
                }
            }
            return ShapeClasses;
        }
    }
}
