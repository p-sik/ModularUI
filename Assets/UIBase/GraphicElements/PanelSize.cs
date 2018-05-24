using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName = "Modular UI Item Data/Panel Size Data")]
public class PanelSize : ScriptableObject
{
    [SerializeField] private bool useScreenSizeX;
    [SerializeField] private bool useScreenSizeY;

    [SerializeField] private int xDimension;
    [SerializeField] private int yDimension;
    [SerializeField] private int horizontalOffset;
    [SerializeField] private int verticalOffset;

    public int XDimension
    {
        get
        {
            if (useScreenSizeX)
            {
                return Screen.width - horizontalOffset * 2;
            }
            else
            {
                return xDimension;
            }

        }
    }
    public int YDimension
    {
        get
        {
            if (useScreenSizeY)
            {
                return Screen.height - verticalOffset * 2;
            }
            else
            {
                return yDimension; 
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
