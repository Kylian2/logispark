using UnityEngine;
using UnityEngine.UI;
using System.Collections.Generic;

namespace LogiSpark.Models
{
    public class FixedGate : UIGate
    {
        public string identifier;
        [SerializeField] private string gateType;
        private Image image;

        public void Start()
        {
            // Récupérer l'image
            image = GetComponent<Image>();
        }

        public override void Lumos()
        {
            image.sprite = Resources.Load<Sprite>("Graphics/Gates/Lumos/" + gateType);
        }
    }
}