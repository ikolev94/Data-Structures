using System;
using System.Collections;
using System.Collections.Generic;

namespace LinkedList
{
    public class LinkedList<T> : IEnumerable<T>
    {
        private class ListNode<T>
        {
            public ListNode(T value)
            {
                this.Value = value;
            }

            public T Value { get; private set; }

            public ListNode<T> NextNode { get; set; }
        }

        private ListNode<T> head;
        private ListNode<T> tail;

        public int Count { get; private set; }

        public void Add(T value)
        {
            var newNode = new ListNode<T>(value);
            if (this.head == null)
            {
                this.head = newNode;
                this.tail = newNode;
            }
            else
            {
                this.tail.NextNode = newNode;
                this.tail = newNode;
            }
            this.Count++;
        }

        public void Remove(int index)
        {
            if (index < 0 || index >= this.Count)
            {
                throw new IndexOutOfRangeException("Ïnvalid Index!");
            }
            if (this.tail == null)
            {
                throw new InvalidOperationException("Empty list");
            }
            if (index == 0)
            {
                this.head = this.head.NextNode;
            }
            else
            {
                var currentNode = this.head;
                for (int i = 1; i < index; i++)
                {
                    currentNode = currentNode.NextNode;
                }
                var prev = currentNode;
                currentNode = currentNode.NextNode;
                var next = currentNode.NextNode;
                if (next == null)
                {
                    this.tail = prev;
                }
                prev.NextNode = next;
            }
            this.Count--;
        }

        public IEnumerator<T> GetEnumerator()
        {
            var currentNode = this.head;
            while (currentNode != null)
            {
                yield return currentNode.Value;
                currentNode = currentNode.NextNode;
            }
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return this.GetEnumerator();
        }

    }
}
