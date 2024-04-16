using System.Collections;
using System.Collections.Generic;
using System.Data;
using UnityEngine;

public class BeginOrderClick : MonoBehaviour
{
    public bool hasOrderedYet = false;
    [SerializeField] private OrderingSystem NPCorder;
    public GameObject orderSheet;
    private int orderOption = 0;
    public void nextOption()
    {
        if (hasOrderedYet == false)
        {
            //do order animation
            //produce order sheet
            var first = NPCorder.order[orderOption];
            orderOption += 1;
            hasOrderedYet = true;
            //add option to order sheet
        }
        else if (orderOption != NPCorder.order.Count)
        {
            //do order animation
            var option = NPCorder.order[orderOption];
            orderOption += 1;
            //add option to order sheet
        }
        else
        {
            //move NPC away
        }
        
    }
}
