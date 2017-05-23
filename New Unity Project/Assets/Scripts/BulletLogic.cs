using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletLogic : MonoBehaviour
{
    public float speed = 10, acceleration = 0, maxSpeed = 10, lifespan = 10;
    private Transform trans;
    private Rigidbody body;
    private HealthHandler health;

    void Start()
    {
        trans = GetComponent<Transform>();
        body = GetComponent<Rigidbody>();
        health = GetComponent<HealthHandler>();
        health.DeathEvent += OnDeath;
        body.velocity = trans.forward * speed;
    }

    void Update()
    {
		if (speed < maxSpeed)
		{
			speed = Mathf.Min(maxSpeed, speed + acceleration * Time.deltaTime);
			body.velocity = trans.forward * speed;
		}
        lifespan -= Time.deltaTime;
        if (lifespan <= 0)
            Destroy(gameObject);
    }

    void OnDeath(Damage killingBlow)
    {
        Destroy(gameObject);
    }

    void OnTriggerEnter(Collider coillider)
    {
        GameObject ga = coillider.gameObject;
        if (ga.tag == "Wall")
            Destroy(gameObject);
    }
}
