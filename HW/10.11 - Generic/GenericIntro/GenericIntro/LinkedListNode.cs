using System;
using System.Collections.Generic;
using System.Text;

namespace GenericIntro
{
    internal class LinkedListNode<T> : IComparable<LinkedListNode<T>>
    {
        public T Data { get; set; }
        public LinkedListNode<T> Next { get; set; }

        public LinkedListNode(T x)
        {
            Data = x;
            Next = null;
        }

        public int CompareTo(LinkedListNode<T> other)
        {
            return Data.ToString().CompareTo(other?.Data.ToString());
        }
    }
}
