using UnityEngine;

public class Defender : MonoBehaviour {


    public int starCost;

    public void AddStars(int amount)
    {
        StarDisplay s = FindObjectOfType<StarDisplay>();
        s.stars += amount;
    }
}
