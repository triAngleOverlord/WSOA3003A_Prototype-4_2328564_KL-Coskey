using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class dragFries : MonoBehaviour, IBeginDragHandler, IEndDragHandler, IDragHandler
{
    public Canvas canvas;

    public GameObject originalSlot;
    public GameObject newSlot;

    public RectTransform itemRect;
    public CanvasGroup itemCanvasGp;

    [SerializeField] private GameObject fryClone;
    public fryType type;
    public int potatoType;
    public int INT;

    private Image potato;

    public enum fryType
    {
        shoestring, waffle, curly, crinkle
    }
    public void Awake()
    {
        itemRect = GetComponent<RectTransform>();
        itemCanvasGp = GetComponent<CanvasGroup>();
        canvas = GameObject.Find("PlayerCanvas").GetComponent<Canvas>();
        potato = GetComponent<Image>();

        typeOfFry();
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
            if (originalSlot.tag == "Untagged")
            {
                var clone = Instantiate(fryClone, Vector3.zero, Quaternion.identity, originalSlot.transform);
                clone.transform.GetComponent<RectTransform>().localPosition = Vector3.zero;
            }

            if (originalSlot.tag == "fry")
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

    public int typeOfFry()
    {
        switch (type)
        {
            case fryType.shoestring:potatoType = 0; 
                break;
            case fryType.waffle: potatoType = 3;
                break;
            case fryType.curly:potatoType = 6;
                break;
            case fryType.crinkle:potatoType= 9; 
                break;
        }
        return potatoType;
    }

    public void Update()
    {
        if (INT == potatoType + 1)
            potato.color = Color.white;
        else if(INT == potatoType + 2)
            potato.color = Color.red;
        else
            potato.color = Color.blue;
        
    }
}
