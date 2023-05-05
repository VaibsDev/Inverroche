using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObjectReset : MonoBehaviour
{
    private Vector3 spawnPosition;
    private float startTime= 0f;
    public float lerpTime=3.0f;
    public bool isResetting = false;
    
    void Start()
    {
        // Store the original position of the object
        spawnPosition = transform.position;
    }

    public void ReturntToBase()
    {
        // StopCoroutine("BackToBase");
        StartCoroutine("BackToBase", spawnPosition);
    }

    IEnumerator BackToBase(Vector3 targetPosition)
    {
        float distance = Vector3.Distance(transform.position, targetPosition);
        float duration = distance / lerpTime; // you can adjust the division factor to control the speed
        float time = 0;
        Vector3 startPosition = transform.position;
        while (time < duration)
        {
            transform.position = Vector3.Lerp(startPosition, targetPosition, time / duration);
            time += Time.deltaTime;
            yield return null;
        }
        transform.position = targetPosition;
    }
}