using System;
using UnityEngine;
using UnityEngine.SocialPlatforms.Impl;

[Serializable]
public class Level
{

    private const int TIME = 1;
    private const int MOVE = 2;

    private int number;
    private bool locked;

    private int scoringSystem;
    private int score;

    // Inventaire du nombre de portes disponibles
    private int or;
    private int xor;
    private int and;
    private int not;
    private int nand;
    private int nor;
    private int wire;


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

    public int GetOr()
    {
        return or;
    }

    public int GetXor()
    {
        return xor;
    }

    public int GetAnd()
    {
        return and;
    }

    public int GetNot()
    {
        return not;
    }

    public int GetNand()
    {
        return nand;
    }

    public int GetNor()
    {
        return nor;
    }

    public int GetWire()
    {
        return wire;
    }
}