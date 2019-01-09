using UnityEngine;

public class Projectile : MonoBehaviour {

    public float projectileSpeed;
    public float damage;
	
	void Update ()
    {
        transform.Translate(Vector3.right * projectileSpeed * Time.deltaTime);
	}

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.GetComponent<Attacker>() && collision.GetComponent<Health>())
        {
            Health hp = collision.GetComponent<Health>();
            hp.DealDamage(damage);
            Destroy(gameObject);
        }
    }
}
