using UnityEngine;
using UnityEngine.UI;

public class LerpAlpha : MonoBehaviour {

    public float duration;
    float alpha;
    public float r = 113.0f/255, g = 75.0f/255, b = 2.0f/255;
    Text colorText;
    Color textColor;

    void LerpAlphaText()
    {
        float lerp = Mathf.PingPong(Time.time, duration) / duration;
        alpha = Mathf.Lerp(0.0f, 1.0f, Mathf.SmoothStep(0.0f, 1.0f, lerp));
        textColor = new Color(r, g, b, alpha);
        colorText.color = textColor;
    }
    void Start()
    {
        colorText = GetComponent<Text>();
    }

    void Update ()
    {
        LerpAlphaText();
    }
}
