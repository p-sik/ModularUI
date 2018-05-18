using UnityEngine;
using UnityEngine.UI;

[CreateAssetMenu(menuName = "Modular UI Item Data/Modular UI Data")]
public class ModularUIData : ScriptableObject {

    [Header("Button")]
    public Sprite ButtonSprite;
    public SpriteState ButtonSpriteState;
    [Space]
    public Sprite AlternateSprite;
    public SpriteState AlternateSpriteState;

    [Header("Floating action button")]
    public Sprite FloatingButtonSprite;
    public SpriteState FloatingButtonSpriteState;

    [Header("Base element")]
    public Sprite MainElement;
    public Sprite MainElementWithShadow;

    [Header("Moving panel")]
    public Sprite PanelBackground;
    public Sprite ContrastPanelBackground;

}
