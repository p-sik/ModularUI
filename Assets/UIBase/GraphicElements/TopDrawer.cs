using Assets.UIBase.GraphicElements.BaseClasses;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TopDrawer : FullWidthDrawer
{
    protected override bool AppearingCondition
    {
        get
        {
            return VerticalPanelPosition > FinalPosition.y;
        }
    }

    protected override bool HidingCondition
    {
        get
        {
            return VerticalPanelPosition < InitialPosition.y;
        }
    }

    protected override int MoveRate
    {
        get
        {
            return -40;
        }
    }

    public override Vector2 InitialPosition
    {
        get
        {
            float initialPosY = Screen.height + panelDimensions.VerticalOffset;
            Vector2 initPositionVector = Vector2.zero;
            initPositionVector.y = initialPosY;

            return initPositionVector;
        }
        set { }
    }

    public override Vector2 FinalPosition
    {
        get
        {
            Vector2 returnedFinalPos = new Vector2(0, Screen.height - panelDimensions.YDimension);
            return returnedFinalPos;
        }
        set { }
    }
}
