using UnityEngine;
using UnityEngine.SceneManagement;

public class LevelManager : MonoBehaviour {

    public float autoLoadNextLevel;
    
    void Start()
    {
        AutoLoad();
    }
    void AutoLoad()
    {
        if (SceneManager.GetActiveScene().buildIndex == 0 && autoLoadNextLevel >= 0)
        {
            Invoke("LoadNextLevel", autoLoadNextLevel);
        }
    }

    public void LoadLevel(string name)
    {
        Debug.Log("Level Load Requested For: " + name);
        SceneManager.LoadScene(name);
        //Resets the timescale from pause menu
        Time.timeScale = 1;
    }

	public void QuitRequest()
    {
		Debug.Log ("Bye:");
		Application.Quit ();
	}
	//Load Next Level using Build Settings
	public void LoadNextLevel()
    {
		SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex +1);
	}
}