using UnityEngine;

public class Health : MonoBehaviour {

    public float hp;

    public void DealDamage(float damage)
    {
        hp -= damage;
        if(hp < 0)
        {
            DestroyObject();
        }
    }

    void DestroyObject()
    {
        Destroy(gameObject);
    }
}
