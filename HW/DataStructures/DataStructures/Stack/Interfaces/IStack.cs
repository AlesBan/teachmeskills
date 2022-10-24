using System;
using System.Collections.Generic;
using System.Text;

namespace Stack.Interfaces
{
    interface IStack<T>
    {
        public List<T> List { get; set; }
        void Push(T item);
        T Pop();
        void Clean();
        void Print();
    }
}
