using System;
using System.Collections.Generic;
using System.Text;

namespace Queue.Interfaces
{
    interface IQueue<T>
    {
        void Enque();
        void Deque();
        void Print();
    }
}
