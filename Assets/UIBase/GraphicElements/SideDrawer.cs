using Assets.UIBase.GraphicElements.BaseClasses;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SideDrawer : ModularPanel, IMovablePanel
{
    private const int movementRate = 20;
    private bool isDrawerExtended = false;

    public Vector2 InitialPosition
    {
        get
        {
            float initialPosX = -panelDimensions.XDimension + panelDimensions.HorizontalOffset;
            float initialPosY = panelDimensions.VerticalOffset;
            Vector2 initPositionVector = new Vector2
            {
                x = initialPosX,
                y = initialPosY
            };

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
        StartCoroutine(DisplayDrawer(true));
        isDrawerExtended = true;
    }

    public void Disappear()
    {
        StartCoroutine(DisplayDrawer(false));
        isDrawerExtended = false;
    }

    private IEnumerator DisplayDrawer(bool shouldAppear)
    {
        float verticalPanelPosition = panelRectTransform.position.y;
        float horizontalPanelPosition = panelRectTransform.position.x;

        if (shouldAppear)
        {
            while (horizontalPanelPosition < FinalPosition.x)
            {
                horizontalPanelPosition += movementRate;
                Vector2 positionToSet = new Vector2(horizontalPanelPosition, verticalPanelPosition);
                panelRectTransform.position = positionToSet;
                yield return new WaitForEndOfFrame();
            }
        }
        else
        {
            while (horizontalPanelPosition > InitialPosition.x)
            {
                horizontalPanelPosition -= movementRate;
                Vector2 positionToSet = new Vector2(horizontalPanelPosition, verticalPanelPosition);
                panelRectTransform.position = positionToSet;
                yield return new WaitForEndOfFrame();
            }
        }
    }
}
