using UnityEngine;
using UnityEngine.UI;

[RequireComponent(typeof(Text))]
public class StarDisplay : MonoBehaviour {

    public Text text;
    public enum Status { SUCCESS, FAILURE };
    public int stars;
    public bool godMode;

    void Start ()
    {
        text = GetComponent<Text>();
        stars = 50;
	}
	
	void Update ()
    {
        text.text = stars.ToString();
        if (godMode)
            stars = 200;
	}

    public Status UseStars(int amount)
    {
        if (stars >= amount)
        {
            stars -= amount;
            return Status.SUCCESS;
        }
        return Status.FAILURE;
    }
}
