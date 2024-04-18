using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class saucing : MonoBehaviour
{
    public sauce sauceType;
    public int INT;
    public GameObject saucePrefab;
    private GameObject clone;
    private Color color;
    public enum sauce
    {
        nothing, tomato, mustard, cheese, mayo
    }
    public void creatSauce()
    {
        if (GameObject.FindGameObjectWithTag("packaging").transform.parent.name != "SaucePanel" || GameObject.FindGameObjectWithTag("Pack") == null)
        {
            Debug.Log("Couldn't fine");
            return;
        }
        else
        {
            switch (sauceType)
            {
                case sauce.tomato:
                    INT = 1; color = Color.red;
                    break;
                case sauce.mustard:
                    INT = 2; color = Color.green;
                    break;
                case sauce.cheese:
                    INT = 3; color = Color.yellow;
                    break;
                case sauce.mayo:
                    INT = 4; color = Color.white;
                    break;
            }

            clone = Instantiate(saucePrefab, GameObject.FindGameObjectWithTag("packaging").transform);
            clone.GetComponent<RectTransform>().localPosition = Vector3.zero;
            clone.GetComponent<saucing>().INT = INT;
            clone.GetComponent<RawImage>().color = color;

        }
    }
}
