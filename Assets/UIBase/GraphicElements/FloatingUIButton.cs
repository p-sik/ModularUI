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
    [SerializeField] FloatingActionButtonSize buttonSize;

    bool isPressed = false;

    protected override void OnSkinUI()
    {
        base.OnSkinUI();
    }

    protected override void SetupButton()
    {
        base.SetupButton();

        ScaleElements(buttonSize.NormalSize);
        button.spriteState = skinData.FloatingButtonSpriteState;
        button.onClick.AddListener(ChangeSize);
    }

    protected override void SetupButtonImage()
    {
        base.SetupButtonImage();
        buttonImage.sprite = skinData.FloatingButtonSprite;
    }

    private void ChangeSize()
    {
        if (!isPressed)
        {
            StartCoroutine(AnimateScaling(buttonSize.PressedSize, true));
            isPressed = true;
        }
        else
        {
            StartCoroutine(AnimateScaling(buttonSize.NormalSize, false));
            isPressed = false;
        }
    }

    private IEnumerator AnimateScaling(float maxScale, bool scalingUp)
    {
        float currScale = buttonRectTransform.rect.width;

        if (scalingUp)
        {
            while (currScale < maxScale)
            {
                currScale += 20;
                ScaleElements(currScale);
                yield return new WaitForFixedUpdate();                
            }
        }
        else
        {
            while (currScale > maxScale)
            {
                currScale -= 20;
                ScaleElements(currScale);
                yield return new WaitForFixedUpdate();                
            }
        }
    }

    private void ScaleElements(float scale)
    {
        buttonRectTransform.SetSizeWithCurrentAnchors(RectTransform.Axis.Horizontal, scale);
        buttonRectTransform.SetSizeWithCurrentAnchors(RectTransform.Axis.Vertical, scale);
    }

}
