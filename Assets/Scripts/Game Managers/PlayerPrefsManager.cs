using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayerPrefsManager : MonoBehaviour {

    const string MASTER_VOLUME_KEY = "master_volume";
    const string DIFFICULTY_KEY = "difficulty";
    const string LEVEL_KEY = "level_unlocked";

    //Volume Block
    public static void SetMasterVolume(float volume)
    {
        if (volume >= 0.0f && volume <= 1.0f)
            PlayerPrefs.SetFloat(MASTER_VOLUME_KEY, volume);
        else
            Debug.LogError("Master Volume out of Range");
    }
    public static float GetMasterVolume()
    {
        return PlayerPrefs.GetFloat(MASTER_VOLUME_KEY);
    }

    //Level Block
    //Playable levels start at 5
    public static void UnlockLevel(int level)
    {
        if (level <= SceneManager.sceneCountInBuildSettings - 1)
            PlayerPrefs.SetInt(LEVEL_KEY + level.ToString(), 1);
        else
            Debug.LogError("Level DNE in Build Order");
    }
    public static bool IsLevelUnlocked(int level)
    {
        int levelValue = PlayerPrefs.GetInt(LEVEL_KEY + level.ToString());
        bool isLevelUnlocked = (levelValue == 1);

        if (level <= SceneManager.sceneCountInBuildSettings - 1)
        {
            return isLevelUnlocked;
        }  
        else
        {
            Debug.LogError("Level DNE in Build Order");
            return false;
        }
    }

    //Difficulty Block
    public static void SetDifficulty(float difficulty)
    {
        if(difficulty >= 1f && difficulty <= 3f)
        {
            PlayerPrefs.SetFloat(DIFFICULTY_KEY, difficulty);
            print("Is Set");
        }
        else
        {
            Debug.LogError("Difficulty out of Range");
        }
    }
    public static float GetDifficulty()
    {
            return PlayerPrefs.GetFloat(DIFFICULTY_KEY);
    }
}