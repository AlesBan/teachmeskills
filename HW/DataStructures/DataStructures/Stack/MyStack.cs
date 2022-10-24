using Stack.Interfaces;
using System;
using System.Collections.Generic;
using System.Text;

namespace Stack
{
    class MyStack<T> : IStack<T>
    {
        public List<T> List { get; set; }
        public MyStack()
        {
            List = new List<T>();
        }

        public T Pop()
        {
            T item = List[^1];
            List = List.GetRange(0, List.Count - 1);
            return item;
        }

        public void Push(T item)
        {
            List.Add(item);
        }

        public void Print()
        {
            Console.WriteLine("My stack:\n");
            int index = 1;
            foreach (T item in List)
            {
                Console.WriteLine($"{index}) {item}");
                index++;
            }
        }

        public void Clean()
        {
            List.Clear();
        }
    }
}
