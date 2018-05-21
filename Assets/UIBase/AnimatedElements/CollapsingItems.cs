using Assets.UIBase.GraphicElements.BaseClasses;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CollapsingItems : CollapsingMenu
{
    [SerializeField]
    List<float> desiredScales = new List<float>();

    public override void ActOnSelected(int index)
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

    public override IEnumerator ScaleCollapsible(int itemIndex, float desiredScale)
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
