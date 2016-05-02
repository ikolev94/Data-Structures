using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;

public class HashTable<TKey, TValue> : IEnumerable<KeyValue<TKey, TValue>>
{
    private LinkedList<KeyValue<TKey, TValue>>[] slots;

    public int Count { get; private set; }
    public const float LoadFactor = 0.75f;

    public int Capacity
    {
        get
        {
            return this.slots.Length;
        }
    }

    public HashTable(int capacity = 16)
    {
        this.slots = new LinkedList<KeyValue<TKey, TValue>>[capacity];
        this.Count = 0;
    }

    public void Add(TKey key, TValue value)
    {
        if ((float)(this.Count + 1) / this.Capacity > LoadFactor)
        {
            this.Grow();
        }

        int slotNumber = this.GetSlotNumber(key);
        if (this.slots[slotNumber] == null)
        {
            this.slots[slotNumber] = new LinkedList<KeyValue<TKey, TValue>>();
        }
        foreach (var item in this.slots[slotNumber])
        {
            if (item.Key.Equals(key))
            {
                throw new ArgumentException("Key already exists: " + key);
            }
        }
        var newElement = new KeyValue<TKey, TValue>(key, value);
        this.slots[slotNumber].AddLast(newElement);
        this.Count++;
    }

    private void Grow()
    {
        var newTable = new HashTable<TKey, TValue>(2 * this.Capacity);
        foreach (var item in this)
        {
            newTable.Add(item.Key, item.Value);
        }
        this.slots = newTable.slots;
        this.Count = newTable.Count;
    }

    private int GetSlotNumber(TKey key)
    {
        return Math.Abs(key.GetHashCode()) % this.slots.Length;
    }

    public bool AddOrReplace(TKey key, TValue value)
    {
        if ((float)(this.Count + 1) / this.Capacity > LoadFactor)
        {
            this.Grow();
        }

        int slotNumber = this.GetSlotNumber(key);
        if (this.slots[slotNumber] == null)
        {
            this.slots[slotNumber] = new LinkedList<KeyValue<TKey, TValue>>();
        }
        foreach (var item in this.slots[slotNumber])
        {
            if (item.Key.Equals(key))
            {
                item.Value = value;
                return false;
            }
        }
        var newElement = new KeyValue<TKey, TValue>(key, value);
        this.slots[slotNumber].AddLast(newElement);
        this.Count++;
        return true;
    }

    public TValue Get(TKey key)
    {
        var element = this.Find(key);
        if (element == null)
        {
            throw new KeyNotFoundException("Invalid key!");
        }
        return element.Value;
    }

    public TValue this[TKey key]
    {
        get
        {
            return this.Get(key);
        }
        set
        {
            this.AddOrReplace(key, value);
        }
    }

    public bool TryGetValue(TKey key, out TValue value)
    {
        var el = this.Find(key);
        if (el != null)
        {
            value = el.Value;
            return true;
        }
        value = default(TValue);
        return false;
    }

    public KeyValue<TKey, TValue> Find(TKey key)
    {
        int slotNumber = this.GetSlotNumber(key);
        var elements = this.slots[slotNumber];
        if (elements != null)
        {
            foreach (var item in elements)
            {
                if (item.Key.Equals(key))
                {
                    return item;
                }
            }
        }
        return null;
    }

    public bool ContainsKey(TKey key)
    {
        return this.Find(key) != null;
    }

    public bool Remove(TKey key)
    {
        int slotNumber = this.GetSlotNumber(key);
        var elements = this.slots[slotNumber];
        if (elements != null)
        {
            var current = elements.First;
            while (current != null)
            {
                if (current.Value.Key.Equals(key))
                {
                    elements.Remove(current);
                    this.Count--;
                    return true;
                }
                current = current.Next;
            }
        }


        return false;
    }

    public void Clear()
    {
        this.slots = new LinkedList<KeyValue<TKey, TValue>>[16];
        this.Count = 0;
    }

    public IEnumerable<TKey> Keys
    {
        get
        {
            return this.Select(e => e.Key);
        }
    }

    public IEnumerable<TValue> Values
    {
        get
        {
            return this.Select(e => e.Value);
        }
    }

    public IEnumerator<KeyValue<TKey, TValue>> GetEnumerator()
    {
        foreach (var elements in this.slots)
        {
            if (elements != null)
            {
                foreach (var element in elements)
                {
                    yield return element;
                }
            }
        }
    }

    IEnumerator IEnumerable.GetEnumerator()
    {
        return this.GetEnumerator();
    }
}
