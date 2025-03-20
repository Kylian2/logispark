using System;
using UnityEngine;

[Serializable]
public class Level
{

    private int number;
    private bool locked;

    public Level(int num)
    {
        number = num;
    }

    public void Unlock()
    {
        locked = false;
    }

    public void Lock()
    {
        locked = true;
    }

    public bool isLocked()
    {
        return locked;
    }

    public int getNumber()
    {
        return number;
    }
}