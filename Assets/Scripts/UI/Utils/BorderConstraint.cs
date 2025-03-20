using UnityEngine;

public class BorderConstraint2D : MonoBehaviour
{
    [Header("Distances minimales par rapport aux bords")]
    [SerializeField] private float leftBorderDistance = 50f;
    [SerializeField] private float rightBorderDistance = 50f;
    [SerializeField] private float topBorderDistance = 50f;
    [SerializeField] private float bottomBorderDistance = 50f;
    
    private Camera mainCamera;
    private float objectHalfWidth;
    private float objectHalfHeight;
    
    void Start()
    {
        mainCamera = Camera.main;
        
        // Récupérer la taille de l'objet 2D
        SpriteRenderer spriteRenderer = GetComponent<SpriteRenderer>();
        if (spriteRenderer != null)
        {
            objectHalfWidth = spriteRenderer.bounds.extents.x;  // extents = half size
            objectHalfHeight = spriteRenderer.bounds.extents.y;
        }
        else
        {
            // Fallback si pas de SpriteRenderer
            Collider2D collider = GetComponent<Collider2D>();
            if (collider != null)
            {
                objectHalfWidth = collider.bounds.extents.x;
                objectHalfHeight = collider.bounds.extents.y;
            }
            else
            {
                // Dernier recours
                objectHalfWidth = transform.localScale.x / 2;
                objectHalfHeight = transform.localScale.y / 2;
            }
        }

        Vector2 bottomLeft = mainCamera.ScreenToWorldPoint(new Vector2(0, 0));
        Vector2 topRight = mainCamera.ScreenToWorldPoint(new Vector2(Screen.width, Screen.height));
        
        // Tenir compte des zones de sécurité (notches, etc.)
        Rect safeArea = Screen.safeArea;
        Vector2 safeBottomLeft = mainCamera.ScreenToWorldPoint(new Vector2(safeArea.xMin, safeArea.yMin));
        Vector2 safeTopRight = mainCamera.ScreenToWorldPoint(new Vector2(safeArea.xMax, safeArea.yMax));
        
        // Calculer les limites en tenant compte de la taille de l'objet et des distances personnalisées
        float minX = safeBottomLeft.x + objectHalfWidth + leftBorderDistance;
        float maxX = safeTopRight.x - objectHalfWidth - rightBorderDistance;
        float minY = safeBottomLeft.y + objectHalfHeight + bottomBorderDistance;
        float maxY = safeTopRight.y - objectHalfHeight - topBorderDistance;
        
        // Obtenir la position actuelle
        Vector3 pos = transform.position;
        
        // Limiter la position dans les bornes
        pos.x = Mathf.Clamp(pos.x, minX, maxX);
        pos.y = Mathf.Clamp(pos.y, minY, maxY);
        
        // Appliquer la nouvelle position
        transform.position = pos;
    }
    
}