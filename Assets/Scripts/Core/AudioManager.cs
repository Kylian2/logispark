using UnityEngine;
using UnityEngine.SceneManagement;

public class AudioManager : MonoBehaviour
{
    public static AudioManager Instance;

    [Header("Sources")]
    public AudioSource musicSource;
    public AudioSource sfxSource;

    [Header("Musiques")]
    public AudioClip[] musicClips; 

    [Header("Effets Sonores")]
    public AudioClip buttonClickClip;
    public AudioClip[] sfxClips;

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

        SceneManager.sceneLoaded += OnSceneLoaded;
        PlaySceneMusic(SceneManager.GetActiveScene().name); 
    }

    void OnSceneLoaded(Scene scene, LoadSceneMode mode)
    {
        PlaySceneMusic(scene.name);
    }

    public void SetMusicVolume(float volume)
    {
        musicSource.volume = volume;
        PlayerPrefs.SetFloat("MusicVolume", volume);
    }

    public void SetSFXVolume(float volume)
    {
        sfxSource.volume = volume;
        PlayerPrefs.SetFloat("SFXVolume", volume);
    }

    public float GetMusicVolume() => musicSource.volume;
    public float GetSFXVolume() => sfxSource.volume;

    public void PlayButtonClick()
    {
        if (buttonClickClip != null)
            sfxSource.PlayOneShot(buttonClickClip);
    }

    public void PlaySFX(int index)
    {
        if (index >= 0 && index < sfxClips.Length)
            sfxSource.PlayOneShot(sfxClips[index]);
    }

    private void PlaySceneMusic(string sceneName)
    {
        switch (sceneName)
        {
            case "Menu":
                PlayMusicByIndex(0);
                break;
            case "LevelSelect":
                PlayMusicByIndex(1);
                break;
            case "Level_1":
                PlayMusicByIndex(2);
                break;
            case "Level_2":
                PlayMusicByIndex(3);
                break;
            case "Level_3":
                PlayMusicByIndex(4);
                break;
            case "Level_4":
                PlayMusicByIndex(5);
                break;
            case "Level_5":
                PlayMusicByIndex(6);
                break;
            default:
                PlayMusicByIndex(0);
                break;
        }
    }

    private void PlayMusicByIndex(int index)
    {
        if (index >= 0 && index < musicClips.Length)
        {
            if (musicSource.clip != musicClips[index])
            {
                musicSource.clip = musicClips[index];
                musicSource.Play();
            }
        }
    }
}
