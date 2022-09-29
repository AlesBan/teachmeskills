using System;

namespace AttributsIntro
{
    class Program
    {
        static void Main(string[] args)
        {
            var obj = new SomeClass();
            bool atrributExists = false;
            var attributes = obj.GetType().GetCustomAttributes(false);
            foreach (var att in attributes)
            {
                if (att is VersionAttribute versionAttribute)
                {
                    atrributExists = true;
                    Console.WriteLine(versionAttribute.Version);
                }
            }
            Console.WriteLine(atrributExists);
        }
        [Version(1)]
        public class SomeClass 
        {



        }

    }
}
