using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName = "Modular UI Item Data/Radial Layout Data")]
public class RadialLayoutData : ScriptableObject
{
    [SerializeField] private float distanceFromCenter;
    [SerializeField] private float startAngle;
    [SerializeField] private float endAngle;

    public float DistanceFromCenter
    {
        get { return distanceFromCenter; }
    }
    public float StartAngle
    {
        get { return startAngle; }
    }
    public float EndAngle
    {
        get { return endAngle; }
    }
}
