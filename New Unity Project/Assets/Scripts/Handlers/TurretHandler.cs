using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TurretHandler : MonoBehaviour
{
    public float maxTurretTurnRate = 180f;
    private Transform trans, transTarget = null;
    private float destAngle = 0;

    public new Transform transform { get { return trans; } }

    void Awake()
    {
        trans = GetComponent<Transform>();
    }

    Vector3 screenPos, mousePos;
    const float pi2 = Mathf.PI * 2;
    void Update()
    {
        if (transTarget != null)
            SetTarget(transTarget.position);
        trans.rotation = Quaternion.Euler(Vector3.up * Mathf.MoveTowardsAngle(trans.eulerAngles.y, destAngle, maxTurretTurnRate * Time.deltaTime));
    }

    public void ResetTarget()
    {
        SetTarget(null);
    }

    public void SetTarget(Transform target)
    {
        transTarget = target;
        if (transTarget != null)
            SetTarget(target.position);
    }

    public void SetTarget(Vector3 target)
    {
        SetTarget(Mathf.Atan2(target.x - trans.position.x, target.z - trans.position.z) * Mathf.Rad2Deg);
    }

    public void SetTarget(float destAngle)
    {
        this.destAngle = destAngle;
    }
}
