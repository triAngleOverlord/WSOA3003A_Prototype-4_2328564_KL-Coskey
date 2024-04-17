using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OrderingSystem : MonoBehaviour
{
    public List<int> order = new List<int>();
    public int timeWaiting;
    public GameObject orderSheet;
    void Start()
    {
        StartCoroutine(waitingTime());
        int fryTYPE = Random.Range(0, 3); // shoestring, waffle, curly, crinkle 
        order.Add(fryTYPE);
        int oneSPICE = Random.Range(0, 3); //nothing, salt, pepper, paprika
        order.Add(oneSPICE);
        int twoSPICE = Random.Range(0, 3); //nothing, chilli , garlic, BBQ
        order.Add(twoSPICE);
        int dippingSAUCE = Random.Range(0, 4);//nothing, tomato , mustard, cheese, mayo
        order.Add(dippingSAUCE);
        int packaging = Random.Range(0, 2);// plate, fry box, bowl
        order.Add(packaging);
        Debug.Log(name);
        orderSheet = GameObject.Find("OrderSheet");

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

    }
}
