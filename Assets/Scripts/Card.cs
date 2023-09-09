using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "Card", menuName = "Card Game/Card", order = 1)]
public class Card : ScriptableObject
{
    public string cardName;
    public Sprite cardMiniature;

}
