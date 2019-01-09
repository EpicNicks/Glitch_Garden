using UnityEngine;

public class Stone : MonoBehaviour {

    private Animator anim;

    private void OnTriggerStay2D(Collider2D collision)
    {
        Attacker attacker = collision.GetComponent<Attacker>();
        if (attacker)
        {
            anim.SetTrigger("onAttacked");
        }
    }

    void Start ()
    {
        anim = GetComponent<Animator>();
    }
}
