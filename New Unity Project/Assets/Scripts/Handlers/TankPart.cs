using System;
using System.Collections.Generic;
using UnityEngine;

[Serializable]
public struct TankStat
{
    public string name;
    public float value;
}

public class TankPart : MonoBehaviour
{
    public TankStat[] stats;
}
