using Assets.UIBase.GraphicElements.BaseClasses;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BottomDrawer : ModularPanel, IMovablePanel
{
    private const int movementRate = 40;
    private bool isDrawerExtended = false;

    public Vector2 InitialPosition
    {
        get
        {
            float initialPosY = -panelDimensions.YDimension;
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
            return Vector2.zero;
        }
        set { }
    }

    protected override void OnSkinUI()
    {
        base.OnSkinUI();
        refreshInEditor = false;

        panelRectTransform.anchoredPosition = InitialPosition;
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

    private IEnumerator MoveBottomDrawer(bool shouldAppear)
    {
        float verticalPanelPosition = panelRectTransform.position.y;
        float horizontalPanelPosition = panelRectTransform.position.x;

        //IMPROVE refactor to not repeat itself
        if (shouldAppear)
        {
            while (verticalPanelPosition < FinalPosition.y)
            {
                verticalPanelPosition += movementRate;
                Vector2 positionToSet = new Vector2(horizontalPanelPosition, verticalPanelPosition);
                panelRectTransform.position = positionToSet;
                yield return new WaitForEndOfFrame();
            }
        }
        else
        {
            while (verticalPanelPosition > InitialPosition.y)
            {
                verticalPanelPosition -= movementRate;
                Vector2 positionToSet = new Vector2(horizontalPanelPosition, verticalPanelPosition);
                panelRectTransform.position = positionToSet;
                yield return new WaitForEndOfFrame();
            }
        }
    }
}
