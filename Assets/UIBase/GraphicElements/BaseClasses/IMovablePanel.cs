using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using UnityEngine;

namespace Assets.UIBase.GraphicElements.BaseClasses
{
    public interface IMovablePanel
    {
        Vector2 InitialPosition { get; set; }
        Vector2 FinalPosition { get; set; }

        void ShowOrHideDrawer();
        void Appear();
        void Disappear();
    }
}
