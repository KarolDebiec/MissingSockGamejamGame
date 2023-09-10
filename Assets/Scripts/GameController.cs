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
    public int aliveEnemies = 2;
    public GameObject player;
    public GameObject endPanel;
    public void StarGame()
    {
        displayPlayerCard1.SetCard(playerCards[0]);
        displayPlayerCard2.SetCard(playerCards[1]);
        SpawnEnemies();
        SpawnWeapons();
        aliveEnemies = 2;
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

    void SpawnWeapons()
    {
        if (playerCards[0] is WeaponCard weaponCard1)
        {
            GameObject weapon = Instantiate(weaponCard1.weaponPrefab, enemyPositions[0], Quaternion.identity);
            weapon.transform.parent = player.GetComponent<PlayerController>().leftWeaponSpot.transform;
            weapon.transform.localPosition = Vector3.zero;
        }
        if (playerCards[1] is WeaponCard weaponCard2)
        {
            GameObject weapon = Instantiate(weaponCard2.weaponPrefab, enemyPositions[0], Quaternion.identity);
            weapon.transform.parent = player.GetComponent<PlayerController>().rightWeaponSpot.transform;
            weapon.transform.localPosition = Vector3.zero;
        }
    }
    public void EnemyDestroyed()
    {
        aliveEnemies--;
        if(aliveEnemies<=0)
        {
            EndGame();
        }
    }
    public void EndGame()
    {
        endPanel.SetActive(true);
        Debug.Log("gg wp wygrales");
    }
}
