using UnityEngine;
using UnityEngine.SceneManagement;

public class MusicManager : MonoBehaviour {

    public AudioClip[] levelMusicArray;
    private AudioSource audioSource;

    void Awake()
    {
        DontDestroyOnLoad(gameObject);
        Debug.Log("Audio Playing From: "+ name);
    }

    void Start ()
    {
        audioSource = GetComponent<AudioSource>();
        audioSource.volume = PlayerPrefsManager.GetMasterVolume();
        SceneManager.sceneLoaded += OnLevelLoad;

        //Loads defaults until slider changes settings
        if (SceneManager.GetActiveScene().name == "00 GlitchGardenSplash")
        {
            audioSource.clip = levelMusicArray[0];
            PlayerPrefsManager.SetMasterVolume(0.5f);
            PlayerPrefsManager.SetDifficulty(2);
            audioSource.Play();
        }
    }

    void OnLevelLoad (Scene scene, LoadSceneMode mode)
    {
        AudioClip thisLevelMusic = levelMusicArray[scene.buildIndex];
        Debug.Log("Playing clip: " + thisLevelMusic);

        if (thisLevelMusic) //If there is music playing
        {
            audioSource.clip = thisLevelMusic;
            audioSource.loop = true;
            audioSource.Play();
        }
    }
    public void SetVolume(float volume)
    {
        audioSource.volume = volume;
    }
}
