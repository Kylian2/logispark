using System;
using System.Collections.Generic;
using System.IO;
using UnityEngine;

// Classe minimaliste pour la sérialisation
[Serializable]
public class LevelProgress
{
    public int number;      
    public bool locked;    
    public double score;    

    // Constructeur pour convertir depuis un Level
    public LevelProgress(Level level)
    {
        number = level.getNumber();
        locked = level.isLocked();
        score = level.GetScore();
    }
}

// Classe pour stocker la collection de progressions
[Serializable]
public class PlayerProgress
{
    public List<LevelProgress> levels = new List<LevelProgress>();
}

public class ProgressManager : MonoBehaviour
{
    private const string SAVE_FILE = "player_progress.json";
    private string savePath;

    public ProgressManager instance;

    private void Awake()
    {

        if (instance == null)
        {
            instance = this;          
            DontDestroyOnLoad(this);        
        }
        else
        {
            Destroy(gameObject);
        }

        //Chemin du fichier de sauvegarde
        // A voir si c'est la méthode la plus fiable pour sauvegarder, 
        // en tout cas au niveau de l'emplacement
        savePath = Path.Combine(Application.dataPath, "./", SAVE_FILE); 
        Debug.Log("Fichier de sauvegarde: " + savePath);
    }

    // Sauvegarder la progression
    public void SaveProgress()
    {
        try
        {
            PlayerProgress progress = new PlayerProgress();

            // Convertir uniquement les informations de progression pour chaque niveau
            foreach (Level level in GameManager.instance.getLevels())
            {
                progress.levels.Add(new LevelProgress(level));
            }

            // Convertir en JSON
            string json = JsonUtility.ToJson(progress, true);
            
            // Écrire dans le fichier
            File.WriteAllText(savePath, json);
            
            Debug.Log("Progression sauvegardée avec succès!");
        }
        catch (Exception e)
        {
            Debug.LogError("Erreur lors de la sauvegarde: " + e.Message);
        }
    }

    public void LoadProgress()
    {
        if (!File.Exists(savePath))
        {
            Debug.Log("Aucune sauvegarde trouvée. Première utilisation du jeu.");
            return;
        }

        try
        {
            // Lire le fichier JSON
            string json = File.ReadAllText(savePath);
            
            // Convertir en objet
            PlayerProgress progress = JsonUtility.FromJson<PlayerProgress>(json);

            // appliquer les données sauvégardées auc niveaux
            foreach (LevelProgress levelProgress in progress.levels)
            {
                // Trouver le niveau dans la liste
                Level level = GameManager.instance.getLevels().Find(l => l.getNumber() == levelProgress.number);
                
                if (level != null)
                {
                    if (levelProgress.locked)
                        level.Lock();
                    else
                        level.Unlock();
                    
                    level.SetScore(levelProgress.score);
                }
            }
            
            Debug.Log("Progression chargée avec succès!");
        }
        catch (Exception e)
        {
            Debug.LogError("Erreur lors du chargement: " + e.Message);
        }
    }
}