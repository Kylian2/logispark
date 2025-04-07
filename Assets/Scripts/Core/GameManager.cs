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

        LogicGate level1Source = new Source();

        LogicGate level1Gate1 = new GateNOT();
        LogicGate level1Gate2 = new GateNOT();

        Tree<LogicGate> lvl1source1 = new Tree<LogicGate>(level1Source);
        Tree<LogicGate> lvl1source2 = new Tree<LogicGate>(level1Source);
        
        Tree<LogicGate> lvl1spot1 = new Tree<LogicGate>(level1Gate1);
        lvl1spot1.AddChildren(lvl1source1);
        
        Tree<LogicGate> lvl1spot2 = new Tree<LogicGate>(level1Gate2);
        lvl1spot2.AddChildren(lvl1source2);
    
        Tree<LogicGate> lvl1spot3 = new Tree<LogicGate>(null);
        lvl1spot3.AddChildren(lvl1spot2);

        Tree<LogicGate> lvl1spot4 = new Tree<LogicGate>(null);
        lvl1spot4.AddChildren(lvl1spot1);
        lvl1spot4.AddChildren(lvl1spot3);
        
        Tree<LogicGate> destination = new Tree<LogicGate>(new Wire());
        destination.AddChildren(lvl1spot4);
        levels.Add(level1);

        Level level2 = new(2);
        level2.Unlock();
        level2.SetAnd(2);
        level2.SetOr(2);
        level2.SetNot(3);

        LogicGate level2Source = new Source();

        LogicGate level2Gate1 = new GateAND();
        LogicGate level2Gate2 = new GateNOT();

        Tree<LogicGate> lvl2source1 = new Tree<LogicGate>(level2Source);
        Tree<LogicGate> lvl2source2 = new Tree<LogicGate>(level2Source);
        Tree<LogicGate> lvl2source3 = new Tree<LogicGate>(level2Source);
        Tree<LogicGate> lvl2source4 = new Tree<LogicGate>(level2Source);

        /* Niveau 1 de l'arbre */
        Tree<LogicGate> lvl2spot1 = new Tree<LogicGate>(level2Gate2);
        lvl2spot1.AddChildren(lvl2source1);

        Tree<LogicGate> lvl2spot2 = new Tree<LogicGate>(level2Gate2);
        lvl2spot2.AddChildren(lvl2source2);

        Tree<LogicGate> lvl2spot3 = new Tree<LogicGate>(level2Gate2);
        lvl2spot3.AddChildren(lvl2source3);

        Tree<LogicGate> lvl2spot4 = new Tree<LogicGate>(level2Gate2);
        lvl2spot4.AddChildren(lvl2source4);

        /* Niveau 2 de l'arbre */
        Tree<LogicGate> lvl2spot5 = new Tree<LogicGate>(null);
        lvl2spot5.AddChildren(lvl2spot1);

        Tree<LogicGate> lvl2spot6 = new Tree<LogicGate>(null);
        lvl2spot6.AddChildren(lvl2spot2);

        Tree<LogicGate> lvl2spot7 = new Tree<LogicGate>(null);
        lvl2spot7.AddChildren(lvl2spot3);

        /* Niveau 3 de l'arbre */
        Tree<LogicGate> lvl2spot8 = new Tree<LogicGate>(null);
        lvl2spot8.AddChildren(lvl2spot5);
        lvl2spot8.AddChildren(lvl2spot6);

        Tree<LogicGate> lvl2spot9 = new Tree<LogicGate>(null);
        lvl2spot9.AddChildren(lvl2spot4);
        lvl2spot9.AddChildren(lvl2spot7);

        /* Niveau 4 de l'arbre */
        Tree<LogicGate> lvl2spot10 = new Tree<LogicGate>(level2Gate1);
        lvl2spot10.AddChildren(lvl2spot8);
        lvl2spot10.AddChildren(lvl2spot9);

        /* Destination */
        Tree<LogicGate> lvl2destination = new Tree<LogicGate>(new Wire());
        lvl2destination.AddChildren(lvl2spot10);
        levels.Add(level2);


        Level level3 = new(3);
        level3.Unlock();
        level3.SetOr(1);
        level3.SetNot(1);
        level3.SetNand(2);

        LogicGate level3Source = new Source();
        LogicGate level3Gate1 = new GateAND();
        LogicGate level3Gate2 = new GateNOT();
        LogicGate level3Gate3 = new GateAND();

        Tree<LogicGate> lvl3source1 = new Tree<LogicGate>(level3Source);
        Tree<LogicGate> lvl3source2 = new Tree<LogicGate>(level3Source);
        Tree<LogicGate> lvl3source3 = new Tree<LogicGate>(level3Source);
        Tree<LogicGate> lvl3source4 = new Tree<LogicGate>(level3Source);    
        Tree<LogicGate> lvl3source5 = new Tree<LogicGate>(level3Source);
        Tree<LogicGate> lvl3source6 = new Tree<LogicGate>(level3Source);
        Tree<LogicGate> lvl3source7 = new Tree<LogicGate>(level3Source);
        Tree<LogicGate> lvl3source8 = new Tree<LogicGate>(level3Source);
        Tree<LogicGate> lvl3source9 = new Tree<LogicGate>(level3Source);

        /* Niveau 1 de l'arbre */
        Tree<LogicGate> lvl3spot1 = new Tree<LogicGate>(null);
        lvl3spot1.AddChildren(lvl3source1);
        lvl3spot1.AddChildren(lvl3source2);

        Tree<LogicGate> lvl3spot2 = new Tree<LogicGate>(null);
        lvl3spot2.AddChildren(lvl3source4);
        lvl3spot2.AddChildren(lvl3source5);

        Tree<LogicGate> lvl3spot3 = new Tree<LogicGate>(null);
        lvl3spot3.AddChildren(lvl3source7);

        Tree<LogicGate> lvl3spot4 = new Tree<LogicGate>(null);
        lvl3spot4.AddChildren(lvl3source8);
        lvl3spot4.AddChildren(lvl3source9);

        /* Niveau 2 de l'arbre */
        Tree<LogicGate> lvl3spot5 = new Tree<LogicGate>(level3Gate1);
        lvl3spot5.AddChildren(lvl3spot1);
        lvl3spot5.AddChildren(lvl3source3);

        Tree<LogicGate> lvl3spot6 = new Tree<LogicGate>(null);
        lvl3spot6.AddChildren(lvl3spot2);
        lvl3spot6.AddChildren(lvl3source6);

        Tree<LogicGate> lvl3spot7 = new Tree<LogicGate>(null);
        lvl3spot7.AddChildren(lvl3spot3);
        lvl3spot7.AddChildren(lvl3spot4);

        /* Niveau 3 de l'arbre */   
        Tree<LogicGate> lvl3spot8 = new Tree<LogicGate>(level3Gate2);
        lvl3spot8.AddChildren(lvl3spot5);

        Tree<LogicGate> lvl3spot9 = new Tree<LogicGate>(null);
        lvl3spot9.AddChildren(lvl3spot6);
        lvl3spot9.AddChildren(lvl3spot7);

        /* Niveau 4 de l'arbre */
        Tree<LogicGate> lvl3spot10 = new Tree<LogicGate>(level3Gate3);
        lvl3spot10.AddChildren(lvl3spot8);
        lvl3spot10.AddChildren(lvl3spot9);

        /* Destination */
        Tree<LogicGate> lvl3destination = new Tree<LogicGate>(new Wire());
        lvl3destination.AddChildren(lvl3spot10);
        Debug.Log(lvl3destination.ToString());

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
