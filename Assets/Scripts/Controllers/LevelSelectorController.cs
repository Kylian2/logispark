using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class LevelSelectorController : MonoBehaviour
{

    void Start()
    {
        setHomeButtonListener();
    }

    void goMenu()
    {
        SceneManager.LoadScene("Menu");
    }

    public void setHomeButtonListener()
    {
        Button homeButton = GameObject.Find("Menu").GetComponent<Button>();
        homeButton.onClick.AddListener(goMenu);
    }

    public void handleClick(int level)
    {
        if (!GameManager.instance.levelIsLocked(level))
        {
            GameManager.instance.setActiveLevel(level);

            switch (level)
            {
                case 1:
                    SceneManager.LoadScene("Level_1");
                    break;
                case 2:
                    SceneManager.LoadScene("Level_2");
                    break;
                case 3:
                    SceneManager.LoadScene("Level_3");
                    break;
                default:
                    SceneManager.LoadScene("Level_1");
                    break;
            }
        }
        else
        {
            Debug.Log("Level " + level + " is locked");
        }
    }
}
