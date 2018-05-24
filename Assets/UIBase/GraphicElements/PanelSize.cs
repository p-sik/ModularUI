using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName = "Modular UI Item Data/Panel Size Data")]
public class PanelSize : ScriptableObject
{
    [SerializeField] private bool useScreenSizeX;
    [SerializeField] private bool useScreenSizeY;

    [SerializeField] private int xDimensionOrOffset;
    [SerializeField] private int yDimensionOrOffset;
    [SerializeField] private int horizontalOffset;
    [SerializeField] private int verticalOffset;

    public int XDimension
    {
        get
        {
            if (useScreenSizeX)
            {
                return Screen.width - xDimensionOrOffset * 2;
            }
            else
            {
                return xDimensionOrOffset;
            }

        }
    }
    public int YDimension
    {
        get
        {
            if (useScreenSizeY)
            {
                return Screen.height - yDimensionOrOffset * 2;
            }
            else
            {
                return yDimensionOrOffset; 
            }
        }
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
