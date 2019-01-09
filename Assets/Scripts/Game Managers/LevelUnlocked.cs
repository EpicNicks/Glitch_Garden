using UnityEngine;
using UnityEngine.UI;

//Sets level buttons to locked or unlocked depending on the PlayerPrefManager
public class LevelUnlocked : MonoBehaviour {

    public Button[] buttons;

	void Start () {
        for(int index = 0; index < buttons.Length; index++)
            buttons[index].interactable = PlayerPrefsManager.IsLevelUnlocked(index + 6);
	}
}
