using Assets.UIBase.GraphicElements.BaseClasses;
using UnityEngine;
using UnityEngine.UI;

/// <summary>
/// A button with a shadow underneath
/// </summary>
public class BaseUIButton : InteractableGraphic
{
    [SerializeField] ButtonColor buttonColor;
    [SerializeField] ButtonSize buttonSize;

    protected override void OnSkinUI()
    {
        base.OnSkinUI();   
    }

    protected override void SetupButton()
    {
        base.SetupButton();

        SetCorrectButtonSkin();
        SetButtonDimensions();
    }

    private void SetButtonDimensions()
    {
        buttonRectTransform.SetSizeWithCurrentAnchors(RectTransform.Axis.Horizontal, buttonSize.XDimension);
        buttonRectTransform.SetSizeWithCurrentAnchors(RectTransform.Axis.Vertical, buttonSize.YDimension);
    }

    private void SetCorrectButtonSkin()
    {
        switch (buttonColor)
        {
            case ButtonColor.Main:
                buttonImage.sprite = skinData.ButtonSprite;
                button.spriteState = skinData.ButtonSpriteState;
                break;
            case ButtonColor.Alternate:
                buttonImage.sprite = skinData.AlternateSprite;
                button.spriteState = skinData.AlternateSpriteState;
                break;
        }
    }

    public enum ButtonColor
    {
        Main,
        Alternate
    }
}
