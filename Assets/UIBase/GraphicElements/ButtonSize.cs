using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName = "Modular UI Item Data/Button Size Data")]
public class ButtonSize : ScriptableObject
{
    [SerializeField] private int xDimension;
    [SerializeField] private int yDimension;

    public int YDimension
    {
        get { return yDimension; }
    }
    public int XDimension
    {
        get { return xDimension; }
    }
}
