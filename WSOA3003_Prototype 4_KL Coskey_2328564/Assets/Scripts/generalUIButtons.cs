using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class generalUIButtons : MonoBehaviour
{
    [SerializeField] private GameObject assignedPanel;
    public bool foodInSauce;
    public bool submitBTN;

    private void Update()
    {
        if (submitBTN == true)
        {
            if (foodInSauce == true)
            {
                transform.GetComponent<RectTransform>().localPosition = new Vector3(801f, 306f, 0);
            }
            else
                transform.GetComponent<RectTransform>().localPosition = new Vector3(1401f, 306f, 0);
        }
    }

    public void movePanelInFront()
    {
        assignedPanel.transform.SetAsLastSibling();
        //Debug.Log("Moved");
    }

    public void submitFood()
    {
        
    }
}
