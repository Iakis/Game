using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    private Transform trans;
    private TankHandler tank;
    private HealthHandler health;

    void Awake()
    {
        trans = GetComponent<Transform>();
        tank = GetComponent<TankHandler>();
        health = GetComponent<HealthHandler>();
        health.DeathEvent += OnDeath;
    }
	

	void FixedUpdate()
    {
        tank.Move(Input.GetAxis("Vertical"));
        tank.Turn(Input.GetAxis("Horizontal"));
    }

    void OnDeath(Damage killingBlow)
    {
        Destroy(this);
    }
}
