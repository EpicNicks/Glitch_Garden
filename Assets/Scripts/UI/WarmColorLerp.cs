using UnityEngine.UI;
using UnityEngine;

public class WarmColorLerp : MonoBehaviour {

    public float duration;
    private GameTimer gt;
    private Text text;

	void Start ()
    {
        gt = FindObjectOfType<GameTimer>();
        text = GetComponent<Text>();
        text.color = Color.red;
	}
	
	void Update ()
    {
        ColorLerp();
        GameState();
    }

    private void GameState()
    {
        if(gt.gameTimer < 0)
        {
            text.text = "Get Ready";
            text.color = Color.black;
        }
        else if(gt.gameTimer > 0 && gt.gameTimer < gt.winTimer)
        {
            text.text = "Charging Pest Attack\n   Countermeasures";
        }
        else if (gt.gameTimer >= gt.winTimer)
        {
            text.text = "Countermeasures Deployed!";
            text.color = Color.green;
        }
    }

    private void ColorLerp()
    {
        if(gt.gameTimer < gt.winTimer && gt.gameTimer > 0)
        {
            float lerp = Mathf.PingPong(Time.time, duration) / duration;
            float g = Mathf.Lerp(0.0f, 1.0f, Mathf.SmoothStep(0.0f, 1.0f, lerp));
            Color textColor = new Color(1, g, 0);
            text.color = textColor;
        }
    }
}
