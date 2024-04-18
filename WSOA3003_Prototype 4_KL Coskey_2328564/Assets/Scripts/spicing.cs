using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class spicing : MonoBehaviour
{
    public spice spiceType;
    public int INT;
    public GameObject spicePrefab;
    private GameObject clone;
    private Color color;
    public enum spice
    {
        nothing, salt, pepper, paprika, chilli, garlic, BBQ
    }
    public void creatSpice()
    {
        if (GameObject.FindGameObjectWithTag("packaging").transform.parent.name != "SpicePanel"|| GameObject.FindGameObjectWithTag("Pack") == null)
        {
            Debug.Log("Couldn't fine");
            return;
        }
        else
        {
            switch (spiceType)
            {
                case spice.salt:
                    INT = 1; color = Color.white;
                    break;
                case spice.pepper:
                    INT = 2; color = Color.black;
                    break;
                case spice.paprika:
                    INT = 3; color = Color.blue;
                    break;
                case spice.chilli:
                    INT = 4; color = Color.red;
                    break;
                case spice.garlic:
                    INT = 5; color = Color.green;
                    break;
                case spice.BBQ:
                    INT = 6; color = Color.yellow;
                    break;
            }

            clone = Instantiate(spicePrefab, GameObject.FindGameObjectWithTag("packaging").transform);
            clone.GetComponent<RectTransform>().localPosition = Vector3.zero;
            clone.GetComponent<spicing>().INT = INT;
            clone.GetComponent<RawImage>().color = color;

        }
        
        
    }

    
}
