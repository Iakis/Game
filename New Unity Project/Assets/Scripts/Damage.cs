using UnityEngine;

public enum DamageType { bullet, explosion }
public struct Damage
{
    public float Amount;
    public DamageType Type;
    public Transform Source;
    public Damage(Transform source, float amount, DamageType type)
    {
        Source = source;
        Amount = amount;
        Type = type;
    }
}
