using System;

public class CircularQueue<T>
{
    private const int DEFAULT_CAPACITY = 16;
    private int head;
    private int tail;
    private T[] elements;

    public int Count { get; private set; }

    public CircularQueue(int capacity = DEFAULT_CAPACITY)
    {
        this.elements = new T[capacity];
    }

    public void Enqueue(T element)
    {
        if (this.Count >= this.elements.Length)
        {
            this.Grow();
        }
        this.elements[this.tail] = element;
        this.tail = (this.tail + 1) % this.elements.Length;
        this.Count++;
    }

    public T Dequeue()
    {
        if (this.Count == 0)
        {
            throw new InvalidOperationException("Queue is empty");
        }
        var result = this.elements[this.head];
        this.head = (this.head + 1) % this.elements.Length;
        this.Count--;
        return result;

    }

    public T[] ToArray()
    {
        T[] result = new T[this.Count];
        this.CopyElements(result);
        return result;
    }

    private void Grow()
    {
        T[] result = new T[2 * this.elements.Length];
        this.CopyElements(result);
        this.elements = result;
        this.head = 0;
        this.tail = this.Count;
    }

    private void CopyElements(T[] arr)
    {
        int index = this.head;
        for (int i = 0; i < this.Count; i++)
        {
            arr[i] = this.elements[index];
            index = (index + 1) % this.elements.Length;
        }
    }
}


class Example
{
    static void Main()
    {
        var queue = new CircularQueue<int>();

        queue.Enqueue(1);
        queue.Enqueue(2);
        queue.Enqueue(3);
        queue.Enqueue(4);
        queue.Enqueue(5);
        queue.Enqueue(6);

        Console.WriteLine("Count = {0}", queue.Count);
        Console.WriteLine(string.Join(", ", queue.ToArray()));
        Console.WriteLine("---------------------------");

        var first = queue.Dequeue();
        Console.WriteLine("First = {0}", first);
        Console.WriteLine("Count = {0}", queue.Count);
        Console.WriteLine(string.Join(", ", queue.ToArray()));
        Console.WriteLine("---------------------------");

        queue.Enqueue(-7);
        queue.Enqueue(-8);
        queue.Enqueue(-9);
        Console.WriteLine("Count = {0}", queue.Count);
        Console.WriteLine(string.Join(", ", queue.ToArray()));
        Console.WriteLine("---------------------------");

        first = queue.Dequeue();
        Console.WriteLine("First = {0}", first);
        Console.WriteLine("Count = {0}", queue.Count);
        Console.WriteLine(string.Join(", ", queue.ToArray()));
        Console.WriteLine("---------------------------");

        queue.Enqueue(-10);
        Console.WriteLine("Count = {0}", queue.Count);
        Console.WriteLine(string.Join(", ", queue.ToArray()));
        Console.WriteLine("---------------------------");

        first = queue.Dequeue();
        Console.WriteLine("First = {0}", first);
        Console.WriteLine("Count = {0}", queue.Count);
        Console.WriteLine(string.Join(", ", queue.ToArray()));
        Console.WriteLine("---------------------------");
    }
}
