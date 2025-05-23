using UnityEditor.SearchService;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class UIManager : MonoBehaviour
{
    //Le UIManager est un singleton qui s'occupera d'afficher les différents éléments de l'interface utilisateur comme :
    // - L'écran de victoire
    // - L'écran de défaite
    // - Les pops-up qui peuvent intervenir
    //IL gèrera probablement l'affichage des chronomètres et des scores.

    public static UIManager instance; // Instance unique de UIManager
    public Button levelButton;
    public Transform buttonContainer;

    public LevelSelectorController levelSelectorController;
    public MainMenuController mainMenuController;

    void Awake(){
    
        if (instance == null)
        {
            instance = this;          
            DontDestroyOnLoad(this);     

            levelSelectorController = gameObject.AddComponent<LevelSelectorController>();
            mainMenuController = gameObject.AddComponent<MainMenuController>();
        }
        else
        {
            Destroy(gameObject);
        }
    }

    public void displayLevels() {
        if(SceneManager.GetActiveScene().name != "LevelSelect") {
            return;
        }
        buttonContainer = FindObjectOfType<GridLayoutGroup>().transform;
        for(int i = 0; i < GameManager.NB_LEVELS; i++) {
            Button button = Instantiate(levelButton, buttonContainer);
            // Créer une copie locale de i qui sera capturée par valeur
            int levelNumber = i + 1;
            
            // Utiliser cette copie locale dans le délégué
            button.onClick.AddListener(delegate { levelSelectorController.handleClick(levelNumber); });
            
            if(GameManager.instance.levelIsLocked(levelNumber)) {
                button.interactable = false;
                button.GetComponent<Image>().sprite = Resources.Load<Sprite>("Graphics/Buttons/Level" + levelNumber + "/locked");
            } else {
                Level level = GameManager.instance.GetLevel(levelNumber);
                double score = level.GetScore();
                if (score > 0){
                    button.GetComponent<Image>().sprite = Resources.Load<Sprite>("Graphics/Buttons/Level" + levelNumber + "/oneStar");
                    if (score > 50)
                    {
                        button.GetComponent<Image>().sprite = Resources.Load<Sprite>("Graphics/Buttons/Level" + levelNumber + "/twoStars");
                        if (score > 80)
                        {
                            button.GetComponent<Image>().sprite = Resources.Load<Sprite>("Graphics/Buttons/Level" + levelNumber + "/threeStars");
                        }
                    }
                }else{
                    button.GetComponent<Image>().sprite = Resources.Load<Sprite>("Graphics/Buttons/Level" + levelNumber + "/unlocked");
                }
            }
        }

        levelSelectorController.setHomeButtonListener();
    }
}
