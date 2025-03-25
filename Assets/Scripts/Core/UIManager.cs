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

    void Awake(){
    
        if (instance == null)
        {
            instance = this;          
            DontDestroyOnLoad(this);     

            levelSelectorController = gameObject.AddComponent<LevelSelectorController>();
        }
        else
        {
            Destroy(gameObject);
        }
    }

    public void displayLevels(){
        Debug.Log(SceneManager.GetActiveScene().name);
        if(SceneManager.GetActiveScene().name != "LevelSelect"){
            return;
        }
        Debug.Log("Display levels");
        buttonContainer = FindObjectOfType<GridLayoutGroup>().transform;
        for(int i = 0; i < GameManager.NB_LEVELS; i++)
        {
            Button button = Instantiate(levelButton, buttonContainer);
            button.onClick.AddListener(delegate { levelSelectorController.handleClick(i+1); });
            if(GameManager.instance.levelIsLocked(i+1))
            {
                button.interactable = false;
                button.GetComponent<Image>().sprite = Resources.Load<Sprite>("Graphics/Buttons/Level" + (i+1)+"/locked");
            }else{
                button.GetComponent<Image>().sprite = Resources.Load<Sprite>("Graphics/Buttons/Level" + (i+1)+"/unlocked");
            }
        }

        levelSelectorController.setHomeButtonListener();
    }
}
