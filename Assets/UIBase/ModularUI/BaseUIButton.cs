using UnityEngine;
using UnityEngine.UI;

/// <summary>
/// A button with a shadow underneath
/// </summary>
[RequireComponent(typeof(Button))]
[RequireComponent(typeof(Image))]
public class BaseUIButton : ModularUI {

    Image buttonImage;
    Button button;
    RectTransform buttonRectTransform;

    [SerializeField] ButtonColor buttonColor;
    [SerializeField] ButtonSize buttonSize;

    protected override void OnSkinUI()
    {
        base.OnSkinUI();
        Navigation navigationDisabler = new Navigation
        {
            mode = Navigation.Mode.None
        };

        buttonImage = GetComponent<Image>();
        button = GetComponent<Button>();
        buttonRectTransform = GetComponent<RectTransform>();

        buttonImage.type = Image.Type.Sliced;

        button.transition = Selectable.Transition.SpriteSwap;
        button.targetGraphic = buttonImage;
        button.navigation = navigationDisabler;
        buttonRectTransform.SetSizeWithCurrentAnchors(RectTransform.Axis.Horizontal, buttonSize.XDimension);
        buttonRectTransform.SetSizeWithCurrentAnchors(RectTransform.Axis.Vertical, buttonSize.YDimension);

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
