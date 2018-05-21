using Assets.UIBase.GraphicElements.BaseClasses;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PopUpPanel : ModularPanel, IMovablePanel
{
    [SerializeField] Transform objectToHideBehind;
    [SerializeField] Vector2 fallBackPosition;
    bool isExtended = false;

    public Vector2 InitialPosition
    {
        get
        {
            Vector2 positionToReturn;
            try
            {
                positionToReturn = objectToHideBehind.position;
            }
            catch (UnassignedReferenceException e)
            {
                Debug.LogWarning(e.Message);
                positionToReturn = fallBackPosition;
            }
            return positionToReturn;
        }
        set { }
    }

    public Vector2 FinalPosition
    {
        get { return InitialPosition; }
        set { }
    }

    protected override void OnSkinUI()
    {
        base.OnSkinUI();

        panelRectTransform.localPosition = InitialPosition;
        SetPanelSize(0, 0);
    }

    private void SetPanelSize(float xSize, float ySize)
    {
        panelRectTransform.SetSizeWithCurrentAnchors(RectTransform.Axis.Horizontal, xSize);
        panelRectTransform.SetSizeWithCurrentAnchors(RectTransform.Axis.Vertical, ySize);
    }

    public void Appear()
    {
        StartCoroutine(IncreaseSizeGradually(true));
    }

    public void Disappear()
    {
        StartCoroutine(IncreaseSizeGradually(false));
    }

    public void ShowOrHideDrawer()
    {
        if (!isExtended)
        {
            Appear();
            isExtended = true;
        }
        else
        {
            Disappear();
            isExtended = false;
        }
    }

    //IMPROVE make it not suck so much, refactor completely
    private IEnumerator IncreaseSizeGradually(bool isExtending)
    {
        float currentXDimension = panelRectTransform.rect.width;
        float currentYDimension = panelRectTransform.rect.height;
        bool isXLarger = panelDimensions.XDimension > panelDimensions.YDimension;

        if (isExtending)
        {
            if (isXLarger)
            {
                while (currentXDimension < panelDimensions.XDimension)
                {
                    if (currentYDimension < panelDimensions.YDimension)
                    {
                        currentYDimension += 20;
                    }

                    currentXDimension += 20;

                    SetPanelSize(currentXDimension, currentYDimension);

                    yield return new WaitForEndOfFrame();
                }
            }
            else
            {
                while (currentYDimension < panelDimensions.YDimension)
                {
                    if (currentXDimension < panelDimensions.XDimension)
                    {
                        currentXDimension += 20;
                    }

                    currentYDimension += 20;

                    SetPanelSize(currentXDimension, currentYDimension);

                    yield return new WaitForEndOfFrame();
                }
            }
        }
        else
        {
            if (isXLarger)
            {
                while (currentXDimension > 0)
                {
                    if (currentYDimension > 0)
                    {
                        currentYDimension -= 20;
                    }

                    currentXDimension -= 20;

                    SetPanelSize(currentXDimension, currentYDimension);

                    yield return new WaitForEndOfFrame();
                }
            }
            else
            {
                while (currentYDimension > 0)
                {
                    if (currentXDimension > 0)
                    {
                        currentXDimension -= 20;
                    }

                    currentYDimension -= 20;

                    SetPanelSize(currentXDimension, currentYDimension);

                    yield return new WaitForEndOfFrame();
                }
            }
        }
    }
}
