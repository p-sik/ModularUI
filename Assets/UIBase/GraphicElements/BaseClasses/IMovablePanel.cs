using UnityEngine;

namespace Assets.UIBase.GraphicElements.BaseClasses
{
    public interface IMovablePanel
    {
        Vector2 InitialPosition { get; set; }
        Vector2 FinalPosition { get; set; }

        /// <summary>
        /// Method to be called by buttons/events
        /// </summary>
        void ShowOrHideDrawer();

        void Appear();
        void Disappear();
    }
}
