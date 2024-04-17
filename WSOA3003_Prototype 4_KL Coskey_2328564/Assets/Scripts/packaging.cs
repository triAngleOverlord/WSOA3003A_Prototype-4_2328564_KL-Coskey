using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class packaging : MonoBehaviour, IDropHandler
{
    public bool hasFries;
    public GameObject submitToNext;
    public GameObject packClone;
    public void OnDrop(PointerEventData eventData)
    {
        if (eventData.pointerDrag != null)
        {
            if (eventData.pointerDrag.transform.tag == "potato")
            {
                eventData.pointerDrag.gameObject.transform.SetParent(transform, true);
                hasFries = true;
                var clone = Instantiate(submitToNext, Vector3.zero, Quaternion.identity, transform);
                clone.transform.GetComponent<RectTransform>().localPosition = Vector3.zero;
            }
        }
    }
    public void cloning()
    {
        var clone = Instantiate(packClone, transform.position, Quaternion.identity, transform.parent.transform);
        //clone.transform.GetComponent<RectTransform>().localPosition = Vector3.zero;
    }
}
