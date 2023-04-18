using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObjectReset : MonoBehaviour
{
    // public GameObject objectToHide;
    private Vector3 spawnPosition;
    private Vector3 currentPosition;
    private float startTime= 0f;
    public float lerpTime=3.0f;

    void Start()
    {
        // Store the original position of the object
        spawnPosition = transform.position;
    }

    public void ReturntToBase()
    {
        StartCoroutine("BackToBase");
    }

    IEnumerator BackToBase()
    {  
        startTime = 0;
        Debug.Log("return to base");
        while(startTime<lerpTime)
        {
        transform.position = Vector3.Lerp(transform.position,spawnPosition,startTime/lerpTime);
        startTime +=Time.deltaTime;
        yield return null;
        // this.transform.position = spawnPosition;
        }
    }

    // public void HideObject() 
    // {
    //     objectToHide.SetActive(false);
    // }

    // public void ShowObject() 
    // {
    //     objectToHide.SetActive(true);
    // }
}



// public Vector3 startingPosition;
//     // Define the original position of the object
//     public Vector3 originalPosition;
//     // Define the duration of the movement
//     public float duration = 2.0f;

//     // Define a variable to track elapsed time
//     private float elapsedTime = 0.0f;

//     // Update is called once per frame
//     void Update () {
//         // If the object has been moved away from its original position
//         if (transform.position != originalPosition) {
//             // Increment the elapsed time
//             elapsedTime += Time.deltaTime;
//             // Calculate the progress of the movement using Lerp
//             float t = Mathf.Clamp01(elapsedTime / duration);
//             transform.position = Vector3.Lerp(startingPosition, originalPosition, t);
//         }
//     }
// }