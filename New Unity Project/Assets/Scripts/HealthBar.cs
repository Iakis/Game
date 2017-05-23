using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using UnityEngine;

public class HealthBar : MonoBehaviour
{
    public HealthHandler target;
    public Texture2D borderTex, healthTex, backTex;
    private Transform trans, targetTrans;
    private Rect borderPos = new Rect(0, 0, 80, 24), backPos, staticPos;

    void Start()
    {
        trans = GetComponent<Transform>();
        targetTrans = target.GetComponent<Transform>();
        backPos = staticPos = borderPos;
    }

    private float GetHealthCurve()
    {
        float x = target.GetPercentageLeft();
        return (37.5119f * x * x * x * x * x * x * x) - (131.325f * x * x * x * x * x * x) + (175.497f * x * x * x * x * x) - (110.257f * x * x * x * x) + (32.7484f * x * x * x) - (4.37973f * x * x) + (1.15f * x);
    }

    void Update()
    {
        trans.position = Camera.main.WorldToScreenPoint(targetTrans.position);
        borderPos.x = backPos.x = trans.position.x - 40;
        borderPos.y = backPos.y = Screen.height - trans.position.y - 40;
        backPos.width = target.GetPercentageLeft() > 0 ? Mathf.Max(4, Mathf.CeilToInt(GetHealthCurve() * 80)) : 0;
    }

    void OnGUI()
    {
        GUI.DrawTexture(borderPos, backTex);
        Color oldColor = GUI.color;
        GUI.BeginGroup(backPos);
        float hue = 0.33f, sat = 0.8f;
        if (target.GetPercentageLeft() < 0.2f)
            hue = 0.025f;
        else if (target.GetPercentageLeft() < 0.3f)
            hue = 0.025f + ((10f * target.GetPercentageLeft() - 2f) * (0.18f - 0.025f));
        else if (target.GetPercentageLeft() < 0.6f)
        {
            hue = 0.18f;
            sat = 1f;
        }
        else if (target.GetPercentageLeft() < 0.7f)
        {
            hue = 0.18f + ((10f * target.GetPercentageLeft() - 6f) * (0.33f - 0.18f));
            sat = 1f + ((10f * target.GetPercentageLeft() - 6f) * (0.8f - 1f));
        }
        GUI.color = Color.HSVToRGB(hue, sat, 1);
        GUI.DrawTexture(staticPos, healthTex);
        GUI.EndGroup();
        GUI.color = oldColor;
        GUI.DrawTexture(borderPos, borderTex);
    }
}
