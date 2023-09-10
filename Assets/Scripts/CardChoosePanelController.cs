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

    void Start()
    {
        //randomize the cards
    }

    // Update is called once per frame
    void Update()
    {
        
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
    }
}
