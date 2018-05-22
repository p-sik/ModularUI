using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnityEngine;
using UnityEngine.UI;

namespace Assets.UIBase.GraphicElements.BaseClasses
{
    public abstract class CollapsingMenu : MonoBehaviour
    {
        protected List<GameObject> allCollapsibles = new List<GameObject>();
        protected List<bool> areButtonsPressed = new List<bool>();

        protected virtual void Awake()
        {
            foreach (Transform t in transform)
            {
                IncludeCollapsibleOnly(t);
            }

            if (allCollapsibles.Count == 0)
            {
                Debug.LogWarning("allCollapsibles is empty. Did you tag the elements?");
            }
        }

        protected virtual void Start()
        {
            
        }

        private void IncludeCollapsibleOnly(Transform objectToCheckTransform)
        {
            if (objectToCheckTransform.gameObject.tag == "CollapsibleElement")
            {
                allCollapsibles.Add(objectToCheckTransform.gameObject);
                areButtonsPressed.Add(false);
            }
        }

        abstract protected IEnumerator ScaleCollapsible(int itemIndex, float desiredScale);
        abstract public void ActOnSelected(int index);
    }
}
