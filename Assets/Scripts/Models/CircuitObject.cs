using UnityEngine;
using UnityEngine.UI;

namespace LogiSpark.Models
{
    public class CircuitObject : MonoBehaviour
    {
        [SerializeField] private string objectType;
        private Image image;

        public void Start()
        {
            // Récupérer l'image
            image = GetComponent<Image>();
        }

        public void Lumos()
        {
            image.sprite = Resources.Load<Sprite>("Graphics/CircuitObjects/Lumos/" + objectType);
        }
    }
}