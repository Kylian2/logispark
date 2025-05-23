using UnityEngine;
using UnityEngine.UI;
using TMPro;

namespace LogiSpark.Models
{
    public class ButtonInventoryGate : MonoBehaviour
    {
        private bool locked = false;
        private bool selected = false;
        private string gateType;
        private TextMeshProUGUI quantityText;
        private LevelManager levelManager;
        private Button button;
        private GameObject borderObject;
        
        public void Initialize(string gateType, TextMeshProUGUI quantityText, LevelManager levelManager)
        {
            this.gateType = gateType;
            this.quantityText = quantityText;
            this.levelManager = levelManager;
            
            // Récupérer le composant Button
            button = GetComponent<Button>();
            
            // Ajouter un écouteur sur ce bouton
            button.onClick.AddListener(OnButtonClick);

            // Créer une bordure jaune qui sera utilisée lorsque la porte sera sélectionnée
            AddYellowBorder(2.5f);

            // Récupérer la bordure et la désactiver
            borderObject = transform.Find("YellowBorder").gameObject;
            borderObject.SetActive(false);
        }
        
        private void OnButtonClick()
        {
            if(!locked)
            {
                // Changer la sélection du bouton
                selected = !selected;

                if(selected)
                {
                    levelManager.activeLevel.DeselectGates(gateType);
                    levelManager.activeLevel.SetGateType(gateType);
                }
                else
                {
                    levelManager.activeLevel.SetGateType("");
                }

                // Activer ou désactiver la bordure en fonction
                borderObject.SetActive(selected);
                }
        }

        public void IncrementQuantity()
        {
            int quantity = int.Parse(quantityText.text);
            quantity += 1;
            quantityText.text = quantity.ToString();

            if(quantity == 1)
            {
                locked = false;
            }
        }

        public void DecrementQuantity()
        {
            int quantity = int.Parse(quantityText.text);
            quantity -= 1;
            quantityText.text = quantity.ToString();

            if(quantity == 0)
            {
                locked = true;
            }        
        }

        public void AddYellowBorder(float borderThickness)
        {
            // Créer un nouvel objet pour la bordure
            GameObject borderObject = new GameObject("YellowBorder");
            
            // Le rendre enfant du GameObject actuel
            borderObject.transform.SetParent(transform, false);
            
            // S'assurer qu'il est positionné derrière l'image principale
            borderObject.transform.SetAsFirstSibling();
            
            // Ajouter un RectTransform
            RectTransform borderRect = borderObject.AddComponent<RectTransform>();
            
            // Configurer le RectTransform pour qu'il soit légèrement plus grand que l'image principale
            RectTransform parentRect = GetComponent<RectTransform>();
            borderRect.anchorMin = Vector2.zero;
            borderRect.anchorMax = Vector2.one;
            borderRect.offsetMin = new Vector2(-borderThickness, -borderThickness);
            borderRect.offsetMax = new Vector2(borderThickness, borderThickness);
            
            // Ajouter un composant Image pour la bordure
            Image borderImage = borderObject.AddComponent<Image>();
            borderImage.color = Color.yellow;
            
            // Utiliser un sprite avec un centre transparent ou configurer l'image pour qu'elle ne dessine que la bordure
            // Option 1: Utiliser un sprite de type "Border"
            // borderImage.sprite = Resources.Load<Sprite>("UI/BorderSprite");
            // borderImage.type = Image.Type.Sliced;
            
            // Option 2: Créer quatre images pour les côtés de la bordure
            CreateBorderSide(borderObject, "TopBorder", new Vector2(0, 1-borderThickness/parentRect.rect.height), Vector2.one, new Vector2(0, 0), new Vector2(0, 0));
            CreateBorderSide(borderObject, "BottomBorder", Vector2.zero, new Vector2(1, borderThickness/parentRect.rect.height), new Vector2(0, 0), new Vector2(0, 0));
            CreateBorderSide(borderObject, "LeftBorder", new Vector2(0, borderThickness/parentRect.rect.height), new Vector2(borderThickness/parentRect.rect.width, 1-borderThickness/parentRect.rect.height), new Vector2(0, 0), new Vector2(0, 0));
            CreateBorderSide(borderObject, "RightBorder", new Vector2(1-borderThickness/parentRect.rect.width, borderThickness/parentRect.rect.height), new Vector2(1, 1-borderThickness/parentRect.rect.height), new Vector2(0, 0), new Vector2(0, 0));
            
            // Détruire l'image principale de la bordure car nous utilisons maintenant les côtés
            Destroy(borderImage);
            
            // S'assurer que la bordure n'intercepte pas les clics
            foreach (Image img in borderObject.GetComponentsInChildren<Image>())
            {
                img.raycastTarget = false;
            }
        }

        private void CreateBorderSide(GameObject parent, string name, Vector2 anchorMin, Vector2 anchorMax, Vector2 offsetMin, Vector2 offsetMax)
        {
            GameObject side = new GameObject(name);
            side.transform.SetParent(parent.transform, false);
            
            RectTransform rectTransform = side.AddComponent<RectTransform>();
            rectTransform.anchorMin = anchorMin;
            rectTransform.anchorMax = anchorMax;
            rectTransform.offsetMin = offsetMin;
            rectTransform.offsetMax = offsetMax;
            
            Image image = side.AddComponent<Image>();
            image.color = Color.yellow;
        }

        public void Deselect()
        {
            selected = false;
            borderObject.SetActive(false);
        }

    }
}