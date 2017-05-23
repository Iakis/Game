using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HealthHandler : MonoBehaviour
{
    public bool showHealthBar = false;
    public float MaxHealth = 100;
    public float Health;
    private GameObject healthBar;

    void Start()
    {
        Health = MaxHealth;

        if (showHealthBar)
        {
            healthBar = Instantiate(Resources.Load("Health Bar", typeof(GameObject))) as GameObject;
            healthBar.GetComponent<HealthBar>().target = this;
        }
    }

    public delegate float DamageDel(Damage damage);
    public delegate void DeathDel(Damage damage);
    public delegate float HealDel(float amount);
    public event DamageDel DamageEvent;
    public event DeathDel DeathEvent;
    public event HealDel HealEvent;

    public void OnDamage(Damage damage)
    {
        if (Health <= 0 || damage.Source == transform.root)
            return;
        if (DamageEvent != null)
            Health -= DamageEvent(damage);
        else
            Health -= damage.Amount;

        if (Health <= 0)
        {
            Destroy(healthBar);
            if (DeathEvent != null)
                DeathEvent(damage);
        }
    }

    public void OnHeal(float heal)
    {
        if (HealEvent != null)
            Health += HealEvent(heal);
        else
            Health += heal;
        if (Health > MaxHealth)
            Health = MaxHealth;
    }

    public float GetPercentageLeft()
    {
        return Health / MaxHealth;
    }
}
