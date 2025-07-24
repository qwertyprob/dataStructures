using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataStructures;

class DynamicArray<T> : IEnumerable<T>
{
    private int count = 0;
    private T[] array;
    public int Count { get { return count; } }
    public T this[int index] 
    {
        get => index >= 0 &&
               index < count ? array[index] :
        throw new IndexOutOfRangeException("Index out of range");
        set
        {
            if (index < 0 || index >= count)
            {
                throw new IndexOutOfRangeException("Index out of range");
            }
            array[index] = value;
        }
    }
    public DynamicArray(int initialSize = 4)
    {
        array = new T[initialSize];
    }
    public void Add(T item)
    {
        if (count >= array.Length)
        {
            this.Resize();
        }
        array[count] = item;
        this.count++;
    }
    private void Resize()
    {
        T[] newArray = new T[this.count * 2];
        for (int i = 0; i < count; i++)
        {
            newArray[i] = array[i];
        }
        array = newArray;
    }
    public void RemoveAt(int index)
    {
        if(index < 0 || index >= count)
        {
            throw new IndexOutOfRangeException("Index out of range");
        }

        for (int i = index; i < count - 1; i++)
        {
            array[i] = array[i + 1];
        }

        count--;
    }
    public void RemoveAtBySwap(int index)
    {
        if (index < 0 || index >= count)
        {
            throw new IndexOutOfRangeException("Index out of range");
        }

        array[index] = array[count - 1];

        count--;
    }
    public void Insert(int index, T value)
    {
        if(index < 0 || index > count)
        {
            throw new IndexOutOfRangeException("Index out of range");
        }

        this.Add(value);

        for(int i = count - 1; i > index; i--)
        {
            array[i] = array[i - 1];    

        }

        array[index] = value;


    }
    public void Clear()
    {
        for (int i = 0; i < count; i++)
        {
            array[i] = default(T); // Delete refs
        }

        count = 0;
    }
    public override string ToString()
    {

        return "[ " + string.Join(", ", array) + " ]";



    }
    //Iterator for LINQ or foreach
    public IEnumerator<T> GetEnumerator()
    {
    for (int i = 0; i < Count; i++)
    {
        yield return array[i];
    }
    }
    System.Collections.IEnumerator System.Collections.IEnumerable.GetEnumerator()
    {
        return GetEnumerator();
    }


}


