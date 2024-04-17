using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class OrderingSystem : MonoBehaviour
{
    public List<int> order = new List<int>();
    public int orderINT;
    public string orderName;

    public int timeWaiting;
    public bool hasOrdered;

    public int option;
    private GameObject orderSheet;
    private GameObject nameSheet;
    void Start()
    {
        StartCoroutine(waitingTime());
        int fryTYPE = Random.Range(0, 3); // shoestring, waffle, curly, crinkle 
        order.Add(fryTYPE);
        int oneSPICE = Random.Range(0, 6); //nothing, salt, pepper, paprika, chilli , garlic, BBQ
        order.Add(oneSPICE);
        int dippingSAUCE = Random.Range(0, 4);//nothing, tomato , mustard, cheese, mayo
        order.Add(dippingSAUCE);
        int packaging = Random.Range(0, 2);// plate, fry box, bowl
        order.Add(packaging);
        Debug.Log(name);

        orderSheet = GameObject.Find("Order Sheet");
        nameSheet = GameObject.Find("NameSheet");
        hasOrdered = false;
    }


    private IEnumerator waitingTime()
    {
        yield return new WaitForSecondsRealtime(1);
        timeWaiting += 1;

        if (timeWaiting == 30)
        {
            Debug.Log("This is taking too long");
            StartCoroutine(waitingTime());
            //get angry and minus 5% from total payment
        }
        else if (timeWaiting == 60)
        {
            Debug.Log("I am leaving");
            StopCoroutine(waitingTime());
        }
        else
            StartCoroutine(waitingTime());
    }

    public void makeTheOrder()
    {
        nameSheet.GetComponent<TextMeshProUGUI>().text = transform.name;
        option = 1;
        if (hasOrdered == false)
        {
            StartCoroutine(nextOption());
        }
        else
            return;
    }

    public IEnumerator nextOption()
    {
        hasOrdered = true;
        orderSheet.transform.GetChild(option).transform.GetComponent<TextMeshProUGUI>().text = new string(optionsTXT(option, order[orderINT]));
        option ++;
        orderINT++;
        yield return new WaitForSecondsRealtime(1);
        if (option == order.Count +1)
        {
            StopAllCoroutines();
            transform.GetChild(0).gameObject.SetActive(false);
        }
        else
            StartCoroutine (nextOption());
    }

    public string optionsTXT (int option, int type)
    {
        if (option == 1)
        {
            orderName = "Fry Type: ";
            if (type == 0)
                orderName += "Shoestring";
            else if (type == 1)
                orderName += "Waffle";
            else if (type == 2)
                orderName += "Curly";
            else
                orderName += "Crinkle";
        }
        else if (option == 2)
        {
            orderName = "Spice: ";
            if (type == 0)
                orderName += "Nothing";
            else if (type == 1)
                orderName += "Salt";
            else if (type == 2)
                orderName += "Pepper";
            else if (type == 3)
                orderName += "Paprika";
            else if (type == 4)
                orderName += "Chilli";
            else if (type == 5)
                orderName += "Garlic";
            else
                orderName += "BBQ";
        }
        
        else if (option == 3)
        {
            orderName = "Sauce: ";
            if (type == 0)
                orderName += "Nothing";
            else if (type == 1)
                orderName += "Tomato";
            else if (type == 2)
                orderName += "Mustard";
            else if (type == 3)
                orderName += "Cheese";
            else
                orderName += "Mayo"; 
        }
        else if (option == 4) 
        { 
            orderName = "Packaging: ";
            if (type == 0)
                orderName += "Plate";
            else if (type == 1)
                orderName += "Fry box";
            else 
                orderName += "Bowl";
        }
        return orderName;
    }
}
