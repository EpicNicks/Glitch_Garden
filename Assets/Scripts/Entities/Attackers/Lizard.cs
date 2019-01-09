using UnityEngine;

[RequireComponent(typeof(Attacker))]
public class Lizard : MonoBehaviour
{
    private Health hp;
    private Animator anim;
    private Attacker att;

    void Start()
    {
        hp = GetComponent<Health>();
        hp.hp = 100;
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
        else
        {
            anim.SetBool("isAttacking", true);
            att.Attack(obj);
        }

        Debug.Log("Fox collided with " + collision);
    }
}
