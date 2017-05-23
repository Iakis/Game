using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DamageHandler : MonoBehaviour
{
    public float damage;
    public DamageType type;

    void OnTriggerEnter(Collider coillider)
    {
        GameObject ga = coillider.gameObject;
        if (ga.transform.root == transform.root)
            return;

        HealthHandler otherHealth = ga.GetComponentInParent<HealthHandler>();
        if (otherHealth)
        {
            otherHealth.OnDamage(new Damage(transform.root, damage, type));
            if (ga.tag == "Tank" || ga.tag == "Wall")
                Destroy(gameObject);
        }
    }
}
