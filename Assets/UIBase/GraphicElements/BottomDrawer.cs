using Assets.UIBase.GraphicElements.BaseClasses;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BottomDrawer : FullWidthDrawer
{
    protected override bool AppearingCondition
    {
        get
        {
            return VerticalPanelPosition < FinalPosition.y;
        }
    }

    protected override bool HidingCondition
    {
        get
        {
            return VerticalPanelPosition > InitialPosition.y;
        }
    }

    protected override int MoveRate
    {
        get
        {
            return 40;
        }
    }

    public override Vector2 InitialPosition
    {
        get
        {
            float initialPosY = -panelDimensions.YDimension + panelDimensions.VerticalOffset;
            Vector2 initPositionVector = Vector2.zero;
            initPositionVector.y = initialPosY;

            return initPositionVector;
        }
        set
        {

        }
    }

    public override Vector2 FinalPosition
    {
        get
        {
            return Vector2.zero;
        }
        set { }
    }
}
