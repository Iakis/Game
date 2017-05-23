using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum GunType { Machinegun, Shotgn, Cannon }
public enum GunIndex { Primary, Secondary, Alt }
public class GunHandler : MonoBehaviour
{
    public GameObject bullet;
    public Transform[] guns;
    private int curGun = 0;
    public bool doesSpin = true;
    public float turretSpinMax = 3, shotsPerSecond = 20, bulletsPerShot = 1, spread = 10, bulletSpeed = 10, bulletAcceleration = 0, bulletMaxSpeed = 10, bulletDamage = 0.5f, bulletHealth = 0.5f, effectiveDistance = 20f;
    public GunType gunType;
    public GunIndex gunIndex;
    private Transform trans;
    private bool fire = false;

    void Awake()
    {
        trans = GetComponent<Transform>();
        if (guns.Length == 0)
            guns = new Transform[] { trans };
    }

    public void Fire()
    {
        fire = true;
    }

    float turretSpin = 0, turretSpinAcc = 0, shootTimer = 0;
    const float pi2 = Mathf.PI * 2;
    void LateUpdate()
    {
        if (fire)
        {
            if (turretSpin < turretSpinMax)
                turretSpin += Mathf.Min(turretSpinMax - turretSpin, Time.deltaTime);
        }
        else
        {
            if (turretSpin > 0)
                turretSpin -= Time.deltaTime * turretSpinMax * 2;
            else if (turretSpin <= 0)
                turretSpin = 0;
        }

        if (shootTimer > 0)
            shootTimer -= Time.deltaTime * shotsPerSecond * (turretSpinMax == 0 ? 1 : turretSpin / turretSpinMax);

        if (turretSpin > 0 || (fire && turretSpinMax == 0))
        {
            for (; shootTimer <= 0; shootTimer++)
            {
                for (int i = 0; i < bulletsPerShot; i++)
                    Shoot(bullet, guns[curGun], Random.Range(-spread, spread), bulletSpeed, bulletAcceleration, bulletMaxSpeed, bulletHealth, bulletDamage);
                curGun++;
                if (curGun >= guns.Length)
                    curGun = 0;
            }
        }

        if (doesSpin)
        {
            foreach(Transform gun in guns)
                gun.Rotate(Vector3.up, turretSpin * pi2);
        }

        fire = false;
    }

    private void Shoot(GameObject projectile, Transform gun, float angleOffset, float speed, float acceleration, float maxSpeed, float health, float damage)
    {
        Quaternion rot = Quaternion.Euler(0, gun.parent.eulerAngles.y + angleOffset, 0);
        GameObject shot = Instantiate(projectile, gun.position + gun.parent.forward * 0.5f, rot);
        shot.transform.parent = gun.root;
        BulletLogic bLog = shot.GetComponent<BulletLogic>();
		HealthHandler bHp = shot.GetComponent<HealthHandler>();
        DamageHandler bDam = shot.GetComponent<DamageHandler>();
        bLog.speed = speed;
		bLog.acceleration = acceleration;
		bLog.maxSpeed = maxSpeed;
		bHp.MaxHealth = bHp.Health = health;
        bDam.damage = damage;
    }
}
