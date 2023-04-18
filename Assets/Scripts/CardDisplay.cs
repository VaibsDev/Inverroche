using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class CardDisplay : MonoBehaviour
{
    public Card card;
    // public GameObject ObjctToDisable;
    [Header("Ingredient Detail")]
    [SerializeField] private Transform ingredientDetailBox;
    public TextMeshProUGUI cardName;
    public TextMeshProUGUI description;
    public RawImage displayImage;


    [Space]
    [Header("Ingredient List")]
    [SerializeField] private IngredientTabBehviour ingredientTabBehviour;
    [SerializeField] private Transform ingredientTabHolder;

    public void SetData()
    {
        cardName.text = card.cardName;
        description.text = card.description;
        displayImage.texture = card.displayImage;
        card.Print();
    }
    

    private void OnMouseOver() 
    {
        Debug.Log("OnMouseOver");
        SetData();
        ingredientDetailBox.gameObject.SetActive(true);
    }
   
    private void OnMouseExit() 
    {
        ingredientDetailBox.gameObject.SetActive(false);

    }
    public void AddIngredient(string cardName)
    {
        IngredientTabBehviour tab = Instantiate(ingredientTabBehviour, ingredientTabHolder);
        tab.SetTab(cardName);
    }

    public void SendData()
    {
        // AddIngredient(card.cardName);
        AddIngredient(cardName.text);
    }

    // public void SendData()
    // {
    //     AddIngredient(title);
    // }
}
