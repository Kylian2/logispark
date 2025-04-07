using System;
using System.Collections.Generic;
using System.Text;
using LogiSpark.Models;
using Unity.Android.Gradle;
using UnityEngine;

public class GameManager : MonoBehaviour
{

    public static GameManager instance; // Instance unique de GameManager

    public const int NB_LEVELS = 3;

    private List<Level> levels;

    private Level currentLevel;

    void Awake()
    {
    
        if (instance == null)
        {
            instance = this;          
            DontDestroyOnLoad(this);  
            InitializeGame();         
        }
        else
        {
            Destroy(gameObject);
        }
    }

    private void InitializeGame()
    {
        
        //Il faudra récupérer les données sauvegardées pour initialiser le jeu, 
        //ce code d'initialisation est temporaire
        levels = new List<Level>();

        Level level1 = new(1);
        level1.Unlock();
        level1.SetAnd(1);
        level1.SetOr(1);
        level1.SetNot(2);

        Tree<LogicGate> source1 = new Tree<LogicGate>(new Source());
        Tree<LogicGate> source2 = new Tree<LogicGate>(new Source());
        
        Tree<LogicGate> spot1 = new Tree<LogicGate>(new GateNOT());
        spot1.AddChildren(source1);
        
        Tree<LogicGate> spot2 = new Tree<LogicGate>(new GateNOT());
        spot2.AddChildren(source2);
    
        Tree<LogicGate> spot3 = new Tree<LogicGate>(null);
        spot3.AddChildren(spot2);

        Tree<LogicGate> spot4 = new Tree<LogicGate>(null);
        spot4.AddChildren(spot1);
        spot4.AddChildren(spot3);
        
        Tree<LogicGate> destination = new Tree<LogicGate>(new Wire());
        destination.AddChildren(spot4);
        levels.Add(level1);

        Level level2 = new(2);
        level2.Lock();
        level2.SetAnd(2);
        level2.SetOr(2);
        level2.SetNot(3);
        levels.Add(level2);

        Level level3 = new(3);
        level3.Lock();
        level3.SetOr(1);
        level3.SetNot(1);
        level3.SetNand(2);
        levels.Add(level3);

    }

    public bool levelIsLocked(int level)
    {
        for(int i = 0; i < NB_LEVELS; i++)
        {
            if (levels[i].getNumber() == level)
            {
                return levels[i].isLocked();
            }
        }
        return false;
    }

    public Level getCurrentLevel()
    {
        return currentLevel;
    }
    public void setActiveLevel(int level)
    {
        for (int i = 0; i < NB_LEVELS; i++)
        {
            if (levels[i].getNumber() == level)
            {
                currentLevel = levels[i];
                return;
            }
        }
        Debug.LogError("Level " + level + " not found");
    }
}
