using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ImageOnMouseOver : MonoBehaviour
{
    // The canvas image to show
    public GameObject canvasImage;

    // Called when the object is clicked
    void OnMouseOver()
    {
        // Set the canvas image to be visible
        canvasImage.SetActive(true);
        Debug.Log("Appear Image");
    }
    void OnMouseExit()
    {
        canvasImage.SetActive(false);
    }
}
