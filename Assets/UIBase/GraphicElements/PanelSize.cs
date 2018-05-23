using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName = "Modular UI Item Data/Panel Size Data")]
public class PanelSize : ScriptableObject
{
    [SerializeField] private int xDimension;
    [SerializeField] private int yDimension;
    [SerializeField] private int verticalOffset;
    [SerializeField] private int horizontalOffset;

    public int XDimension
    {
        get { return xDimension; }
    }
    public int YDimension
    {
        get { return yDimension; }
    }
    public int VerticalOffset
    {
        get { return verticalOffset; }
    }
    public int HorizontalOffset
    {
        get { return horizontalOffset; }
    }
}
