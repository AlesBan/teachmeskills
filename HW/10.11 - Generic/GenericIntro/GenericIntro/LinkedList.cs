using System;
using System.Collections.Generic;
using System.Text;

namespace GenericIntro
{
    public class LinkedList<T>
    {
        public int Count { get; set; }
        private LinkedListNode<T> Head { get; set; }
        private LinkedListNode<T> LastItem { get; set; }
        public LinkedList()
        {
            Head = null;
            LastItem = null;
            Count = 0;
        }
        public void DeleteNode(int index)
        {
            LinkedListNode<T> runningNode;
            LinkedListNode<T> previous;
            LinkedListNode<T> corrent;
            if (index == 1)
            {
                runningNode = Head.Next;
                Head = null;
                Head = runningNode;
            }
            else if (index == Count)
            {
                previous = FindNode(Count - 1);
                previous.Next = null;
                LastItem = previous;
            }
            else
            {
                previous = FindNode(index - 1);
                corrent = FindNode(index);
                previous.Next = corrent.Next;
                corrent.Next = null;
            }
            Count--;
        }
        private LinkedListNode<T> FindNode(int index)
        {
            LinkedListNode<T> runningNode = Head;
            for (int i = 1; i != index; i++)
            {
                runningNode = runningNode.Next;
            }
            return runningNode;
        }
        public void AddNode(T data)
        {
            LinkedListNode<T> node = new LinkedListNode<T>(data);
            if (Head != null)
            {
                LastItem.Next = node;
                LastItem = node;
            }
            else
            {
                Head = node;
                LastItem = node;
            }
            Count++;
        }
        public void AddNodeToFront(T data)
        {
            LinkedListNode<T> node = new LinkedListNode<T>(data)
            {
                Next = Head
            };
            Head = node;
            Count++;
        }

        public void PrintList()
        {
            LinkedListNode<T> runner = Head;
            while (runner != null)
            {
                Console.WriteLine(runner.Data);
                runner = runner.Next;
            }
        }
        public void Reverse()
        {
            LinkedListNode<T> newHead = LastItem;
            LinkedListNode<T> previous;
            for (int i = 1; i < Count; i++)
            {
                previous = FindNode(Count - i);
                LastItem.Next = previous;
                LastItem = previous;
            }
            LastItem.Next = null;
            Head = newHead;
        }
        public void Sort()
        {
            LinkedListNode<T>[] temp = new LinkedListNode<T>[Count];
            LinkedListNode<T> runner = Head;
            for (int i = 0; i < Count; i++)
            {
                temp[i] = runner;
                runner = runner.Next;
            }
            Array.Sort(temp);
            Head = temp[0];
            LastItem = temp[0];
            foreach (LinkedListNode<T> node in temp[1..])
            {
                AddNode(node.Data);
            }
        }
        public override string ToString()
        {
            List<string> newArray = new List<string>();
            LinkedListNode<T> runner = Head;
            while (runner != null)
            {
                newArray.Add(runner.Data.ToString());
                runner = runner.Next;
            }
            return string.Join(" ", newArray);
        }
    }
}
