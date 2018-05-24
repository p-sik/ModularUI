using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName = "Modular UI Item Data/Button Size Data")]
public class ButtonSize : ScriptableObject
{
    [SerializeField] private bool useScreenSizeX;
    [SerializeField] private bool useScreenSizeY;

    [SerializeField] private int horizontalOffset;
    [SerializeField] private int verticalOffset;

    [SerializeField] private int xDimension;
    [SerializeField] private int yDimension;

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
    
}
