using System.Collections;
using UnityEngine;

namespace Assets.UIBase.GraphicElements.BaseClasses
{
    public abstract class FullWidthDrawer : ModularPanel, IMovablePanel
    {
        bool isDrawerExtended = false;

        abstract protected int MoveRate { get; }
        abstract protected bool AppearingCondition { get; }
        abstract protected bool HidingCondition { get; }
        abstract public Vector2 InitialPosition { get; set; }
        abstract public Vector2 FinalPosition { get; set; }

        protected float HorizontalPanelPosition => panelRectTransform.position.x;
        protected float VerticalPanelPosition => panelRectTransform.position.y;

        protected override void OnSkinUI()
        {
            base.OnSkinUI();

            refreshInEditor = false;
            panelRectTransform.anchoredPosition = InitialPosition;
        }

        public void ShowOrHideDrawer()
        {
            if (!isDrawerExtended)
            {
                Appear();
                isDrawerExtended = true;
            }
            else
            {
                Disappear();
                isDrawerExtended = false;
            }
        }

        public void Appear()
        {
            StartCoroutine(MoveBottomDrawer(true));
            isDrawerExtended = true;
        }

        public void Disappear()
        {
            StartCoroutine(MoveBottomDrawer(false));
            isDrawerExtended = false;
        }

        private IEnumerator MoveBottomDrawer(bool shouldAppear)
        {
            float verticalPanelPosition = VerticalPanelPosition;
            float horizontalPanelPosition = HorizontalPanelPosition;

            if (shouldAppear)
            {
                while (AppearingCondition)
                {
                    verticalPanelPosition += MoveRate;
                    Vector2 positionToSet = new Vector2(horizontalPanelPosition, verticalPanelPosition);
                    panelRectTransform.position = positionToSet;
                    yield return new WaitForEndOfFrame();
                }
            }
            else
            {
                while (HidingCondition)
                {
                    verticalPanelPosition -= MoveRate;
                    Vector2 positionToSet = new Vector2(horizontalPanelPosition, verticalPanelPosition);
                    panelRectTransform.position = positionToSet;
                    yield return new WaitForEndOfFrame();
                }
            }
        }

    }
}
