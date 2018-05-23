using Assets.UIBase.GraphicElements.BaseClasses;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class RadialCollapsingItems : CollapsingMenu
{
    [SerializeField] RadialLayoutData layoutData;

    private int numberOfElements;
    private float[] elementAngles;
    private Vector2[] elementSizes;
    private bool isShowing = false;
    private bool isRunning = false;

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
        float totalAngle = layoutData.EndAngle - layoutData.StartAngle;
        totalAngle = CheckAngle(totalAngle);
        float angleOffset = layoutData.AngleOffset * Mathf.Deg2Rad;
        float angleBetweenElements = SetAngleBetweenElements(totalAngle);

        for (int angleIndex = 0; angleIndex < numberOfElements; angleIndex++)
        {
            returnedAngles[angleIndex] = angleBetweenElements * angleIndex;
            returnedAngles[angleIndex] += angleOffset;
        }

        return returnedAngles;
    }

    private static float CheckAngle(float totalAngle)
    {
        if (totalAngle <= 0)
        {
            Debug.Assert(totalAngle > 0, $"Provided angle range is { totalAngle }. Reverting to default value of 360°");
            totalAngle = 360f;
        }

        return totalAngle;
    }

    private float SetAngleBetweenElements(float totalAngle)
    {
        float returnedTotalAngle;

        int dividingFactor = totalAngle != 360 ?  (numberOfElements - 1) : numberOfElements;
        returnedTotalAngle = totalAngle / dividingFactor * Mathf.Deg2Rad;

        return returnedTotalAngle;
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

    public void ShowOrHideElements()
    {
        if (!isRunning && !isShowing)
        {
            isShowing = true;
            StartCoroutine(LayoutChange(isShowing));

        }
        else if (!isRunning && isShowing)
        {
            isShowing = false;
            StartCoroutine(LayoutChange(isShowing));
        }
    }

    protected IEnumerator LayoutChange(bool isExtending)
    {
        bool someElementsStillNeedChange = true;
        isRunning = true;

        while (someElementsStillNeedChange)
        {
            bool[] numCompletedLayoutChanges = new bool[numberOfElements];

            for (int radialElement = 0; radialElement < numberOfElements; radialElement++)
            {
                float desiredDistance = isExtending ? layoutData.DistanceFromCenter : 0;
                float desiredElementAngle = elementAngles[radialElement];
                Vector2 desiredScale = isExtending ? elementSizes[radialElement] : Vector2.zero;
                RectTransform rt = allCollapsibles[radialElement].transform as RectTransform;

                ChangeElementSize(rt, desiredScale);
                numCompletedLayoutChanges[radialElement] = PositionElement(rt, desiredDistance, desiredElementAngle);
            }

            if (numCompletedLayoutChanges.All(x => x == true))
            {
                someElementsStillNeedChange = false;
            }

            yield return new WaitForEndOfFrame();
        }
        isRunning = false;
    }

    private void ChangeElementSize(RectTransform elementTransform, Vector2 endSize)
    {
        Vector2 elementSize = elementTransform.rect.size;
        bool isXEndSize = elementSize.x == endSize.x;
        bool isYEndSize = elementSize.y == endSize.y;
        int changeRate = endSize == Vector2.zero ? -5 : 5;

        if (isXEndSize && isYEndSize)
        {
            return;
        }

        elementSize.x = !isXEndSize ? elementSize.x + changeRate : elementSize.x;
        elementSize.y = !isYEndSize ? elementSize.y + changeRate : elementSize.y;

        elementTransform.SetSizeWithCurrentAnchors(RectTransform.Axis.Horizontal, elementSize.x);
        elementTransform.SetSizeWithCurrentAnchors(RectTransform.Axis.Vertical, elementSize.y);
    }

    private bool PositionElement(RectTransform elementTransform, float goalDistance, float angle)
    {
        float currentX = elementTransform.localPosition.x;
        float currentY = elementTransform.localPosition.y;
        float goalXPosition = goalDistance * Mathf.Cos(angle);
        float goalYPosition = goalDistance * Mathf.Sin(angle);
        int changeRate = goalDistance == 0 ? -10 : 10;

        float epsilon = 0.0001f;
        bool reachedX = Mathf.Abs(currentX - goalXPosition) < epsilon;
        bool reachedY = Mathf.Abs(currentY - goalYPosition) < epsilon;

        if (reachedX && reachedY)
        {
            return true;
        }

        currentX = !reachedX ? currentX + changeRate * Mathf.Cos(angle) : currentX;
        currentY = !reachedY ? currentY + changeRate * Mathf.Sin(angle) : currentY;
        Vector2 newPosition = new Vector2(currentX, currentY);
        elementTransform.localPosition = newPosition;

        return false;
    }
}
