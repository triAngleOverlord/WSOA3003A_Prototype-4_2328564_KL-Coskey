using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class frying : MonoBehaviour
{
    public GameObject frySlot;
    [SerializeField] private GameObject fryState;
    public int time;
    public bool isFrying;

    public void Start()
    {
        frySlot = gameObject;
    }
    public void fryingFries()
    {
        if (frySlot == null)
            return;
        if (frySlot != null && isFrying==false)
        {
            transform.GetComponent<RectTransform>().position = new Vector3(transform.GetComponent<RectTransform>().position.x, transform.GetComponent<RectTransform>().position.y - 1, transform.GetComponent<RectTransform>().position.z);
            StartCoroutine(timer());
        }
        else if (frySlot != null && isFrying == true)
        {
            transform.GetComponent<RectTransform>().position = new Vector3(transform.GetComponent<RectTransform>().position.x, transform.GetComponent<RectTransform>().position.y + 1, transform.GetComponent<RectTransform>().position.z);
            StopAllCoroutines();
        }
        isFrying = !isFrying;
    }

    public IEnumerator timer()
    {
        yield return new WaitForSecondsRealtime(1);
        time += 1;
        if (time < 30)
        {
            fryState.GetComponent<RawImage>().color = Color.blue;
        }
        if (time == 30)
        {
            Debug.Log("Fries are perfectly cooked");
            StartCoroutine(timer());
            fryState.GetComponent<RawImage>().color = Color.green;
        }
        else if (time == 60)
        {
            Debug.Log("Fries are now burnt");
            StartCoroutine(timer());
            fryState.GetComponent<RawImage>().color = Color.red;
        }
        else
            StartCoroutine(timer());
    }
}
