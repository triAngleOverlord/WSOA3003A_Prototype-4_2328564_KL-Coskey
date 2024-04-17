using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.EventSystems;

public class fryBasket : MonoBehaviour, IDropHandler
{
    public void OnDrop(PointerEventData eventData)
    {
        if (eventData.pointerDrag != null)
        {
            //Debug.Log("drop detected");
            if (eventData.pointerDrag.transform.tag == "potato")
            {
                eventData.pointerDrag.gameObject.transform.SetParent(transform, true);
                GetComponent<frying>().frySlot = eventData.pointerDrag.gameObject;
            }
        }
    }
}
