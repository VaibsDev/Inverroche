using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TriggerStay : MonoBehaviour
{
    // public float waitTime;
     private Vector3 originalPosition;
    private bool insideZone = false;

    private void Start() {
        
    }
    private void OnTriggerStay(Collider other)
    {
        if (!insideZone &&other.CompareTag("Ingredient"))
        {
            insideZone = true;
            Debug.Log("Stay");
            // StartCoroutine(WaitForSeconds());
            StartCoroutine(StayAtOnePosition());
        }
    }
    IEnumerator StayAtOnePosition()
    {
        Debug.Log("WaitFor 5 Seconds ");
        Vector3 originalPosition = transform.position;
        transform.position = new Vector3(0, 0, 0); // set the object to stay at this position
        yield return new WaitForSeconds(5f); // wait for 5 seconds
        transform.position = originalPosition; // set the object back to its original position
    }

    private void OnTriggerExit(Collider other)
    {
    //     // if (other.CompareTag("Ingredient"))
    //     // {
            insideZone = false;
            // StopAllCoroutines();
    //     // }
    }

    // private IEnumerator WaitForSeconds()
    // {
    //     yield return new WaitForSeconds(waitTime);

    //     if (insideZone)
    //     {
    //         // do something
    //         Debug.Log("Stay");
    //     }
    // }
}











/*// Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    } */