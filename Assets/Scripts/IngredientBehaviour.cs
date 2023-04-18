using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class IngredientBehaviour : MonoBehaviour
{
    public string title;
    public string description;
    public Texture2D displayImage;
    // public Card card; 

    void OnMouseOver()
    {
        UIManager.Instance.SetData(title, description, displayImage);
        UIManager.Instance.IngredientDetailBox.gameObject.SetActive(true);
    }

     void OnMouseExit()
     {
        UIManager.Instance.IngredientDetailBox.gameObject.SetActive(false);
     }

     public void SendData()
     {
         UIManager.Instance.AddIngredient(title);
     }
}
