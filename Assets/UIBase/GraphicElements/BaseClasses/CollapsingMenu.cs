﻿using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnityEngine;
using UnityEngine.UI;

namespace Assets.UIBase.GraphicElements.BaseClasses
{
    [RequireComponent(typeof(VerticalLayoutGroup))]
    public abstract class CollapsingMenu : MonoBehaviour
    {
        [SerializeField]
        protected CollapsibleElementData collapsibleElementData;
        protected List<GameObject> allCollapsibles = new List<GameObject>();
        protected List<bool> areButtonsPressed = new List<bool>();
        protected VerticalLayoutGroup verticalLayoutComponent;

        public virtual void Awake()
        {
            SetupVerticalLayoutComponent();
        }

        public virtual void Start()
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

        private void SetupVerticalLayoutComponent()
        {
            verticalLayoutComponent = GetComponent<VerticalLayoutGroup>();
            verticalLayoutComponent.childForceExpandHeight = true;
            verticalLayoutComponent.childForceExpandWidth = true;
        }

        private void IncludeCollapsibleOnly(Transform objectToCheckTransform)
        {
            if (objectToCheckTransform.gameObject.tag == "CollapsibleElement")
            {
                allCollapsibles.Add(objectToCheckTransform.gameObject);
                areButtonsPressed.Add(false);
            }
        }

        abstract public IEnumerator ScaleCollapsible(int itemIndex, float desiredScale);
        abstract public void ActOnSelected(int index);
    }
}