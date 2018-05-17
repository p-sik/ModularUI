using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

/// <summary>
/// A floating action button that grows when clicked
/// </summary>
[RequireComponent(typeof(Button))]
[RequireComponent(typeof(Image))]
public class FloatingUIButton : ModularUI
{
    const float PRESSED_SIZE = 400f;
    const float NORMAL_SIZE = 160f;

    bool isPressed = false;

    Image buttonImage;
    Button button;
    RectTransform buttonRectTransform;

    protected override void OnSkinUI()
    {
        base.OnSkinUI();
        
        RetreiveComponents();
        SetupButton();
        SetupButtonImage();
        DisableAutomaticNavigation();
    }

    private void RetreiveComponents()
    {
        buttonImage = GetComponent<Image>();
        button = GetComponent<Button>();
        buttonRectTransform = GetComponent<RectTransform>();
    }

    private void SetupButton()
    {
        button.transition = Selectable.Transition.SpriteSwap;
        button.targetGraphic = buttonImage;
        button.spriteState = skinData.FloatingButtonSpriteState;
        button.onClick.AddListener(ChangeSize);

        buttonRectTransform.pivot = Vector2.one * 0.5f;
    }

    private void SetupButtonImage()
    {
        buttonImage.type = Image.Type.Sliced;
        buttonImage.sprite = skinData.FloatingButtonSprite;
    }

    private void DisableAutomaticNavigation()
    {
        Navigation navigationDisabler = new Navigation
        {
            mode = Navigation.Mode.None
        };
        button.navigation = navigationDisabler;
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
