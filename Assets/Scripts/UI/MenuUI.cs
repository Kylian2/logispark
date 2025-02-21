using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.SceneManagement;

public class MenuUI : MonoBehaviour
{
    private bool isChangingScene = false;

    void Update()
    {
        if (Touchscreen.current != null && Touchscreen.current.primaryTouch.press.wasPressedThisFrame) 
        {
            if (!isChangingScene && SceneManager.GetActiveScene().name == "Accueil")
            {
                ChangeScene();
            }
        }
    }

    void ChangeScene()
    {
        isChangingScene = true;
        Debug.Log("Changement de scène vers : Accueil");
        SceneManager.LoadScene("Niveaux");
    }
}
