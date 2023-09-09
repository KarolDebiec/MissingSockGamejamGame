using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "CardCombinationDatabase", menuName = "Card Game/Card Combination Database")]
public class CardCombinationDatabase : ScriptableObject
{
    public List<CardCombination> combinations;
}
