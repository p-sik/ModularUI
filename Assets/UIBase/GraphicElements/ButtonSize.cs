using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName = "Modular UI Item Data/Button Size Data")]
public class ButtonSize : ScriptableObject
{
    [SerializeField] private bool useScreenSizeX;
    [SerializeField] private bool useScreenSizeY;

    [SerializeField] private int xDimensionOrOffset;
    [SerializeField] private int yDimensionOrOffset;

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
    
}
