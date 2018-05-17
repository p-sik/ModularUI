using UnityEditor;
using UnityEngine;
using UnityEngine.UI;

[ExecuteInEditMode()]
public class ModularUI : MonoBehaviour {

    public ModularUIData skinData;
    [SerializeField]
    [Tooltip("Uncheck if running the element in Update breaks it's functionality")]
    bool refreshInEditor = true;

    protected virtual void OnSkinUI()
    {
        
    }

    public virtual void Awake()
    {
        OnSkinUI();
    }

    public virtual void Update()
    {
        if (Application.isEditor && refreshInEditor)
        {
            OnSkinUI();
        }
    }
}
