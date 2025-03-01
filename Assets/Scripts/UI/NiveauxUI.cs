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
            Vector2 touchPosition = Touchscreen.current.primaryTouch.position.ReadValue();
            Vector2 worldPosition = Camera.main.ScreenToWorldPoint(touchPosition);
            RaycastHit2D hit = Physics2D.Raycast(worldPosition, Vector2.zero);
            if(hit.collider != null && hit.collider.gameObject == gameObject)
            {
                if (!isChangingScene && SceneManager.GetActiveScene().name == "Niveaux")
                {
                    ChangeScene();
                }
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
