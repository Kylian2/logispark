using System;
using UnityEngine;

[Serializable]
public class Level
{

    private int number;
    private bool locked;
    private GameObject levelIcon;
    private Sprite sprite;

    public Level(int num, bool lo)
    {
        this.number = num;
        this.locked = lo;
        levelIcon = new GameObject("Level" + number);
        SpriteRenderer spriteRenderer = levelIcon.AddComponent<SpriteRenderer>();

        // Charger le sprite en fonction du statut "locked"
        Sprite sprite = Resources.Load<Sprite>("Sprites/Levels/Level" + number + (locked ? "/locked" : "/unlocked"));

        if (sprite == null)
        {
            Debug.LogError("Sprite introuvable pour le niveau " + number);
        }
        else
        {
            spriteRenderer.sprite = sprite;
        }

        levelIcon.transform.position = new Vector2(-6 + (((number-1)%5)*3), 3 * (Mathf.FloorToInt(number/-6)));
    }
}
