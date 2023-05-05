using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class IngredientTabBehviour : MonoBehaviour
{
    // public Card card;
    [SerializeField] private TextMeshProUGUI cardName;

    public void SetTab(string card)
    {
        this.cardName.text = card;
    }
}
