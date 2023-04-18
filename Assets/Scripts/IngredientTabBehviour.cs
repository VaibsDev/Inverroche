using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class IngredientTabBehviour : MonoBehaviour
{
    // public Card card;
    [SerializeField] private TextMeshProUGUI cardName;
    // [SerializeField] private Button cancleButton;

    public void SetTab(string card)
    {
        this.cardName.text = card;
    }
}
