using System;

namespace Stack
{
    public class LinkedStack<T>
    {
        private class Node<T>
        {
            public Node(T value, Node<T> nextNode = null)
            {
                this.Value = value;
                this.NextNode = nextNode;
            }
            public T Value { get; private set; }
            public Node<T> NextNode { get; set; }
        }

        private Node<T> top;

        public int Count { get; private set; }

        public void Push(T element)
        {
            if (this.Count == 0)
            {
                this.top = new Node<T>(element);
            }
            else
            {
                var newNode = new Node<T>(element, this.top);
                this.top = newNode;
            }
            this.Count++;
        }

        public T Pop()
        {
            if (this.Count == 0)
            {
                throw new InvalidOperationException("Stack is empty");
            }
            var result = this.top.Value;
            this.top = this.top.NextNode;
            this.Count--;
            return result;

        }

        public T[] ToArray()
        {
            T[] result = new T[this.Count];
            int index = 0;
            var current = this.top;

            while (current != null)
            {
                result[index++] = current.Value;
                current = current.NextNode;
            }

            return result;
        }
    }
}
