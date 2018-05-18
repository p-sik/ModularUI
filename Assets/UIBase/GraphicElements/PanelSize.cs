using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName = "Modular UI Item Data/Panel Size Data")]
public class PanelSize : ScriptableObject
{
    [SerializeField] private int xDimension;
    [SerializeField] private int yDimension;

    public int XDimension
    {
        get { return xDimension; }
    }
    public int YDimension
    {
        get { return yDimension; }
    }
}
