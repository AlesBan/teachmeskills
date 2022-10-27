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
            T item = List[0];
            List = List.GetRange(1, List.Count - 1);
            return item;
        }

        public void Push(T item)
        {
            List<T> newlist = new List<T>()
            {
                item
            };
            newlist.AddRange(List);
            List = newlist;
        }

        public void Print()
        {
            Console.WriteLine("\nMy stack:\n");
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
