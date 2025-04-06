using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.PlayerLoop;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class LevelManager : MonoBehaviour
{

    public ActiveLevel activeLevel;
    public Transform inventory;

    public TMPro.TextMeshProUGUI scoreDisplay;

    public GameObject gridElementPrefab; // Prefab pour les éléments de la grille

    public Button pauseButton;
    public Button restartButton;
    public Button leaveButton;

    public GameObject modalePause;


    void Start()
    {
        Level level = GameManager.instance.getCurrentLevel();
        activeLevel = new ActiveLevel(level);
        activeLevel.InstanciateGates();
        
        // Ajouter les portes NOT si disponibles
        if(activeLevel.GetLevel().GetNot() > 0)
        {
            AddGateToInventory("gate_not", activeLevel.GetLevel().GetNot());
        }
        
        // Ajouter les portes AND si disponibles
        if(activeLevel.GetLevel().GetAnd() > 0)
        {
            AddGateToInventory("gate_and", activeLevel.GetLevel().GetAnd());
        }
        
        if(activeLevel.GetLevel().GetOr() > 0)
        {
            AddGateToInventory("gate_or", activeLevel.GetLevel().GetAnd());
        }

        if(activeLevel.GetLevel().GetNand() > 0)
        {
            AddGateToInventory("gate_nand", activeLevel.GetLevel().GetAnd());
        }

        if(activeLevel.GetLevel().GetXor() > 0)
        {
            AddGateToInventory("gate_xor", activeLevel.GetLevel().GetAnd());
        }
        modalePause.SetActive(false);
        activeLevel.StartScore();
        pauseButton.onClick.AddListener(PauseGame);
        restartButton.onClick.AddListener(ResumeGame);
        leaveButton.onClick.AddListener(LeaveGame);
    }

    void Update()
    {
        // Mettre à jour l'affichage du score
        if (scoreDisplay != null)
        {
            Debug.Log(activeLevel.GetInGameScore().ToString());
            scoreDisplay.text = activeLevel.GetInGameScore().ToString();
        }
        else
        {
            Debug.LogError("Score display not found.");
        }
    }

    // Fonction pour ajouter un élément de porte logique à l'inventaire
    private void AddGateToInventory(string gateType, int quantity)
    {
        GameObject gridElement = Instantiate(gridElementPrefab, inventory);
        
        // Mettre à jour l'image
        Transform gateTransform = gridElement.transform.Find("gate");
        if (gateTransform != null)
        {
            // Charger le sprite depuis les ressources
            SpriteRenderer spriteRenderer = gateTransform.GetComponent<SpriteRenderer>();
            if (spriteRenderer != null)
            {
                spriteRenderer.sprite = Resources.Load<Sprite>("Graphics/Gates/" + gateType);
            }
            else
            {
                Debug.LogError("SpriteRenderer not found on gate object.");
            }
        }
        else
        {
            Debug.LogError("Gate image not found in prefab.");
        }
        
        // Mettre à jour le texte de quantité
        TMPro.TextMeshProUGUI quantityText = gridElement.transform.Find("quantity").GetComponent<TMPro.TextMeshProUGUI>();
        if (quantityText != null)
        {
            quantityText.text = quantity.ToString();
        }
        else
        {
            Debug.LogError("Quantity text not found in prefab.");
        }
    }

    public void PauseGame()
    {
        modalePause.SetActive(true);
        activeLevel.GetScoringSystem().Pause();

    }

    public void ResumeGame()
    {
        modalePause.SetActive(false);
        activeLevel.GetScoringSystem().Resume();
    }

    public async void LeaveGame()
    {
        AsyncOperation asyncLoad = SceneManager.LoadSceneAsync("LevelSelect");
        
        // Empêcher la transition automatique vers la nouvelle scène lorsqu'elle est prête
        asyncLoad.allowSceneActivation = true;
        
        // Attendre que la scène soit complètement chargée
        while (!asyncLoad.isDone)
        {   
            // Attendre le prochain frame
            await System.Threading.Tasks.Task.Yield();
        }
        
        // Maintenant que la scène est chargée, afficher les niveaux
        UIManager.instance.displayLevels();
    }
}
