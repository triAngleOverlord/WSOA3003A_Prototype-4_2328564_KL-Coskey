using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class nextStation : MonoBehaviour
{
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        transform.SetAsLastSibling();
    }

    public void toSpice()
    {
        if (transform.parent.parent.name == "Frying Panel")
        {
            transform.parent.GetComponent<packaging>().cloning();
            transform.parent.transform.SetParent(GameObject.Find("SpicePanel").transform, true);
            transform.parent.GetChild(0).GetComponent<CanvasGroup>().blocksRaycasts = false;
        }
        else if (transform.parent.parent.name == "SpicePanel")
        {
            transform.parent.transform.SetParent(GameObject.Find("SaucePanel").transform, true);
        }
        else if (transform.parent.parent.name == "SaucePanel")
        {
            transform.parent.transform.SetParent(GameObject.Find("OrderPanel").transform, true);
            transform.parent.parent.SetAsLastSibling();
            GameObject.FindGameObjectWithTag("NPC").GetComponent<OrderingSystem>().judging();
            gameObject.SetActive(false);
        }
        Debug.Log("click");
        
        
    }
}
