using UnityEditor.SearchService;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class LevelSelectorController : MonoBehaviour
{

    void goMenu()
    {
        SceneManager.LoadScene("Menu");
    }

    public void setHomeButtonListener()
    {
        Button homeButton = GameObject.Find("Menu").GetComponent<Button>();
        homeButton.onClick.AddListener(goMenu);
    }

    public void handleClick(int level){
        if(!GameManager.instance.levelIsLocked(level)){
            Debug.Log("Move to level " + level);
        }else{
            Debug.Log("Level " + level + " is locked");
        }
    }
}
