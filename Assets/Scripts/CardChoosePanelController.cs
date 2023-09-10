using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CardChoosePanelController : MonoBehaviour
{
    public CardSlot enemyCard1;
    public CardSlot enemyCard2;
    public CardSlot enemyCard3;
    public CardSlot enemyCard4;

    public CardSlot playerCard1;
    public CardSlot playerCard2;
    public CardSlot playerCard3;
    public CardSlot playerCard4;
    public CardSlot playerCard5;

    public CardSlot enemyCombinationOutput1;
    public CardSlot enemyCombinationOutput2;
    public CardSlot playerCombinationOutput1;
    public CardSlot playerCombinationOutput2;

    public GameController gameController;

    public List<Card> allBasicEnemies;
    public List<Card> allBasicWeapons;
    void Start()
    {
        SetRandomCards();
    }

    void SetRandomCards()
    {
        enemyCard1.SetCard(PickRandomCard(allBasicEnemies));
        enemyCard2.SetCard(PickRandomCard(allBasicEnemies));
        enemyCard3.SetCard(PickRandomCard(allBasicEnemies));
        enemyCard4.SetCard(PickRandomCard(allBasicEnemies));
        playerCard1.SetCard(PickRandomCard(allBasicWeapons));
        playerCard2.SetCard(PickRandomCard(allBasicWeapons));
        playerCard3.SetCard(PickRandomCard(allBasicWeapons));
        playerCard4.SetCard(PickRandomCard(allBasicWeapons));
        playerCard5.SetCard(PickRandomCard(allBasicWeapons));
    }
    Card PickRandomCard(List<Card> cards)
    {
        if (cards != null && cards.Count > 0)
        {
            int randomIndex = Random.Range(0, cards.Count);
            return cards[randomIndex];
        }
        return null;
    }
    public void CombineCards()
    {
        enemyCombinationOutput1.card = gameController.GetCombinationResult(enemyCard1.card, enemyCard2.card);
        enemyCombinationOutput1.UpdateDisplayFromCard();
        enemyCombinationOutput1.cardType = CardType.Immovable;
        enemyCombinationOutput2.card = gameController.GetCombinationResult(enemyCard3.card, enemyCard4.card);
        enemyCombinationOutput2.UpdateDisplayFromCard();
        enemyCombinationOutput2.cardType = CardType.Immovable;
        playerCombinationOutput1.card = gameController.GetCombinationResult(playerCard1.card, playerCard2.card);
        playerCombinationOutput1.UpdateDisplayFromCard();
        playerCombinationOutput1.cardType = CardType.Immovable;
        playerCombinationOutput2.card = gameController.GetCombinationResult(playerCard4.card, playerCard5.card);
        playerCombinationOutput2.UpdateDisplayFromCard();
        playerCombinationOutput2.cardType = CardType.Immovable;
        gameController.enemies.Add(enemyCombinationOutput1.card);
        gameController.enemies.Add(enemyCombinationOutput2.card);
        gameController.playerCards.Add(playerCombinationOutput1.card);
        gameController.playerCards.Add(playerCombinationOutput2.card);
    }
}
