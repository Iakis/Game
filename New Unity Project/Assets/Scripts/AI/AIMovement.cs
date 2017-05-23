using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AIMovement : MonoBehaviour
{
    private Transform trans;
    private TankHandler tank;
    private Vector3 target = Vector3.zero;
    public Transform enemy;
    private float destAngle;
    public LayerMask layermask;

    private HealthHandler health;

    void Awake()
    {
        trans = GetComponent<Transform>();
        tank = GetComponent<TankHandler>();
        health = GetComponent<HealthHandler>();
        health.DeathEvent += OnDeath;
    }

    private bool ContainsObstacle(Vector3 dir)
    {
        RaycastHit[] hits = Physics.SphereCastAll(trans.position + trans.forward*0.1f + Vector3.up, 1f, dir, 2, layermask);
        bool didHit = false;
        foreach (RaycastHit hit in hits)
        {
            if (hit.transform.root != trans.root)
            {
                didHit = true;
                break;
            }
        }
        return didHit;
    }

    void FixedUpdate()
    {
        //target = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        //target.y = 0.3f;
        target = enemy != null ? enemy.position : Vector3.zero;

        if (target != Vector3.zero)
        {
            destAngle = Mathf.Atan2(target.x - trans.position.x, target.z - trans.position.z) * Mathf.Rad2Deg;
            if (destAngle < 0)
                destAngle += 360;
            
            bool obstacleInFront = ContainsObstacle(trans.forward);
            
            if (!obstacleInFront && Vector3.Distance(trans.position, target) > 3)
                tank.Move(1);

            float deltaAngle = Mathf.DeltaAngle(destAngle, trans.eulerAngles.y);
            Vector3 vec3DeltaAngle = Vector3.Normalize(target - trans.position);
            if (!ContainsObstacle(vec3DeltaAngle))
            {
                tank.Turn(Mathf.Sign(-deltaAngle));
            }
            else if (obstacleInFront || Mathf.Abs(deltaAngle) > 170)
            {
                bool obstacleOnRight = ContainsObstacle(Vector3.Normalize(trans.forward + trans.right)),
                     obstacleOnLeft = ContainsObstacle(Vector3.Normalize(trans.forward - trans.right));
                if (!obstacleOnRight && !obstacleOnLeft)
                    tank.Turn(Mathf.Sign(deltaAngle));
                else if (obstacleOnRight)
                    tank.Turn(-1);
                else
                    tank.Turn(1);
            }
        }
    }

    void OnDeath(Damage killingBlow)
    {
        Destroy(this);
    }

    void OnDrawGizmos()
    {
        if (trans == null)
            return;
        Gizmos.color = Color.blue;
        Gizmos.DrawSphere(trans.position + Vector3.up + trans.forward * 2, 1f);
        Gizmos.color = Color.green;
        Gizmos.DrawSphere(trans.position + Vector3.up + Vector3.Normalize(trans.forward + trans.right) * 2, 1f);
        Gizmos.DrawSphere(trans.position + Vector3.up + Vector3.Normalize(trans.forward - trans.right) * 2, 1f);
        Gizmos.color = Color.red;
        Gizmos.DrawSphere(trans.position + Vector3.up + Vector3.Normalize(target - trans.position) * 2, 1f);
    }
}
