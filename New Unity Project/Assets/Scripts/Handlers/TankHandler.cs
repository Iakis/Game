using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TankHandler : MonoBehaviour
{
    private Transform trans;
    private Rigidbody body;
    private HealthHandler health;
    private float deathTimer, speed, turning;

    public GameObject DeathParticles;

	void Awake()
    {
        trans = GetComponent<Transform>();
        body = GetComponent<Rigidbody>();
        health = GetComponent<HealthHandler>();
        health.DeathEvent += OnDeath;

        Dictionary<string, float> stats = new Dictionary<string, float>() { { "armor", 0 }, { "mass", 0 }, { "speed", 0 }, { "turning", 0 } };
        foreach(TankPart part in GetComponentsInChildren<TankPart>())
        {
            foreach(TankStat stat in part.stats)
            {
                if (stats.ContainsKey(stat.name))
                    stats[stat.name] += stat.value;
            }
        }
        health.MaxHealth = stats["armor"];
        body.mass = stats["mass"];
        speed = stats["speed"];
        turning = stats["turning"];
    }
	
    void Update()
    {
        if (deathTimer > 0)
        {
            deathTimer -= Time.deltaTime;
            if (deathTimer <= 0)
                Destroy(gameObject);
        }
    }

    public void Move(float multiplier)
    {
        body.AddForce(trans.forward * speed * multiplier, ForceMode.Force);
    }

    public void Turn(float multiplier)
    {
        body.AddTorque(trans.up * turning * multiplier, ForceMode.Force);
    }

    void OnDeath(Damage killingBlow)
    {
        Instantiate(DeathParticles, trans.position + Vector3.up, Quaternion.Euler(270, 0,0 ));
        deathTimer = 2f;
    }
}
