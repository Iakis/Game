using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerTurret : MonoBehaviour
{
    private Transform trans;
    private TurretHandler turret;
    private GunHandler[] guns = new GunHandler[3];
    private HealthHandler health;

    void Awake()
    {
        trans = GetComponent<Transform>();
        turret = GetComponentInChildren<TurretHandler>();
        foreach(GunHandler gun in GetComponentsInChildren<GunHandler>())
            guns[(int)gun.gunIndex] = gun;

        health = GetComponent<HealthHandler>();
        health.DeathEvent += OnDeath;
    }

    Vector3 mousePos;
    void Update()
    {
        mousePos = Input.mousePosition - Camera.main.WorldToScreenPoint(trans.position);
        mousePos.z = mousePos.y;
        turret.SetTarget(mousePos);

        if (Input.GetKey(KeyCode.Mouse0) && guns[0] != null)
            guns[0].Fire();
        if (Input.GetKey(KeyCode.Mouse1) && guns[1] != null)
            guns[1].Fire();
    }

    void OnDeath(Damage killingBlow)
    {
        Destroy(this);
    }
}
