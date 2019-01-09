using UnityEngine;

public class DefenderSpawner : MonoBehaviour {

    public Camera myCamera;
    private GameObject parent;
    public float distanceFromCamera;

    private void Start()
    {
        //If parent is not null find defenders. If parent is null, Instantiate it as a new GameObject
        parent = GameObject.Find("Defenders") ?? new GameObject("Defenders");
    }

    private void OnMouseDown()
    {
        StarDisplay starDisplay = FindObjectOfType<StarDisplay>();
        Defender defender = Dragger.selectedDefender.GetComponent<Defender>();
        int defenderCost = defender.starCost;

        if (starDisplay.UseStars(defenderCost) == StarDisplay.Status.SUCCESS)
        {
            GameObject newDefender = Instantiate(Dragger.selectedDefender, SnapToGrid(CalculateWorldPointOfMouseClick()), Quaternion.identity) as GameObject;
            newDefender.transform.parent = parent.transform;
        }
    }

    Vector2 CalculateWorldPointOfMouseClick()
    {
        Vector3 triplet = new Vector3(Input.mousePosition.x, Input.mousePosition.y, distanceFromCamera);
        Vector2 worldPos = Camera.main.ScreenToWorldPoint(triplet);

        return worldPos;
    }

    Vector3 SnapToGrid(Vector3 rawWorldPos)
    {
        int roundX = Mathf.RoundToInt(rawWorldPos.x);
        int roundY = Mathf.RoundToInt(rawWorldPos.y);
        return new Vector3(roundX, roundY, 1);
    }
}
