using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameController : MonoBehaviour
{
    public CardCombinationDatabase combinationDatabase;

    public List<Card> enemies;
    public List<Card> playerCards;

    // Start is called before the first frame update
    void Start()
    {
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void StarGame()
    {
        Debug.Log("The has started");
    }

    public Card GetCombinationResult(Card card1, Card card2)
    {
        foreach (var combination in combinationDatabase.combinations)
        {
            if ((combination.Card1 == card1 && combination.Card2 == card2) ||
                (combination.Card1 == card2 && combination.Card2 == card1))
            {
                return combination.ResultCard;
            }
        }
        return null; // No valid combination found
    }
}
