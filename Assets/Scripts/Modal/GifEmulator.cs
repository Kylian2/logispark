using UnityEngine;
using UnityEngine.UI;

public class GifController : MonoBehaviour
{
    public Image image;  
    public Sprite[] sprites; 
    public float frameRate = 1f; 

    private int currentFrame = 0;  

    void Start()
    {
        if (sprites.Length > 0)
        {
            InvokeRepeating("ChangeImage", 0f, frameRate);
        }
        else
        {
            Debug.LogError("Le tableau de sprites est vide ! Impossible de démarrer le GIF.");
        }
    }

    void ChangeImage()
    {
        if (sprites.Length > 0)
        {
            currentFrame = (currentFrame + 1) % sprites.Length;

            image.sprite = sprites[currentFrame];
        }
        else
        {
            Debug.LogError("Le tableau de sprites est vide. Impossible de changer d'image.");
        }
    }

    void OnDisable()
    {
        CancelInvoke("ChangeImage");
    }
}
