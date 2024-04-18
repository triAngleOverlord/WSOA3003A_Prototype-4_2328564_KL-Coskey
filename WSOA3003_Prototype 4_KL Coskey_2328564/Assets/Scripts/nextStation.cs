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
        
    }

    public void toSpice()
    {
        if (transform.parent.parent.name == "Frying Panel")
        {
            transform.parent.GetComponent<packaging>().cloning();
            transform.parent.transform.SetParent(GameObject.Find("SpicePanel").transform, true);
            transform.parent.GetChild(0).GetComponent<CanvasGroup>().blocksRaycasts = false;
        }
        else if (transform.parent.parent.name == "Spice Panel")
        {

        }
        else if (transform.parent.parent.name == "Sauce Panel")
        {

        }
        
    }
}
