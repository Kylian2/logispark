using UnityEngine;
using UnityEngine.UI;

public class AudioSettingsModal : MonoBehaviour
{
    public GameObject modalSettings;
    public Button openButton;
    public Slider musicSlider;
    public Slider sfxSlider;
    public Button closeButton;
    public Button[] allButtons;

    
    void Start()
    {
        musicSlider.value = AudioManager.Instance.GetMusicVolume();
        sfxSlider.value = AudioManager.Instance.GetSFXVolume();

        if (closeButton != null)
        {
            closeButton.onClick.AddListener(() =>
            {
                AudioManager.Instance.PlayButtonClick();
                CloseModal();
            });
        }

        openButton.onClick.AddListener(() =>
        {
            AudioManager.Instance.PlayButtonClick();
            OpenModal();
        });
    }

    public void OpenModal()
    {
        
        foreach (var btn in allButtons)
        {
            if (!this.modalSettings.transform.IsChildOf(btn.transform))
            {
                btn.interactable = false;
            }
        }

        this.modalSettings.SetActive(true);

        this.musicSlider.value = AudioManager.Instance.GetMusicVolume();
        this.sfxSlider.value = AudioManager.Instance.GetSFXVolume();
    }

    public void CloseModal()
    {
        AudioManager.Instance.SetMusicVolume(musicSlider.value);
        AudioManager.Instance.SetSFXVolume(sfxSlider.value);

        foreach (var btn in allButtons)
        {
            if (btn != null)
                btn.interactable = true;
        }

        modalSettings.SetActive(false);
    }
}
