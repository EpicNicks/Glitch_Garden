using UnityEngine;
using System.Collections;
using UnityEngine.EventSystems;

public class Dragger : MonoBehaviour {

    private Dragger[] draggers;
    public static GameObject selectedDefender;
    public GameObject defenderPrefab;

	void Start ()
    {
        draggers = FindObjectsOfType<Dragger>();
	}

    private void OnMouseOver()
    {
        foreach (Dragger d in draggers)
        {
            d.GetComponent<SpriteRenderer>().color = Color.black;
        }
        GetComponent<SpriteRenderer>().color = Color.white;
        selectedDefender = defenderPrefab;
    }
}
