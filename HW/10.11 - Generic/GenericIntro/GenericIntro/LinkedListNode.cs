using System;
using System.Collections.Generic;
using System.Text;

namespace GenericIntro
{
    class LinkedListNode<T>
    {
        public T data;
        public LinkedListNode<T> next;

        public LinkedListNode(T x)
        {
            data = x;
            next = null;
        }
    }
}
