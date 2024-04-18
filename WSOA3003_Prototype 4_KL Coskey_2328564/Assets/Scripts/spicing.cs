using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class spicing : MonoBehaviour
{
    public spice spiceType;
    public int spiceINT;
    public GameObject spicePrefab;
    private GameObject clone;
    private Color color;
    public enum spice
    {
        nothing, salt, pepper, paprika, chilli, garlic, BBQ
    }
    public void creatSpice()
    {
        if (GameObject.FindGameObjectWithTag("Pack").transform.parent != transform.parent || GameObject.FindGameObjectWithTag("Pack") == null)
        {
            Debug.Log("Couldn't fine");
            return;
        }
        else
        {
            switch (spiceType)
            {
                case spice.salt:
                    spiceINT = 1; color = Color.white;
                    break;
                case spice.pepper:
                    spiceINT = 2; color = Color.black;
                    break;
                case spice.paprika:
                    spiceINT = 3; color = Color.blue;
                    break;
                case spice.chilli:
                    spiceINT = 4; color = Color.red;
                    break;
                case spice.garlic:
                    spiceINT = 5; color = Color.green;
                    break;
                case spice.BBQ:
                    spiceINT = 6; color = Color.yellow;
                    break;
            }

            clone = Instantiate(spicePrefab, GameObject.FindGameObjectWithTag("Pack").transform);
            clone.GetComponent<RectTransform>().localPosition = Vector3.zero;
            clone.GetComponent<spicing>().spiceINT = spiceINT;
            clone.GetComponent<RawImage>().color = color;

        }
        
        
    }

    
}
