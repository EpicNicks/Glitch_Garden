using UnityEngine;

[RequireComponent (typeof (Attacker))]
public class Fox : MonoBehaviour {

    private Animator anim;
    private Attacker att;
    private Health hp;

    void Start()
    {
        hp = GetComponent<Health>();
        hp.hp = 75;
        anim = GetComponent<Animator>();
        att = GetComponent<Attacker>();
    }

    void OnTriggerEnter2D(Collider2D collision)
    {
        GameObject obj = collision.gameObject;
        if (!obj.GetComponent<Defender>())
        {
            return;
        }
        if (obj.GetComponent<Stone>())
        {
            anim.SetTrigger("JumpTrigger");
        }
        else
        {
            anim.SetBool("isAttacking", true);
            att.Attack(obj);
        }

        Debug.Log("Fox collided with " + collision);
    }
}
