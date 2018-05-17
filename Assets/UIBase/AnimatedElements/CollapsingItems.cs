using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

[RequireComponent(typeof(VerticalLayoutGroup))]
public class CollapsingItems : MonoBehaviour
{
    [SerializeField]
    List<float> desiredScales = new List<float>();

    [SerializeField]
    CollapsibleElementData collapsibleElementData;

    List<GameObject> allCollapsibles = new List<GameObject>();
    List<bool> areButtonsPressed = new List<bool>();

    VerticalLayoutGroup verticalLayoutComponent;

    private void Awake()
    {
        SetupVerticalLayoutComponent();
    }

    private void SetupVerticalLayoutComponent()
    {
        verticalLayoutComponent = GetComponent<VerticalLayoutGroup>();
        verticalLayoutComponent.childForceExpandHeight = true;
        verticalLayoutComponent.childForceExpandWidth = true;
    }

    private void Start()
    {
        foreach (Transform t in transform)
        {
            IncludeCollapsibleOnly(t);
        }

        if (allCollapsibles.Count == 0)
        {
            Debug.LogWarning("allCollapsibles is empty. Did you tag the elements?");
        }
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

    private void IncludeCollapsibleOnly(Transform objectToCheckTransform)
    {
        if (objectToCheckTransform.gameObject.tag == "CollapsibleElement")
        {
            allCollapsibles.Add(objectToCheckTransform.gameObject);
            areButtonsPressed.Add(false);
        }
    }

    private IEnumerator ScaleCollapsible(int itemIndex, float desiredScale)
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
                yield return new WaitForFixedUpdate();
            }
        }
        else
        {
            while (rt.rect.height > desiredScale)
            {
                currentScale -= collapsibleElementData.ScalingFactor;
                currentScale = currentScale < desiredScale ? desiredScale : currentScale;
                rt.SetSizeWithCurrentAnchors(RectTransform.Axis.Vertical, currentScale);
                yield return new WaitForFixedUpdate();
            }
        }
    }

}
