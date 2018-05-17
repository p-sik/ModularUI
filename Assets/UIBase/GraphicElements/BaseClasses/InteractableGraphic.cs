using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using UnityEngine;
using UnityEngine.UI;

namespace Assets.UIBase.GraphicElements.BaseClasses
{
    [RequireComponent(typeof(Button))]
    [RequireComponent(typeof(Image))]
    public class InteractableGraphic : ModularUI
    {
        protected Image buttonImage;
        protected Button button;
        protected RectTransform buttonRectTransform;

        protected override void OnSkinUI()
        {
            base.OnSkinUI();

            RetreiveComponents();
            SetupButton();
            SetupButtonImage();
            DisableAutomaticNavigation();
        }

        protected void RetreiveComponents()
        {
            buttonImage = GetComponent<Image>();
            button = GetComponent<Button>();
            buttonRectTransform = GetComponent<RectTransform>();
        }

        protected virtual void SetupButton()
        {
            button.transition = Selectable.Transition.SpriteSwap;
            button.targetGraphic = buttonImage;
            buttonRectTransform.pivot = Vector2.one * 0.5f;
        }

        protected virtual void SetupButtonImage()
        {
            buttonImage.type = Image.Type.Sliced;            
        }

        protected void DisableAutomaticNavigation()
        {
            Navigation navigationDisabler = new Navigation
            {
                mode = Navigation.Mode.None
            };
            button.navigation = navigationDisabler;
        }
    }
}
