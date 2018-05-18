using Assets.UIBase.GraphicElements.BaseClasses;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SideDrawer : ModularPanel, IMovablePanel
{
    private const int movementRate = 20;
    private bool isDrawerExtended = false;
    Vector2 initialPosition;
    Vector2 finalPosition;

    protected override void OnSkinUI()
    {
        base.OnSkinUI();
        refreshInEditor = false;
        finalPosition = SetFinalPosition();
        initialPosition = SetInitialPosition();

        panelRectTransform.anchoredPosition = initialPosition;
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
    }

    public void Disappear()
    {
        StartCoroutine(DisplayDrawer(false));
    }

    public Vector2 SetFinalPosition()
    {
        return Vector2.zero;
    }

    private IEnumerator DisplayDrawer(bool shouldAppear)
    {
        float verticalPanelPosition = panelRectTransform.position.y;
        float horizontalPanelPosition = panelRectTransform.position.x;

        if (shouldAppear)
        {
            while (horizontalPanelPosition < finalPosition.x)
            {
                horizontalPanelPosition += movementRate;
                Vector2 positionToSet = new Vector2(horizontalPanelPosition, verticalPanelPosition);
                panelRectTransform.position = positionToSet;
                yield return new WaitForEndOfFrame();
            }
        }
        else
        {
            while (horizontalPanelPosition > initialPosition.x)
            {
                horizontalPanelPosition -= movementRate;
                Vector2 positionToSet = new Vector2(horizontalPanelPosition, verticalPanelPosition);
                panelRectTransform.position = positionToSet;
                yield return new WaitForEndOfFrame();
            }
        }
    }

    public Vector2 SetInitialPosition()
    {
        float initialPosX = -panelDimensions.XDimension;
        Vector2 initPositionVector = Vector2.zero;
        initPositionVector.x = initialPosX;

        return initPositionVector;
    }
}
