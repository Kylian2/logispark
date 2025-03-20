using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class MainMenuController : MonoBehaviour
{

    private Button startButton;

    void Start()
    {
        startButton = GetComponent<Button>();
        startButton.onClick.AddListener(startButtonListener);
    }

    void startButtonListener()
    {
        SceneManager.LoadScene("LevelSelect");
    }
}
