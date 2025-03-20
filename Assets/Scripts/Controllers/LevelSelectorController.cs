using UnityEditor.SearchService;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class LevelSelectorController : MonoBehaviour
{
    public Button homeButton;
    void Start()
    {
        homeButton.onClick.AddListener(goMenu);
    }

    void goMenu()
    {
        SceneManager.LoadScene("Menu");
    }

    public void handleClick(int level){
        if(!GameManager.instance.levelIsLocked(level)){
            Debug.Log("Move to level " + level);
        }else{
            Debug.Log("Level " + level + " is locked");
        }
    }
}
