using Assets.UIBase.GraphicElements.BaseClasses;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BottomDrawer : ModularPanel, IMovablePanel
{
    bool isDrawerExtended = false;
    Vector2 initialPosition;
    Vector2 finalPosition;
    List<GameObject> allChildObjects = new List<GameObject>(); //TODO check if still needed

    protected override void OnSkinUI()
    {
        base.OnSkinUI();
        finalPosition = SetFinalPosition();
        initialPosition = SetInitialPosition();

        panelRectTransform.anchoredPosition = initialPosition;

        foreach (Transform t in transform)
        {
            //t.gameObject.SetActive(false);
            allChildObjects.Add(t.gameObject);
        }
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
    }

    public void Disappear()
    {
        StartCoroutine(MoveBottomDrawer(false));
    }

    private IEnumerator MoveBottomDrawer(bool shouldAppear)
    {
        float verticalPanelPosition = panelRectTransform.position.y;
        float horizontalPanelPosition = panelRectTransform.position.x;

        //IMPROVE refactor to not repeat itself
        if (shouldAppear)
        {
            while (verticalPanelPosition < finalPosition.y)
            {
                verticalPanelPosition += 20;
                Vector2 positionToSet = new Vector2(horizontalPanelPosition, verticalPanelPosition);
                panelRectTransform.position = positionToSet;
                yield return new WaitForEndOfFrame();
            }
        }
        else
        {
            while (verticalPanelPosition > initialPosition.y)
            {
                verticalPanelPosition -= 20;
                Vector2 positionToSet = new Vector2(horizontalPanelPosition, verticalPanelPosition);
                panelRectTransform.position = positionToSet;
                yield return new WaitForEndOfFrame();
            }
        }
    }

    public Vector2 SetInitialPosition()
    {
        float initialPosY = -panelDimensions.YDimension;
        Vector2 initPositionVector = Vector2.zero;
        initPositionVector.y = initialPosY;

        return initPositionVector;        
    }

    public Vector2 SetFinalPosition()
    {
        return Vector2.zero;
    }
}
