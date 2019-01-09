using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class GameTimer : MonoBehaviour {

    public float winTimer;

    private LevelManager levelManager;
    private Slider slider;
    private Spawner spawner;
    private AudioSource audioSource;
    private GameObject winLabel;
    private LoseCollider loseCollider;
    //Time since level loaded - Starting Spawn Delay
    public float gameTimer;
    private bool isEndOfLevel = false;

	void Start ()
    {
        spawner = FindObjectOfType<Spawner>();
        slider = GetComponent<Slider>();
        audioSource = GetComponent<AudioSource>();
        levelManager = FindObjectOfType<LevelManager>();
        loseCollider = FindObjectOfType<LoseCollider>();
        winLabel = GameObject.Find("Win Label");
        winLabel.transform.localScale = new Vector3(0, 0);
        winLabel.SetActive(false);
        SetWinTimer();
    }

    private void SetWinTimer()
    {
        if (PlayerPrefsManager.GetDifficulty() == 1)
            winTimer = 45;
        else if (PlayerPrefsManager.GetDifficulty() == 2)
            winTimer = 60;
        else if (PlayerPrefsManager.GetDifficulty() == 3)
            winTimer = 75;
        else
        {
            winTimer = 60;
        }
    }

    void Update ()
    {
        SpawnTimer();
    }

    private void SpawnTimer()
    {
        gameTimer = Time.timeSinceLevelLoad - spawner.startingSpawnDelay;
            slider.value = gameTimer >= 0 ? gameTimer / winTimer : 0;

        if (gameTimer > winTimer)
        {
            FinalizeLevel();
        }
    }

    private void FinalizeLevel()
    {
        winLabel.SetActive(true);
        winLabel.layer = 10;
        //Makes the label lerp from (0, 0) to (1, 1)
        float lerpSize = 1 / audioSource.clip.length / 60;
        if (winLabel.transform.localScale.x < 1)
            winLabel.transform.localScale += new Vector3(lerpSize, lerpSize) / 60;
        //Unlocks the next level
        Debug.Log(SceneManager.GetActiveScene().buildIndex);
        PlayerPrefsManager.UnlockLevel(SceneManager.GetActiveScene().buildIndex + 1);

        if (!isEndOfLevel)
        {
            loseCollider.enabled = false;
            audioSource.Play();
            Invoke("LoadNextLevel", audioSource.clip.length);
            isEndOfLevel = true;
        }
    }

    void LoadNextLevel()
    {
        levelManager.LoadLevel("03A Win");
    }
}