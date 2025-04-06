using UnityEngine;

public class AudioManager : MonoBehaviour
{
    public static AudioManager Instance;

    public AudioSource musicSource;
    public AudioSource sfxSource;

    public AudioClip buttonClickClip; // Son de clic des boutons
    public AudioClip[] sfxClips; // Tableau de SFX pour autres actions

    void Awake()
    {
        if (Instance == null)
        {
            Instance = this;
            DontDestroyOnLoad(gameObject);
        }
        else
        {
            Destroy(gameObject);
        }
    }

    void Start()
    {
        float musicVol = PlayerPrefs.GetFloat("MusicVolume", 0.5f);
        float sfxVol = PlayerPrefs.GetFloat("SFXVolume", 0.5f);

        musicSource.volume = musicVol;
        sfxSource.volume = sfxVol;

        if (!musicSource.isPlaying && musicSource.clip != null)
            musicSource.Play();
    }

    public void SetMusicVolume(float volume) => musicSource.volume = volume;
    public void SetSFXVolume(float volume) => sfxSource.volume = volume;

    public float GetMusicVolume() => musicSource.volume;
    public float GetSFXVolume() => sfxSource.volume;

    // Fonction pour jouer un son de bouton spécifique
    public void PlayButtonClick()
    {
        if (buttonClickClip != null)
            sfxSource.PlayOneShot(buttonClickClip);
    }

    // Fonction pour jouer n'importe quel autre effet sonore
    public void PlaySFX(int index)
    {
        if (index >= 0 && index < sfxClips.Length)
        {
            sfxSource.PlayOneShot(sfxClips[index]);
        }
    }
}
