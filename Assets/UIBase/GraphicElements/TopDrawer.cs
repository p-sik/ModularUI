using Assets.UIBase.GraphicElements.BaseClasses;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TopDrawer : ModularPanel, IMovablePanel
{
    private bool isDrawerExtended = false;
    int movementRate = 40;

    public Vector2 InitialPosition
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

    public Vector2 FinalPosition
    {
        get
        {
            Vector2 returnedFinalPos = new Vector2(0, Screen.height - panelDimensions.YDimension);
            return returnedFinalPos;
        }
        set { }
    }

    public void Appear()
    {
        StartCoroutine(MoveBottomDrawer(true));
        isDrawerExtended = true;
    }

    public void Disappear()
    {
        StartCoroutine(MoveBottomDrawer(false));
        isDrawerExtended = false;
    }

    public void ShowOrHideDrawer()
    {
        if (!isDrawerExtended)
        {
            Appear();
            isDrawerExtended = true;
        }
        else
        {
            Disappear();
            isDrawerExtended = false;
        }
    }

    //TODO create shared drawer class for top and bottom!
    private IEnumerator MoveBottomDrawer(bool shouldAppear)
    {
        float verticalPanelPosition = panelRectTransform.position.y;
        float horizontalPanelPosition = panelRectTransform.position.x;

        if (shouldAppear)
        {
            while (verticalPanelPosition > FinalPosition.y)
            {
                verticalPanelPosition -= movementRate;
                Vector2 positionToSet = new Vector2(horizontalPanelPosition, verticalPanelPosition);
                panelRectTransform.position = positionToSet;
                yield return new WaitForEndOfFrame();
            }
        }
        else
        {
            while (verticalPanelPosition < InitialPosition.y)
            {
                verticalPanelPosition += movementRate;
                Vector2 positionToSet = new Vector2(horizontalPanelPosition, verticalPanelPosition);
                panelRectTransform.position = positionToSet;
                yield return new WaitForEndOfFrame();
            }
        }
    }
}
