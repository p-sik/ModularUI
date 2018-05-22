using Assets.UIBase.GraphicElements.BaseClasses;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RadialCollapsingItems : CollapsingMenu
{
    [SerializeField] RadialLayoutData layoutData;

    private int numberOfElements;
    private float[] elementAngles;
    private Vector2[] elementSizes;

    protected override void Awake()
    {
        base.Awake();

        numberOfElements = allCollapsibles.Count;
        elementAngles = SetElementAngles();
        elementSizes = GetElementSizes();
        SetInitialSizeAndPositionOfChildren();
    }

    private float[] SetElementAngles()
    {
        float[] returnedAngles = new float[numberOfElements];
        float angleBetweenElements = 360f / numberOfElements * Mathf.Deg2Rad;

        for (int angleIndex = 0; angleIndex < numberOfElements; angleIndex++)
        {
            returnedAngles[angleIndex] = angleBetweenElements * angleIndex;
        }

        return returnedAngles;
    }

    private Vector2[] GetElementSizes()
    {
        Vector2[] returnedSizes = new Vector2[numberOfElements];

        for (int sizeIndex = 0; sizeIndex < numberOfElements; sizeIndex++)
        {
            RectTransform rt = allCollapsibles[sizeIndex].transform as RectTransform;
            returnedSizes[sizeIndex] = rt.rect.size;
        }

        return returnedSizes;
    }


    private void SetInitialSizeAndPositionOfChildren()
    {
        foreach (var collapsible in allCollapsibles)
        {
            RectTransform rt = collapsible.transform as RectTransform;
            rt.SetSizeWithCurrentAnchors(RectTransform.Axis.Horizontal, 0);
            rt.SetSizeWithCurrentAnchors(RectTransform.Axis.Vertical, 0);
        }
    }

    public override void ActOnSelected(int index)
    {
        SetRadialLayout();
    }

    protected override IEnumerator ScaleCollapsible(int itemIndex, float desiredScale)
    {
        while (true)
        {
            yield return new WaitForEndOfFrame();
        }
    }

    private void SetRadialLayout()
    {
        for (int radialElementIndex = 0; radialElementIndex < numberOfElements; radialElementIndex++)
        {
            RectTransform rt = allCollapsibles[radialElementIndex].transform as RectTransform;
            rt.localPosition = new Vector2(Mathf.Cos(elementAngles[radialElementIndex]) * layoutData.DistanceFromCenter, Mathf.Sin(elementAngles[radialElementIndex]) * layoutData.DistanceFromCenter);
            rt.SetSizeWithCurrentAnchors(RectTransform.Axis.Horizontal, elementSizes[radialElementIndex].x);
            rt.SetSizeWithCurrentAnchors(RectTransform.Axis.Vertical, elementSizes[radialElementIndex].y);
        }
    }
}
