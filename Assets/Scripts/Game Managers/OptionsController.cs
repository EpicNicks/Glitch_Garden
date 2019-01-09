using UnityEngine;
using UnityEngine.UI;

public class OptionsController : MonoBehaviour {

    public Slider volumeSlider;
    public Slider difficultySlider;
    public LevelManager levelManager;
    private MusicManager musicManager;

	void Start ()
    {
        musicManager = FindObjectOfType<MusicManager>();
        volumeSlider.value = PlayerPrefsManager.GetMasterVolume();
        difficultySlider.value = PlayerPrefsManager.GetDifficulty();
    }
	
	void Update ()
    {
        musicManager.SetVolume(volumeSlider.value);
	}

    public void SaveAndExit()
    {
        PlayerPrefsManager.SetMasterVolume(volumeSlider.value);
        PlayerPrefsManager.SetDifficulty(difficultySlider.value);
        levelManager.LoadLevel("01A Start");
    }
    public void SetDefaults()
    {
        volumeSlider.value = 0.8f;
        difficultySlider.value = 2;
    }

    public void SetVolume()
    {
        musicManager.SetVolume(volumeSlider.value);
    }
}
