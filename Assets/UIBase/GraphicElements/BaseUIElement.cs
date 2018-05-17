using UnityEngine;
using UnityEngine.UI;

/// <summary>
/// Base element with only a static sprite (headers, footers, panels)
/// </summary>
[RequireComponent(typeof(Image))]
public class BaseUIElement : ModularUI {

    public bool hasShadow;

    Image elementImage;

    protected override void OnSkinUI()
    {
        base.OnSkinUI();

        elementImage = GetComponent<Image>();
        elementImage.type = Image.Type.Sliced;

        if (hasShadow)
        {
            elementImage.sprite = skinData.MainElementWithShadow; 
        }
        else
        {
            elementImage.sprite = skinData.MainElement;
        }
    }

}
