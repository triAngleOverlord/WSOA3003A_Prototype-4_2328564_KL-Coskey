using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class generalUIButtons : MonoBehaviour
{
    [SerializeField] private GameObject assignedPanel;

    public void movePanelInFront()
    {
        assignedPanel.transform.SetAsLastSibling();
        Debug.Log("Moved");
    }
}
