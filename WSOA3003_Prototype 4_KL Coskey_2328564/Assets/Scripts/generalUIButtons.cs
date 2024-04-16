using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class generalUIButtons : MonoBehaviour
{
    private bool lookingAtCounter;
    public void moveCamera()
    {
        if (lookingAtCounter == false)
        {
            Transform camera = GameObject.Find("Main Camera").transform;
            camera.position = new Vector3(0, -3.33f, -10f);
            transform.GetComponent<RectTransform>().rotation = new Quaternion(0, 0, 180f, 0);
            
        }
        if (lookingAtCounter == true)
        {
            Transform camera = GameObject.Find("Main Camera").transform;
            camera.position = new Vector3(0, 0, -10f);
            transform.GetComponent<RectTransform>().rotation = new Quaternion(0, 0, 0, 0);

        }
        lookingAtCounter = !lookingAtCounter;
    }
}
