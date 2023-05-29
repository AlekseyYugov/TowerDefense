using System;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.EventSystems;

namespace TowerDefense
{
    public class BuildSite : MonoBehaviour, IPointerDownHandler
    {
        public TowerAsset[] buldableTowers;
        public void SetBuildableTowers(TowerAsset[] towers) 
        {
            if (towers == null || towers.Length ==0)
            {
                Destroy(transform.parent.gameObject);
                
            }
            else
            {
                buldableTowers = towers;
            }
            
        }
        public static event Action<BuildSite> OnClickEvent;

        public static void HideControls()
        {
            OnClickEvent(null);
        }
        public virtual void OnPointerDown(PointerEventData eventData)
        {
            //print($"Нажато: {transform.root.name}");
            //Debug.Log("transform.root " + transform.root);
            OnClickEvent(this);
        }
    }
}

