using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AITurret : MonoBehaviour
{
    private Transform trans;
    private TurretHandler turret;
    private GunHandler[] guns = new GunHandler[3];
    private HealthHandler health;
    public Transform enemy;
    public LayerMask layermask;

    void Awake()
    {
        trans = GetComponent<Transform>();
        turret = GetComponentInChildren<TurretHandler>();
        foreach(GunHandler gun in GetComponentsInChildren<GunHandler>())
            guns[(int)gun.gunIndex] = gun;

        health = GetComponent<HealthHandler>();
        health.DeathEvent += OnDeath;
    }

    void Start()
    {
        turret.SetTarget(enemy);
    }

    RaycastHit hit;
    void Update()
    {
        if (enemy != null && Physics.Raycast(trans.position, turret.transform.forward, out hit, 100f, layermask))
        {
            if (hit.transform == enemy)
            {
                Debug.Log("shooting " + Time.deltaTime);
                float distanceToEnemy = Vector3.Distance(trans.position, enemy.position);
                if (guns[0] != null && distanceToEnemy < guns[0].effectiveDistance)
                    guns[0].Fire();

                if (guns[1] != null && distanceToEnemy < guns[1].effectiveDistance)
                    guns[1].Fire();
            }
        }
    }

    void OnDeath(Damage killingBlow)
    {
        Destroy(this);
    }

    void OnDrawGizmos()
    {
        if (turret == null || turret.transform == null || trans == null)
            return;
        Gizmos.color = Color.yellow;
        Gizmos.DrawRay(trans.position, turret.transform.forward * 100);
    }
}
