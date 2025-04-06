using System;
using System.Collections.Generic;
using System.Text;

public class Tree<T>
{
    private T data;
    private List<Tree<T>> children;
    private Tree<T> parent;

    public Tree()
    {
        this.children = new List<Tree<T>>();
    }

    public Tree(T data, params Tree<T>[] childs)
    {
        this.data = data;
        this.children = new List<Tree<T>>();
        foreach (Tree<T> child in childs)
        {
            this.children.Add(child);
        }
        this.parent = null;
    }

    public T Data()
    {
        return this.data;
    }

    public Tree<T> Child(int n)
    {
        try
        {
            return this.Children().Count > n ? this.Children()[n] : null;
        }
        catch (ArgumentOutOfRangeException)
        {
            return null;
        }
    }

    private List<Tree<T>> Children()
    {
        return this.children;
    }

    public int NbChildren()
    {
        return this.Children().Count;
    }

    public Tree<T> Parent()
    {
        return this.parent;
    }

    public void AddChildren(params Tree<T>[] childs)
    {
        foreach (Tree<T> child in childs)
        {
            child.parent = this;
            this.children.Add(child);
        }
    }

    /* Note: The following method can only modify an existing child */
    public void SetChild(int i, Tree<T> child)
    {
        this.children[i] = child;
    }

    /* Adapted from VasiliNovikov@StackOverflow */
    private void Print(StringBuilder buffer, string prefix, string childrenPrefix)
    {
        buffer.Append(prefix);
        buffer.Append(this.Data());
        buffer.Append('\n');
        for (int i = 0; i < NbChildren(); i++)
        {
            Tree<T> next = this.Child(i);
            if (i < NbChildren() - 1)
            {
                next.Print(buffer, childrenPrefix + "├── ", childrenPrefix + "│   ");
            }
            else
            {
                next.Print(buffer, childrenPrefix + "└── ", childrenPrefix + "    ");
            }
        }
    }

    public override string ToString()
    {
        StringBuilder buffer = new StringBuilder(50);
        Print(buffer, "", "");
        return buffer.ToString();
    }

    public void Display()
    {
        Console.WriteLine(this.ToString());
    }

    // (*) Depth of a tree
    public int Depth()
    {
        int max = 0;
        for (int i = 0; i < this.NbChildren(); i++)
        {
            int v = this.Child(i).Depth();
            if (v > max)
            {
                max = v;
            }
        }
        return max + 1;
    }

    public int Size()
    {
        int nbfils = 0;
        for (int i = 0; i < this.NbChildren(); i++)
        {
            if (this.Child(i) != null)
            {
                nbfils += this.Child(i).Size();
            }
        }
        return nbfils + 1;
    }

    public int Max()
    {
        if (!(this.Data() is int))
        {
            throw new InvalidOperationException("Invalid type of data, data must be an integer");
        }
        
        int max = (int)(object)this.Data();
        for (int i = 0; i < this.NbChildren(); i++)
        {
            int v = this.Child(i).Max();
            if (v > max)
            {
                max = v;
            }
        }
        
        return max;
    }
}