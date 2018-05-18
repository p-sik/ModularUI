using Assets.UIBase.GraphicElements.BaseClasses;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// TODO flesh out ideas
/// how to pop out
/// how will it appear
/// where will it be positioned
/// </summary>
public class PopUpPanel : ModularPanel, IMovablePanel
{
    public Vector2 InitialPosition
    {
        get { return Vector2.zero; }
        set { }
    }

    public Vector2 FinalPosition
    {
        get { return Vector2.zero; }
        set { }
    }

    protected override void OnSkinUI()
    {
        base.OnSkinUI();
    }

    public void Appear()
    {
        throw new System.NotImplementedException();
    }

    public void Disappear()
    {
        throw new System.NotImplementedException();
    }

    public void ShowOrHideDrawer()
    {
        throw new System.NotImplementedException();
    }
}
