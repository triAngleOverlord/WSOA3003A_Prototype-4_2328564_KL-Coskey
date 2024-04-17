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
        transform.parent.GetComponent<packaging>().cloning();
        transform.parent.transform.SetParent(GameObject.Find("SpicePanel").transform, true);
        gameObject.SetActive(false);
    }
}
