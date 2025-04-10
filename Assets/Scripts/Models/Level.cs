using System;
using System.Collections.Generic;
using LogiSpark.Models;
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
    private double score;

    // Inventaire du nombre de portes disponibles
    private int or;
    private int xor;
    private int and;
    private int not;
    private int nand;
    private int nor;
    private int wire;

    public Func<Dictionary<string, List<Tree<LogicGate>>>, Tree<LogicGate>> treemaker;


    public Level(int num)
    {
        number = num;
        score = 0;
        locked = true;
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

    public int GetWire()
    {
        return wire;
    }

    public void SetOr(int or)
    {
        this.or = or;
    }
    public void SetXor(int xor)
    {
        this.xor = xor;
    }
    public void SetAnd(int and)
    {
        this.and = and;
    }
    public void SetNot(int not)
    {
        this.not = not;
    }
    public void SetNand(int nand)
    {
        this.nand = nand;
    }
    public void SetWire(int wire)
    {
        this.wire = wire;
    }

    public int GetNbDoors()
    {
        return or + xor + and + not + nand + wire;
    }

    public void SetScore(double score)
    {
        if(this.score < score)
        {
            this.score = score;
        }
    }

    public double GetScore()
    {
        return score;
    }
}