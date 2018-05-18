using UnityEngine;
using UnityEditor;

public class UIBaseInstance : Editor {

    #region MenuItems
    [MenuItem("GameObject/Modular UI/Base Button", priority = 0)]
    public static void AddButton()
    {
        Create("BaseButton");
    }

    [MenuItem("GameObject/Modular UI/Floating Action Button", priority = 0)]
    public static void AddFloatingButton()
    {
        Create("FloatingButton");
    }

    [MenuItem("GameObject/Modular UI/Bottom Drawer", priority = 0)]
    public static void AddBottomDrawer()
    {
        Create("BottomDrawer");
    }
    #endregion

    static GameObject clickedObject;

    private static GameObject Create(string objectName)
    {
        GameObject instance = Instantiate(Resources.Load<GameObject>(objectName));
        instance.name = objectName;

        clickedObject = UnityEditor.Selection.activeObject as GameObject;

        if (clickedObject != null)
        {
            instance.transform.SetParent(clickedObject.transform, false);
        }

        return instance;
    }
}
