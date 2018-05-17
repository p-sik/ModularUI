using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using UnityEngine;
using UnityEngine.UI;

namespace Assets.UIBase.GraphicElements.BaseClasses
{
    [RequireComponent(typeof(Image))]
    public class ModularPanel : ModularUI
    {
        Image panelBackground;

        [SerializeField] PanelColor color;
        [SerializeField] PanelSize panelDimensions;

        protected override void OnSkinUI()
        {
            base.OnSkinUI();

            panelBackground = GetComponent<Image>();
            SetCorrectPanelColor();
        }

        private void SetCorrectPanelColor()
        {
            switch (color)
            {
                case PanelColor.Main:
                    panelBackground.sprite = skinData.PanelBackground;
                    break;
                case PanelColor.Alternate:
                    panelBackground.sprite = skinData.ContrastPanelBackground;
                    break;
            }
        }

        public enum PanelColor
        {
            Main,
            Alternate
        }
    }
}
