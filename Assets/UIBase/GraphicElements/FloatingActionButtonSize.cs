using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName = "Modular UI Item Data/Floating Action Button Data")]
public class FloatingActionButtonSize : ScriptableObject {

    [SerializeField] private float pressedSize;
    [SerializeField] private float normalSize;    

    public float PressedSize
    {
        get { return pressedSize; }
    }
    public float NormalSize
    {
        get { return normalSize; }
    }
}
