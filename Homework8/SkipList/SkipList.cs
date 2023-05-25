namespace SkipList;

using System.Collections;
using System.Collections.Generic;
using System.Xml.Linq;

public class SkipList<T>//: IList<T>
{
    private readonly Node Head;
    public int Count { get; private set; }

    public bool IsReadOnly { get; private set; }


    private class Node 
    { 
        public T value { get; set; }

        int index { get; set; }

        int level { get; set; } 

        public Node Next { get; set; }


    } 

    public IEnumerator<T> GetEnumerator()
    {
        Node? current = Head;

        while (current != null)
        {
            yield return current.value;
            current = current.Next;
        }
    }

    //public IEnumerable GetEnumerator() => GetEnumerator();

    public T this[int index]
    {
        get
        {
            return (T)this[index];
        }
        set
        {
            throw new NotSupportedException("In this type of list, insertion by index is not provided!");
        }
    }

    public int IndexOf(T item)
    {
        return 0;
    }

    public void Insert(int index, T item)
    {
        throw new NotSupportedException("In this type of list, insertion by index is not provided!");
    }

    public void RemoveAt(int index)
    {
        return;
    }

    public void Add(T item)
    {

    }

    public void Clear()
    {

    }

    public bool Contains(T item)
    {
        return false;
    }

    public void CopyTo(T[] array, int arrayIndex)
    {

    }

    public bool Remove(T item)
    {
        return false;
    }


}