using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;
using UnityEngine.UIElements;

public class dragFries : MonoBehaviour, IBeginDragHandler, IEndDragHandler, IDragHandler
{
    public Canvas canvas;

    public GameObject originalSlot;
    public GameObject newSlot;

    public RectTransform itemRect;
    public CanvasGroup itemCanvasGp;

    [SerializeField] private GameObject fryClone;

    public void Awake()
    {
        itemRect = GetComponent<RectTransform>();
        itemCanvasGp = GetComponent<CanvasGroup>();
        canvas = GameObject.Find("PlayerCanvas").GetComponent<Canvas>();
    }

    public void OnBeginDrag(PointerEventData eventData)
    {
        originalSlot = transform.parent.gameObject;
        //Debug.Log(originalSlot.name);
        transform.SetParent(canvas.transform, true);
        //Debug.Log(transform.name + " begun drag");
        itemCanvasGp.blocksRaycasts = false;

    }

    public void OnDrag(PointerEventData eventData)
    {

        itemRect.anchoredPosition += eventData.delta / canvas.scaleFactor;
        //Debug.Log(transform.name + " is on drag");
    }

    public void OnEndDrag(PointerEventData eventData)
    {
        if (transform.parent != canvas.transform)
        {
            //Debug.Log(transform.parent.name + " is the new parent");
            itemCanvasGp.blocksRaycasts = true;
            if (transform.parent.tag != "Untagged" && originalSlot.tag != "Pack")
            {
                var clone = Instantiate(fryClone, Vector3.zero, Quaternion.identity, originalSlot.transform);
                clone.transform.GetComponent<RectTransform>().localPosition = Vector3.zero;
            }

            if (transform.parent.tag == "Pack" && originalSlot.tag != "Untagged")
            {
                originalSlot.GetComponent<frying>().frySlot = null;
                originalSlot.GetComponent<frying>().fryState.GetComponent<RawImage>().color = Color.blue;
                originalSlot.GetComponent<frying>().time = 0;
            }
            if (originalSlot.tag == "Pack")
            {
                originalSlot.transform.GetComponent<packaging>().hasFries = false;
                Destroy(originalSlot.transform.GetChild(0).gameObject);
            }

        }
        else
        {
            //Debug.Log("Item cannot be placed into space");
            originalSlot.transform.tag = transform.tag;
            transform.SetParent(originalSlot.transform, true);
            itemRect.anchoredPosition = Vector3.zero;
            itemCanvasGp.blocksRaycasts = true;

        }

    }
}
