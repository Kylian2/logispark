using UnityEngine;
using System.Collections.Generic;

public class LevelManager : MonoBehaviour
{
    public List<Level> levels = new List<Level>(); // Liste de tous les niveaux
    public int totalLevels = 1; // Nombre total de niveaux (modifiable)

    void Start()
    {
        LoadLevels(); 
    }

    void LoadLevels()
    {
        levels.Clear();

        for (int i = 1; i <= totalLevels; i++)
        {
            bool isUnlocked = i != 1; // Le niveau 1 est toujours débloqué
            levels.Add(new Level(i, isUnlocked)); 
        }
    }
}
