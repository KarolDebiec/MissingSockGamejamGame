using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public enum CardType
{
    Player,
    Enemy,
    Immovable
}
public class CardSlot : MonoBehaviour
{
    public Card card;
    public Image cardImage;
    public TextMeshProUGUI nameText;
    public TextMeshProUGUI descriptionText;

    public CardType cardType;
    private void Start()
    {
        if(card!=null)
        {
            UpdateDisplayFromCard();
        }
    }
    public bool SetCard(Card newCard)
    {
        if (newCard.CardType == cardType)
        {
            card = newCard;
            UpdateDisplayFromCard();
            return true;
        }
        return false;
    }
    public void UpdateDisplayFromCard()
    {
        if (card != null)
        {
            cardImage.sprite = card.cardMiniature;// Assuming Card has a Sprite property
            nameText.text = card.cardName;
            descriptionText.text = card.cardDescription;
            cardType = card.CardType;
        }
    }
    public Card GetCard()
    {
        return card;
    }
}
