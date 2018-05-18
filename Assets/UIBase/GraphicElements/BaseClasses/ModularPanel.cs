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
        protected Image panelBackground;
        protected RectTransform panelRectTransform;

        [SerializeField] protected PanelColor color;
        [SerializeField] protected PanelSize panelDimensions;

        public override void Update()
        {
            base.Update();
        }

        protected override void OnSkinUI()
        {
            base.OnSkinUI();

            RetreiveComponents();
            SetPanelColor();
            SetPanelDimensions();
        }

        protected virtual void RetreiveComponents()
        {
            panelBackground = GetComponent<Image>();
            panelRectTransform = GetComponent<RectTransform>();
        }

        private void SetPanelColor()
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

        protected virtual void SetPanelDimensions()
        {
            float xScale = panelDimensions.XDimension;
            float yScale = panelDimensions.YDimension;

            panelRectTransform.SetSizeWithCurrentAnchors(RectTransform.Axis.Horizontal, xScale);
            panelRectTransform.SetSizeWithCurrentAnchors(RectTransform.Axis.Vertical, yScale);
        }

        public enum PanelColor
        {
            Main,
            Alternate
        }
    }
}
