using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

namespace DataStructures;
public class Node<T>
{
    public T? Value { get; set; }
    public Node<T>? NextNode { get; set; }
    public Node(T? value)
    {
        Value = value;
    }
}

public class LinkedList<T> : IEnumerable
{
    private int count = 0;
    public int Count { get => this.count; }
    private Node<T>? head = null;
    public T this[int index]
    {
        get
        {
            if(index < 0 || index>=count)
                throw new IndexOutOfRangeException();

            int i = 0;
            var current = head;
            while(current != null)
            {
                if(i == index)
                {
                    return current.Value;
                }
                current = current.NextNode;
                i++;
            }

            throw new IndexOutOfRangeException();
        }
        set
        {
            if (index < 0 || index >= count)
                throw new IndexOutOfRangeException();

            int i = 0;
            var current = head;
            while (current != null)
            {
                if (i == index)
                {
                    current.Value = value;
                }
                current = current.NextNode;
                i++;
            }
        }
    }
    public void Add(T value)
    {
        var newNode = new Node<T>(value);
        if (head == null)
        {
            head = newNode;
            count++;
            return;

        }

        var currentNode = head;

        while(currentNode.NextNode != null)
        {
            currentNode = currentNode.NextNode;
        }

        currentNode.NextNode = newNode;
        count++;
        
    }
    public Node<T> GetNode(int index)
    {
        if (index < 0 || index >= count)
            throw new IndexOutOfRangeException();
        int i = 0;
        var current = head;

        while (current != null) 
        {
            if (i == index)
            {
                return current;
            }

            current = current.NextNode;
            i++;
            
        }

        throw new IndexOutOfRangeException();

    }
    public void RemoveAt(int index)
    {
        if (index < 0 || index >= count)
            throw new IndexOutOfRangeException();

        if(index == 0)
        {
            head = head?.NextNode;
            count--;
            return;
        }

        var item = GetNode(index - 1);
       

        item.NextNode = item.NextNode.NextNode;
        count--;


    }
    public void InsertAt(int index, T value)
    {
        if (index < 0 || index >= count)
            throw new IndexOutOfRangeException();

        var newNode = new Node<T>(value);

        if(index == 0)
        {
            newNode.NextNode = head;
            head = newNode;
            count++;
            return;
            
        }

        var node = GetNode(index - 1);

        newNode.NextNode = node.NextNode;
        node.NextNode = newNode;
        count++;

    }
    //Iterator for LINQ or foreach
    public IEnumerator<T> GetEnumerator()
    {
        var current = head;
        while (current != null)
        {
            yield return current.Value;
            current = current.NextNode;
        }
    }
    System.Collections.IEnumerator System.Collections.IEnumerable.GetEnumerator()
    {
        return GetEnumerator();
    }

}

