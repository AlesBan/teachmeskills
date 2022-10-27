using Stack.Helpers;
using System;

namespace Stack
{
    internal class Program
    {
        protected Program()
        {

        }
        static void Main(string[] args)
        {
            Start();
        }
        public static void Start()
        {
            MyStack<string> myStrStack = new MyStack<string>();

            Console.WriteLine("Pushing stack");
            for (int i = 0; i < 5; i++)
            {
                myStrStack.Push(Constans.strs[i]);
            }
            myStrStack.Print();

            Console.WriteLine("\nPoping item: " + myStrStack.Pop());
            myStrStack.Print();

            Console.WriteLine("\nPushing stack");
            for (int i = 4; i < Constans.strs.Length - 1; i++)
            {
                myStrStack.Push(Constans.strs[i]);
            }
            myStrStack.Print();

            Console.WriteLine("\nPoping item: " + myStrStack.Pop());
            myStrStack.Print();

            Console.WriteLine("\nClear stack:");
            myStrStack.Clean();
        }
    }
}
