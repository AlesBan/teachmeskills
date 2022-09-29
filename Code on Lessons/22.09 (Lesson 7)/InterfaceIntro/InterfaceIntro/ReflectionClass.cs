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
        public static IEnumerable<Type> GetClasses()
        {
            Type[] types;
            IEnumerable<Type> ShapeClasses = new List<Type>();
            var files = Directory.GetFiles(Directory.GetCurrentDirectory());
            
            //var files = Directory.GetFiles(Directory.GetCurrentDirectory(), "*.dll");
            foreach (var file in files)
            {
                try
                {
                    types = Assembly.LoadFrom(file).GetTypes();
                }
                catch
                {
                    continue;
                }
                ShapeClasses = types.Where(t => t.IsClass && t.GetInterfaces().Contains(typeof(IPrintTable)));
            }
            return ShapeClasses;
        }
    }
}
