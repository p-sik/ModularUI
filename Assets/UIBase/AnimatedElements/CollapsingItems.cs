using Assets.UIBase.GraphicElements.BaseClasses;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

[RequireComponent(typeof(VerticalLayoutGroup))]
public class CollapsingItems : CollapsingMenu
{
    [SerializeField] List<float> desiredScales = new List<float>();
    [SerializeField] CollapsibleElementData collapsibleElementData;
    VerticalLayoutGroup verticalLayoutComponent;

    protected override void Awake()
    {
        base.Awake();

        SetupVerticalLayoutComponent();
    }

    private void SetupVerticalLayoutComponent()
    {
        verticalLayoutComponent = GetComponent<VerticalLayoutGroup>();
        verticalLayoutComponent.childForceExpandHeight = true;
        verticalLayoutComponent.childForceExpandWidth = true;
    }

    public void ActOnSelected(int index)
    {
        float expandedScale;
        float closedScale = collapsibleElementData.DefaultClosedSize;

        try
        {
            expandedScale = desiredScales[index];
        }
        catch (System.ArgumentOutOfRangeException)
        {
            expandedScale = collapsibleElementData.DefaultScaledSize;
        }

        if (!areButtonsPressed[index])
        {
            StartCoroutine(ScaleCollapsible(index, expandedScale));
            areButtonsPressed[index] = true;
        }
        else
        {
            StartCoroutine(ScaleCollapsible(index, closedScale));
            areButtonsPressed[index] = false;
        }
    }

    protected IEnumerator ScaleCollapsible(int itemIndex, float desiredScale)
    {
        RectTransform rt = allCollapsibles[itemIndex].GetComponent<RectTransform>();
        float currentScale = rt.rect.height;

        if (currentScale < desiredScale)
        {
            while (rt.rect.height < desiredScale)
            {
                currentScale += collapsibleElementData.ScalingFactor;
                currentScale = currentScale > desiredScale ? desiredScale : currentScale;
                rt.SetSizeWithCurrentAnchors(RectTransform.Axis.Vertical, currentScale);

                yield return new WaitForEndOfFrame();
            }
        }
        else
        {
            while (rt.rect.height > desiredScale)
            {
                currentScale -= collapsibleElementData.ScalingFactor;
                currentScale = currentScale < desiredScale ? desiredScale : currentScale;
                rt.SetSizeWithCurrentAnchors(RectTransform.Axis.Vertical, currentScale);

                yield return new WaitForEndOfFrame();
            }
        }
    }

}
