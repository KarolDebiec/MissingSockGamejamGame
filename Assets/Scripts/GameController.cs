using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameController : MonoBehaviour
{
    public CardCombinationDatabase combinationDatabase;

    public CardSlot displayPlayerCard1;
    public CardSlot displayPlayerCard2;
    public List<Card> enemies;
    public List<Card> playerCards;
    public List<Vector3> enemyPositions;
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
        displayPlayerCard1.SetCard(playerCards[0]);
        displayPlayerCard2.SetCard(playerCards[1]);
        SpawnEnemies();
        Debug.Log("The game has started");
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

    void SpawnEnemies()
    {
        if (enemies[0] is EnemyCard enemyCard1)
        {
            Instantiate(enemyCard1.enemyPrefab, enemyPositions[0], Quaternion.identity);
        }
        else
        {
            Debug.LogError("First enemy card is not an enemy card");
        }
        if (enemies[1] is EnemyCard enemyCard2)
        {
            Instantiate(enemyCard2.enemyPrefab, enemyPositions[1], Quaternion.identity);
        }
        else
        {
            Debug.LogError("Second enemy card is not an enemy card");
        }
    }
}
