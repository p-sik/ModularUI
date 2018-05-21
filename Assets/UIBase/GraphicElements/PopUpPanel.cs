using Assets.UIBase.GraphicElements.BaseClasses;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PopUpPanel : ModularPanel, IMovablePanel
{
    //IMPROVE make the settings prettier (use ScriptableObj?)
    [SerializeField] bool useObjectForPosition;
    [SerializeField] Transform objectToHideBehind;
    [SerializeField] Vector2 fallbackPosition;
    bool isExtended = false;

    public Vector2 InitialPosition
    {
        get
        {
            Vector2 positionToReturn;
            if (useObjectForPosition)
            {
                try
                {
                    positionToReturn = objectToHideBehind.localPosition;
                }
                catch (UnassignedReferenceException e)
                {
                    Debug.LogWarning($"No Transform was added to Object To Hide Behind: " + e.Message);
                    positionToReturn = fallbackPosition;
                }
            }
            else
            {
                positionToReturn = fallbackPosition;
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

    private IEnumerator IncreaseSizeGradually(bool isExtending)
    {
        float currentXDimension = panelRectTransform.rect.width;
        float currentYDimension = panelRectTransform.rect.height;
        int desiredYDimension = panelDimensions.YDimension;
        int desiredXDimension = panelDimensions.XDimension;
        bool isXLarger = desiredXDimension > desiredYDimension;
        const int changeRate = 40;

        if (isExtending && isXLarger)
        {
            while (currentXDimension < desiredXDimension)
            {
                currentYDimension = currentYDimension < desiredYDimension ? currentYDimension + changeRate : currentYDimension;
                currentXDimension += changeRate;
                SetPanelSize(currentXDimension, currentYDimension);

                yield return new WaitForEndOfFrame();
            }
        }
        else if (isExtending && !isXLarger)
        {
            while (currentYDimension < desiredYDimension)
            {
                currentXDimension = currentXDimension < desiredXDimension ? currentXDimension + changeRate : currentXDimension;
                currentYDimension += changeRate;
                SetPanelSize(currentXDimension, currentYDimension);

                yield return new WaitForEndOfFrame();
            }
        }
        else if (!isExtending && isXLarger)
        {
            while (currentXDimension > 0)
            {
                bool doesYNeedChanging = currentYDimension > 0 && currentYDimension >= currentXDimension;
                currentYDimension = doesYNeedChanging ? currentYDimension - changeRate : currentYDimension;
                currentXDimension -= changeRate;
                SetPanelSize(currentXDimension, currentYDimension);

                yield return new WaitForEndOfFrame();
            }
        }
        else if (!isExtending && !isXLarger)
        {
            while (currentYDimension > 0)
            {
                bool doesXNeedChanging = currentXDimension > 0 && currentXDimension >= currentYDimension;
                currentXDimension = doesXNeedChanging ? currentXDimension - changeRate : currentXDimension;
                currentYDimension -= changeRate;
                SetPanelSize(currentXDimension, currentYDimension);

                yield return new WaitForEndOfFrame();
            }
        }
    }
}
