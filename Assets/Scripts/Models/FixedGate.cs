using UnityEngine;
using UnityEngine.UI;

namespace LogiSpark.Models
{
    public class FixedGate : UIGate
    {
        public string identifier;
        [SerializeField] private string gateType;
        [SerializeField] private LevelManager levelManager;
        private Image image;

        public void Start()
        {
            // Récupérer l'image
            image = GetComponent<Image>();

            LogicGate gate = null; 
            switch (gateType)
            {
                case "gate_or":
                    gate = new GateOR();
                    break;
                case "gate_xor":
                    gate = new GateXOR();
                    break;
                case "gate_and":
                    gate = new GateAND();
                    break;
                case "gate_not":
                    gate = new GateNOT();
                    break;
                case "gate_nand":
                    gate = new GateNAND();
                    break;
            }

            // On place la porte sur l'arbre
            foreach (var tree in levelManager.activeLevel.GetEmplacements()[identifier])
            {
                tree.SetData(gate);
            }
        }

        public override void Lumos()
        {
            image.sprite = Resources.Load<Sprite>("Graphics/Gates/Lumos/" + gateType);
        }
    }
}