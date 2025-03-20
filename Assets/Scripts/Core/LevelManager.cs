using UnityEngine;
using UnityEngine.UI;

public class LevelManager : MonoBehaviour
{

    public Button levelButton;
    public Transform buttonContainer;
    public LevelSelectorController levelSelectorController;

    public void Start()
    {
        for(int i = 0; i < GameManager.NB_LEVELS; i++)
        {
            Button button = Instantiate(levelButton, buttonContainer);
            button.onClick.AddListener(delegate { levelSelectorController.handleClick(i+1); });
            if(GameManager.instance.levelIsLocked(i+1))
            {
                button.interactable = false;
                button.GetComponent<Image>().sprite = Resources.Load<Sprite>("Graphics/Buttons/Level" + (i+1)+"/locked");
            }else{
                button.GetComponent<Image>().sprite = Resources.Load<Sprite>("Graphics/Buttons/Level" + (i+1)+"/unlocked");
            }
        }
    }
}
