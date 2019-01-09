using UnityEngine;

[RequireComponent (typeof (Rigidbody2D))]
public class Attacker : MonoBehaviour {

    [Tooltip("States how often a given attacker will spawn")]
    public float seenEverySeconds;
    private float walkSpeed;
    private GameTimer gt;
    private GameObject currentTarget;
    private Animator anim;

	void Start ()
    {
        anim = GetComponent<Animator>();
        gt = FindObjectOfType<GameTimer>();
	}
	
	void Update ()
    {
        transform.Translate(Vector3.left * walkSpeed * Time.deltaTime);
        if (!currentTarget)
        {
            anim.SetBool("isAttacking", false);
        }
        //On DefendersWin
        Explode();
	}

    void OnTriggerEnter2D(Collider2D collision)
    {
        Debug.Log(name + " trigger enter");
    }

    public void SetWalkSpeed(float walkSpeed)
    {
        this.walkSpeed = walkSpeed;
    }

    public void StrikeCurrentTarget(float damage)
    {
        Debug.Log(name + " has attacked for " + damage + " damage");
        if (currentTarget)
        {
            Health hp = currentTarget.GetComponent<Health>();
            if (hp)
            {
                hp.DealDamage(damage);
            }
        }
    }

    public void Attack(GameObject gObj)
    {
        currentTarget = gObj;
    }

    public void Explode()
    {
        if (gt.gameTimer > gt.winTimer)
        {
            anim.SetTrigger("DefendersWin");
        }
    }
}
