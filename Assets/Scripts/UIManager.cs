using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class UIManager : MonoBehaviour
{
    public static UIManager Instance;
    [Header("Ingredient Detail")]
    [SerializeField] private Transform ingredientDetailBox;
    public Transform IngredientDetailBox {get{return ingredientDetailBox; }set{ ingredientDetailBox = value;}}
    [SerializeField] private TextMeshProUGUI title;
    [SerializeField] private TextMeshProUGUI description;
    [SerializeField] private RawImage displaceImage;

    [Space]
    [Header("Ingredient List")]
    [SerializeField] private IngredientTabBehviour ingredientTabBehviour;
    [SerializeField] private Transform ingredientTabHolder;

    void Awake()
    {
        Instance = this;
    }

    public void SetData(string title, string description, Texture2D displayImage)
    {
        this.title.text = title;
        this.description.text = description;
        displaceImage.texture = displayImage;
    }

    public void AddIngredient(string title)
    {
        IngredientTabBehviour tab = Instantiate(ingredientTabBehviour, ingredientTabHolder);
        tab.SetTab(title);
    }
}
