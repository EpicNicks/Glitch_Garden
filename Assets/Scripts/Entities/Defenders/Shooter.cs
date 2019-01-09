using UnityEngine;

public class Shooter : MonoBehaviour {

    public GameObject projectile, gun;
    private GameObject projectileParent;
    private Animator anim;
    private Spawner spawner;

    private void Fire()
    {
        GameObject newProjectile = Instantiate(projectile) as GameObject;
        newProjectile.transform.parent = projectileParent.transform;
        newProjectile.transform.position = gun.transform.position;
    }

	void Start ()
    {
        anim = FindObjectOfType<Animator>();
        projectileParent = GameObject.Find("Projectiles");

        if (!projectileParent)
        {
            projectileParent = new GameObject("Projectiles");
        }
	}
	
	void Update ()
    {
        if (spawner == null)
            FindLaneSpawner();
        if(anim != null)
            anim.SetBool("isAttacking", IsAttackerAhead());
	}

    bool IsAttackerAhead()
    {
        //Are there attackers in lane?
        if (spawner.transform.childCount < 0)
            return false;

        //Is an attacker in lane ahead?
        foreach(Transform child in spawner.transform)
        {
            if(child.transform.position.x > transform.position.x)
            {
                return true;
            }
        }

        //Attackers behind Shooter
        return false;
    }

    void FindLaneSpawner()
    {
        Spawner[] spawners = FindObjectsOfType<Spawner>();
        foreach (Spawner s in spawners)
        {
            if (s.transform.position.y == transform.position.y)
            {
                spawner = s;
                return;
            }
        }
        Debug.LogError("Could not find spawner in lane: " + transform.position.y);
    }
}
