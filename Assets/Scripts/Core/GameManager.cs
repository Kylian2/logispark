using System.Collections.Generic;
using LogiSpark.Models;
using UnityEngine;

public class GameManager : MonoBehaviour
{

    public static GameManager instance; // Instance unique de GameManager
    public ProgressManager progressManager;

    public const int NB_LEVELS = 10;

    [SerializeField] private List<Level> levels;

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

        // Obtenir le ProgressManager
        progressManager = GetComponent<ProgressManager>();
        
        // Si vous n'avez pas ajouté le composant dans l'éditeur
        if (progressManager == null)
        {
            progressManager = gameObject.AddComponent<ProgressManager>();
        }
        
        InitializeGame();
        
        // Charger la progression sauvegardée
        progressManager.LoadProgress();
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
        level1.SetWire(2);

        level1.treemaker = emplacement =>
        {
            LogicGate level1Source = new Source();

            LogicGate level1Gate1 = new GateNOT();
            LogicGate level1Gate2 = new GateNOT();

            emplacement.Add("3", new List<Tree<LogicGate>>());
            emplacement.Add("4", new List<Tree<LogicGate>>());

            Tree<LogicGate> lvl1source1 = new Tree<LogicGate>(level1Source);
            Tree<LogicGate> lvl1source2 = new Tree<LogicGate>(level1Source);
            
            Tree<LogicGate> lvl1spot1 = new Tree<LogicGate>(level1Gate1);
            lvl1spot1.AddChildren(lvl1source1);
            
            Tree<LogicGate> lvl1spot2 = new Tree<LogicGate>(level1Gate2);
            lvl1spot2.AddChildren(lvl1source2);
        
            Tree<LogicGate> lvl1spot3 = new Tree<LogicGate>(null);
            lvl1spot3.AddChildren(lvl1spot2);
            emplacement["3"].Add(lvl1spot3);

            Tree<LogicGate> lvl1spot4 = new Tree<LogicGate>(null);
            lvl1spot4.AddChildren(lvl1spot1);
            lvl1spot4.AddChildren(lvl1spot3);
            emplacement["4"].Add(lvl1spot4);
            
            Tree<LogicGate> destination = new Tree<LogicGate>(new Wire());
            destination.AddChildren(lvl1spot4);
            return destination;
        };
        
        levels.Add(level1);

        Level level2 = new(2);
        level2.Lock();
        level2.SetAnd(2);
        level2.SetOr(2);
        level2.SetNot(3);

        level2.treemaker = emplacement =>
        {
            LogicGate level2Source = new Source();

            LogicGate level2Gate1 = new GateAND();
            LogicGate level2Gate2 = new GateNOT();

            emplacement.Add("2", new List<Tree<LogicGate>>());
            emplacement.Add("3", new List<Tree<LogicGate>>());
            emplacement.Add("4", new List<Tree<LogicGate>>());
            emplacement.Add("5", new List<Tree<LogicGate>>());

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
            emplacement["2"].Add(lvl2spot5);

            Tree<LogicGate> lvl2spot6 = new Tree<LogicGate>(null);
            lvl2spot6.AddChildren(lvl2spot2);
            emplacement["2"].Add(lvl2spot6);

            Tree<LogicGate> lvl2spot7 = new Tree<LogicGate>(null);
            lvl2spot7.AddChildren(lvl2spot3);
            emplacement["3"].Add(lvl2spot7);

            /* Niveau 3 de l'arbre */
            Tree<LogicGate> lvl2spot8 = new Tree<LogicGate>(null);
            lvl2spot8.AddChildren(lvl2spot5);
            lvl2spot8.AddChildren(lvl2spot6);
            emplacement["4"].Add(lvl2spot8);

            Tree<LogicGate> lvl2spot9 = new Tree<LogicGate>(null);
            lvl2spot9.AddChildren(lvl2spot4);
            lvl2spot9.AddChildren(lvl2spot7);
            emplacement["5"].Add(lvl2spot9);

            /* Niveau 4 de l'arbre */
            Tree<LogicGate> lvl2spot10 = new Tree<LogicGate>(level2Gate1);
            lvl2spot10.AddChildren(lvl2spot8);
            lvl2spot10.AddChildren(lvl2spot9);

            /* Destination */
            Tree<LogicGate> lvl2destination = new Tree<LogicGate>(new Wire());
            lvl2destination.AddChildren(lvl2spot10);
            return lvl2destination;
        };
        levels.Add(level2);


        Level level3 = new(3);
        level3.Lock();
        level3.SetOr(1);
        level3.SetNot(2);
        level3.SetNand(2);
        level3.SetWire(2);

        level3.treemaker = emplacement =>
        { 
            LogicGate level3Source = new Source();
            LogicGate level3Gate1 = new GateAND();
            LogicGate level3Gate2 = new GateNOT();
            LogicGate level3Gate3 = new GateAND();

            emplacement.Add("1", new List<Tree<LogicGate>>());
            emplacement.Add("2", new List<Tree<LogicGate>>());
            emplacement.Add("4", new List<Tree<LogicGate>>());
            emplacement.Add("6", new List<Tree<LogicGate>>());

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
            emplacement["2"].Add(lvl3spot1);

            Tree<LogicGate> lvl3spot2 = new Tree<LogicGate>(null);
            lvl3spot2.AddChildren(lvl3source4);
            lvl3spot2.AddChildren(lvl3source5);
            emplacement["1"].Add(lvl3spot2);

            Tree<LogicGate> lvl3spot3 = new Tree<LogicGate>(null);
            lvl3spot3.AddChildren(lvl3source7);
            emplacement["2"].Add(lvl3spot3);

            Tree<LogicGate> lvl3spot4 = new Tree<LogicGate>(null);
            lvl3spot4.AddChildren(lvl3source8);
            lvl3spot4.AddChildren(lvl3source9);
            emplacement["1"].Add(lvl3spot4);

            /* Niveau 2 de l'arbre */
            Tree<LogicGate> lvl3spot5 = new Tree<LogicGate>(level3Gate1);
            lvl3spot5.AddChildren(lvl3spot1);
            lvl3spot5.AddChildren(lvl3source3);

            Tree<LogicGate> lvl3spot6 = new Tree<LogicGate>(level3Gate1);
            lvl3spot6.AddChildren(lvl3spot2);
            lvl3spot6.AddChildren(lvl3source6);

            Tree<LogicGate> lvl3spot7 = new Tree<LogicGate>(null);
            lvl3spot7.AddChildren(lvl3spot3);
            lvl3spot7.AddChildren(lvl3spot4);
            emplacement["4"].Add(lvl3spot7);

            /* Niveau 3 de l'arbre */   
            Tree<LogicGate> lvl3spot8 = new Tree<LogicGate>(level3Gate2);
            lvl3spot8.AddChildren(lvl3spot5);

            Tree<LogicGate> lvl3spot9 = new Tree<LogicGate>(null);
            lvl3spot9.AddChildren(lvl3spot6);
            lvl3spot9.AddChildren(lvl3spot7);
            emplacement["6"].Add(lvl3spot9);

            /* Niveau 4 de l'arbre */
            Tree<LogicGate> lvl3spot10 = new Tree<LogicGate>(level3Gate3);
            lvl3spot10.AddChildren(lvl3spot8);
            lvl3spot10.AddChildren(lvl3spot9);

            /* Destination */
            Tree<LogicGate> lvl3destination = new Tree<LogicGate>(new Wire());
            lvl3destination.AddChildren(lvl3spot10);
            return lvl3destination;
        };
        levels.Add(level3);
        
        for(int i = 4; i <= NB_LEVELS; i++)
        {
            levels.Add(new Level(i));
        }
    }

    public List<Level> getLevels()
    {
        return levels;
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

    public void UnlockLevel(int level)
    {
        for (int i = 0; i < NB_LEVELS; i++)
        {
            if (levels[i].getNumber() == level)
            {
                levels[i].Unlock();
                return;
            }
        }
        Debug.LogError("Level " + level + " not found");
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

    public void RegisterScore(int level, double score){
        for (int i = 0; i < NB_LEVELS; i++)
        {
            if (levels[i].getNumber() == level)
            {
                levels[i].SetScore(score);
                return;
            }
        }
        Debug.LogError("Level " + level + " not found");
    }

    // Sauvegarde automatique en quittant le jeu
    private void OnApplicationQuit()
    {
        progressManager.SaveProgress();
    }
    
    // Sauvegarde automatique en mettant le jeu en pause
    private void OnApplicationPause(bool pauseStatus)
    {
        if (pauseStatus)
        {
            progressManager.SaveProgress();
        }
    }

    public Level GetLevel(int level){
        for (int i = 0; i < NB_LEVELS; i++)
        {
            if (levels[i].getNumber() == level)
            {
                return levels[i];
            }
        }
        Debug.LogError("Level " + level + " not found");
        return null;
    }
}
