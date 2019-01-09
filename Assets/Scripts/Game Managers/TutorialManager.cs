using UnityEngine;
using UnityEngine.UI;

public class TutorialManager : MonoBehaviour {

    public string[] tutorials;
    private Text tutText;
    private Button NextButton, BackButton;
    private int index = 0;

	void Start ()
    {
        tutorials = new string[10];

        NextButton = GameObject.Find("Next Button").GetComponent<Button>();
        BackButton = GameObject.Find("Back Button").GetComponent<Button>();

        BackButton.interactable = false;

        tutText = GetComponent<Text>();

        tutorials[0] = "Welcome to Glitch Garden, a Plants Vs. Zombies like home defence game!";
        tutorials[1] = "In this game, you are tasked with using your plants to defend your home from pesky animals";
        tutorials[2] = "Basics:";
        tutorials[3] = "You start by placing defenders in squares on the lawn";
        tutorials[4] = "You have a limited amount of energy to start with shown by the stars amount in the top right of the screen";
        tutorials[5] = "Each defender has a cost, labeled next to their icon in the top left of the screen";
        tutorials[6] = "All defenders have health to subdue the attacking animals as well as a <b>Special Ability</b>";
        tutorials[7] = "<b>TIP</b>: The <b>Star Trophy</b> generates stars for you to place more defenders";
        tutorials[8] = "<b>TIP</b>: The <b>Cactus</b> throws zucchini at attackers";
        tutorials[9] = "Well, I think that's enough from me, you will pick up the rest of what you need to know from playing";
        tutorials[10] = "Good Luck!";
	}
	
	void Update ()
    {
        tutText.text = tutorials[index];
	}

    public void Next()
    {
        if(index < tutorials.Length - 1)
        {
            index++;
            BackButton.interactable = true;
            if (index == tutorials.Length - 1)
            {
                NextButton.interactable = false;
            }
        }
    }
    
    public void Back()
    {
        if(index > 0)
        {
            index--;
            NextButton.interactable = true;
            if(index == 0)
            {
                BackButton.interactable = false;
            }
        }
    }
}
