using System;
using System.Collections.Generic;
using System.Text;

namespace GenericIntro
{
    class LinkedList<T>
    {
        public int Count { get; set; }
        public LinkedListNode<T> Head { get; set; }
        public LinkedListNode<T> LastItem { get; set; }
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
                runningNode = Head.next;
                Head = null;
                Head = runningNode;
            }
            else if (index == Count)
            {
                previous = FindNode(Count - 1);
                previous.next = null;
                LastItem = previous;
            }
            else
            {
                previous = FindNode(index - 1);
                corrent = FindNode(index);
                previous.next = corrent.next;
                corrent.next = null;
            }
            Count--;
        }
        public LinkedListNode<T> FindNode(int index)
        {
            LinkedListNode<T> runningNode = Head;
            for (int i = 1; i != index; i++)
            {
                runningNode = runningNode.next;
            }
            return runningNode;
        }
        public void AddNode(T data)
        {
            LinkedListNode<T> node = new LinkedListNode<T>(data);
            if (Head != null)
            {
                LastItem.next = node;
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
                next = Head
            };
            Head = node;
            Count++;
        }
        public void PrintList()
        {
            LinkedListNode<T> runner = Head;
            while (runner != null)
            {
                Console.WriteLine(runner.data);
                runner = runner.next;
            }
        }
        public void Reverse()
        {
            LinkedListNode<T> newHead = LastItem;
            LinkedListNode<T> previous;
            for (int i = 1; i < Count; i++)
            {
                previous = FindNode(Count - i);
                LastItem.next = previous;
                LastItem = previous;
            }
            LastItem.next = null;
            Head = newHead;
        }
        public override string ToString()
        {
            List<string> newArray = new List<string>();
            LinkedListNode<T> runner = Head;
            while (runner != null)
            {
                newArray.Add(runner.data.ToString());
                runner = runner.next;
            }
            return string.Join(" ", newArray);
        }
    }
}
