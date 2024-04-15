using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OrderingSystem : MonoBehaviour
{
    List<int> order = new List<int>();
    public int timeWaiting;
    void Start()
    {
        StartCoroutine(waitingTime());
        int fryTYPE = Random.Range(0, 4); //straight, curly, slap chips, crinkle cut, mashed
        order.Add(fryTYPE);
        int oneSPICE = Random.Range(0, 3); //salt, pepper, paprika, cumin
        order.Add(oneSPICE);
        int twoSPICE = Random.Range(0, 3); //chilli salt, fennel seeds , garlic, BBQ
        order.Add(twoSPICE);
        int dippingSAUCE = Random.Range(0, 4);// tomato sauce, mustard, cheese, mayo, 1000 islands
        order.Add(dippingSAUCE);
        int packaging = Random.Range(0, 2);// plate, fry box, bowl
        order.Add(packaging);
        Debug.Log(name);
        foreach (int i in order)
        {
            Debug.Log(i);
        }

    }

    // Update is called once per frame
    void Update()
    {

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

}
