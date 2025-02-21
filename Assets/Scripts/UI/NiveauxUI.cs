using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.SceneManagement;

public class NiveauxUI : MonoBehaviour
{
    private bool isChangingScene = false;

    void Update()
    {
        if (Touchscreen.current != null && Touchscreen.current.primaryTouch.press.wasPressedThisFrame) 
        {
            if (!isChangingScene && SceneManager.GetActiveScene().name == "Niveaux")
            {
                ChangeScene();
            }
        }
    }

    void ChangeScene()
    {
        isChangingScene = true;
        Debug.Log("Changement de scène vers : Accueil");
        SceneManager.LoadScene("Accueil");
    }
}
