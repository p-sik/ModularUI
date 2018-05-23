using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName = "Modular UI Item Data/Radial Layout Data")]
public class RadialLayoutData : ScriptableObject
{
    [SerializeField] private float distanceFromCenter;

    [SerializeField]
    [Range(0, 360)]
    private float startAngle;

    [SerializeField]
    [Range(0, 360)]
    private float endAngle;

    [SerializeField]
    [Range(0, 360)]
    private float angleOffset;

    public float DistanceFromCenter
    {
        get
        {
            if (distanceFromCenter % 10 != 0)
            {
                distanceFromCenter = Mathf.Round(distanceFromCenter / 10);
                distanceFromCenter *= 10;
            }
            return distanceFromCenter;
        }
    }
    public float StartAngle
    {
        get { return startAngle; }
    }
    public float EndAngle
    {
        get { return endAngle; }
    }
    public float AngleOffset
    {
        get { return angleOffset; }
    }
}
