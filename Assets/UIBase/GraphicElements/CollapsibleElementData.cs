using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName = "Modular UI Item Data/Collapsible Element Data")]
public class CollapsibleElementData : ScriptableObject
{
    [SerializeField] private float defaultScaledSize;

    [SerializeField] private float defaultClosedSize;

    [SerializeField] private float scalingFactor = 20;

    public float DefaultScaledSize
    {
        get { return defaultScaledSize; }
    }
    public float DefaultClosedSize
    {
        get { return defaultClosedSize; }
    }
    public float ScalingFactor
    {
        get { return scalingFactor; }
    }

}
