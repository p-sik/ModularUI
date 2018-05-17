using Assets.UIBase.GraphicElements.BaseClasses;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

/// <summary>
/// A floating action button that grows when clicked
/// </summary>
public class FloatingUIButton : InteractableGraphic
{
    const float PRESSED_SIZE = 400f;
    const float NORMAL_SIZE = 160f;

    bool isPressed = false;

    protected override void SetupButton()
    {
        base.SetupButton();
        button.onClick.AddListener(ChangeSize);
    }

    private void ChangeSize()
    {
        if (!isPressed)
        {
            StartCoroutine(AnimateScaling(PRESSED_SIZE, true));
            isPressed = true;
        }
        else
        {
            StartCoroutine(AnimateScaling(NORMAL_SIZE, false));
            isPressed = false;
        }
    }

    private IEnumerator AnimateScaling(float maxScale, bool scalingUp)
    {
        RectTransform rectTransform = GetComponent<RectTransform>();
        float currScale = rectTransform.rect.width;

        if (scalingUp)
        {
            while (currScale < maxScale)
            {
                currScale += 20;
                ScaleElements(rectTransform, currScale);
                yield return new WaitForFixedUpdate();                
            }
        }
        else
        {
            while (currScale > maxScale)
            {
                currScale -= 20;
                ScaleElements(rectTransform, currScale);
                yield return new WaitForFixedUpdate();                
            }
        }
    }

    private void ScaleElements(RectTransform rectTransform, float scale)
    {
        rectTransform.SetSizeWithCurrentAnchors(RectTransform.Axis.Horizontal, scale);
        rectTransform.SetSizeWithCurrentAnchors(RectTransform.Axis.Vertical, scale);
    }

}
