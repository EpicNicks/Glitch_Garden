using UnityEngine;

public class Spawner : MonoBehaviour {

    public Animator[] anims;
    public GameObject[] attackerPrefabs;
    public GameTimer gt;
    public float startingSpawnDelay;

	void Start ()
    {
        anims = GetComponentsInChildren<Animator>();
        gt = FindObjectOfType<GameTimer>();
        startingSpawnDelay = 30;
	}
	

	void Update () {
		foreach(GameObject thisAttacker in attackerPrefabs)
        {
            if (IsTimeToSpawn(thisAttacker))
            {
                Spawn(thisAttacker);
            }
        }
	}

    bool IsTimeToSpawn(GameObject attacker)
    {
        //Gives player time to setup
        if (Time.timeSinceLevelLoad < startingSpawnDelay)
            return false;

        Attacker att = attacker.GetComponent<Attacker>();
        float spawnDelay = att.seenEverySeconds;
        // 1 / howLongUntilNextSpawnInSeconds * difficulty mult / softener
        float spawnsPerSecond = 1 / spawnDelay;

        if(Time.deltaTime > spawnDelay)
        {
            Debug.LogWarning("Spawn rate capped by framerate");
        }

        float threshold = spawnsPerSecond * Time.deltaTime / 5 * gt.winTimer / (gt.winTimer - gt.gameTimer + 10);
        return Random.value < threshold;
    }

    void Spawn(GameObject attacker)
    {
        if (gt.gameTimer < gt.winTimer)
        {
            GameObject a = Instantiate(attacker) as GameObject;
            a.transform.parent = transform;
            a.transform.position = transform.position;
        }
    }
}
