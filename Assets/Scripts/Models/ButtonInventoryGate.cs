using UnityEngine;
using UnityEngine.UI;
using TMPro;

namespace LogiSpark.Models
{
    public class ButtonInventoryGate : MonoBehaviour
    {
        private bool selected = false;
        private TextMeshProUGUI quantityText;
        private ActiveLevel activeLevel;
        private Button button;
        
        public void Initialize(TextMeshProUGUI quantityText, ActiveLevel activeLevel)
        {
            this.quantityText = quantityText;
            this.activeLevel = activeLevel;
            
            // Récupérer le bouton sur ce même GameObject
            button = GetComponent<Button>();
            
            if (button != null)
            {
                button.onClick.AddListener(OnButtonClick);
            }
        }
        
        private void OnButtonClick()
        {
            Debug.Log("Mathieu : OnButtonClick()");

            selected = !selected;

            //Debug.Log("Gate : " + (selected ? "selected" : "deselected"));
        }
    }
}