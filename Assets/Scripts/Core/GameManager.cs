using System.Collections.Generic;
using Unity.Android.Gradle;
using UnityEngine;

public class GameManager : MonoBehaviour
{

    public static GameManager instance; // Instance unique de GameManager

    public const int NB_LEVELS = 10;

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

        for (int i = 0; i < NB_LEVELS; i++)
        {
            Level level = new Level(i+1);
            level.SetNot(1);
            level.SetAnd(1);
            levels.Add(level);
            if (i == 0)
            {
                levels[i].Unlock();
            }else
            {
                levels[i].Lock();
            }
        }
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
    }
}
