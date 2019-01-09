using UnityEngine;

public class Pause : MonoBehaviour {

    private bool isPaused;
    int index;
    public Sprite[] sprites;
    public Canvas canvas;
    private SpriteRenderer rend;

	void Start ()
    {
        rend = GetComponent<SpriteRenderer>();
        canvas.enabled = false;
	}

    private void OnMouseDown()
    {
        //Toggle paused
        isPaused = !isPaused;
        index = isPaused ? 1 : 0;
        rend.sprite = sprites[index];

        //Pause and set visibility
        Time.timeScale = isPaused ? 0 : 1;
        canvas.enabled = isPaused;
    }
}
