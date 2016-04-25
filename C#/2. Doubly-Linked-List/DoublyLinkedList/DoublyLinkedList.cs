using Double_Linked_List;
using System;
using System.Collections;
using System.Collections.Generic;

public class DoublyLinkedList<T> : IEnumerable<T>
{
    private const string EMPTY_LIST_ERROR_MESSAGE = "List is empty";
    private ListNode<T> head;
    private ListNode<T> tail;

    public int Count { get; private set; }

    public void AddFirst(T element)
    {
        ListNode<T> newHead = new ListNode<T>(element);

        if (this.head == null)
        {
            this.head = newHead;
            this.tail = newHead;
        }
        else
        {
            newHead.NextNode = this.head;
            this.head.PrevNode = newHead;
            this.head = newHead;
        }
        this.Count++;
    }

    public void AddLast(T element)
    {
        ListNode<T> newTail = new ListNode<T>(element);

        if (this.tail == null)
        {
            this.head = newTail;
            this.tail = newTail;
        }
        else
        {
            newTail.PrevNode = this.tail;
            this.tail.NextNode = newTail;
            this.tail = newTail;
        }
        this.Count++;
    }

    public T RemoveFirst()
    {
        if (this.head == null)
        {
            throw new InvalidOperationException(EMPTY_LIST_ERROR_MESSAGE);
        }
        var firstElement = this.head.Value;
        this.head = this.head.NextNode;
        if (this.head == null)
        {
            this.tail = null;
        }
        else
        {
            this.head.PrevNode = null;
        }
        this.Count--;
        return firstElement;
    }

    public T RemoveLast()
    {
        if (this.tail == null)
        {
            throw new InvalidOperationException(EMPTY_LIST_ERROR_MESSAGE);
        }
        var lastElement = this.tail.Value;
        this.tail = this.tail.PrevNode;
        if (this.tail == null)
        {
            this.head = null;
        }
        else
        {
            this.tail.NextNode = null;
        }
        this.Count--;
        return lastElement;
    }

    public void ForEach(Action<T> action)
    {
        var currentNode = this.head;
        while (currentNode != null)
        {
            action(currentNode.Value);
            currentNode = currentNode.NextNode;
        }
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

    public T[] ToArray()
    {
        T[] result = new T[this.Count];
        var index = 0;
        var currentNode = this.head;
        while (currentNode != null)
        {
            result[index] = currentNode.Value;
            index++;
            currentNode = currentNode.NextNode;
        }

        return result;
    }
}


class Example
{
    static void Main()
    {
        var list = new DoublyLinkedList<int>();

        list.ForEach(Console.WriteLine);
        Console.WriteLine("--------------------");

        list.AddLast(5);
        list.AddFirst(3);
        list.AddFirst(2);
        list.AddLast(10);
        Console.WriteLine("Count = {0}", list.Count);

        list.ForEach(Console.WriteLine);
        Console.WriteLine("--------------------");

        list.RemoveFirst();
        list.RemoveLast();
        list.RemoveFirst();

        list.ForEach(Console.WriteLine);
        Console.WriteLine("--------------------");

        list.RemoveLast();

        list.ForEach(Console.WriteLine);
        Console.WriteLine("--------------------");
    }
}
