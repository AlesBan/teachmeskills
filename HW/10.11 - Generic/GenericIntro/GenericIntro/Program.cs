using System;
using System.Collections.Generic;

namespace GenericIntro
{
    class Program
    {
        static void Main(string[] args)
        {
            LinkedList<string> linkedList = new LinkedList<string>();
            linkedList.AddNode("11111");
            linkedList.AddNode("2222");
            linkedList.AddNode("333333");
            linkedList.AddNode("4444");
            linkedList.AddNode("555555");
            linkedList.AddNode("666666");
            linkedList.PrintList();
            Console.WriteLine("\n\n");
            linkedList.DeleteNode(6);
            linkedList.PrintList();
            Console.WriteLine("\n\n");
            Console.WriteLine(linkedList.ToString());
            Console.WriteLine("\n\n");
            linkedList.Reverse();
            Console.WriteLine(linkedList.ToString());
            linkedList.Sort();
            Console.WriteLine(linkedList.ToString());
        }
    }
}
