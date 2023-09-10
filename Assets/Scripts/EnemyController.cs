using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyController : MonoBehaviour
{
    public int health;
    public void DamageEnemy(int amount)
    {
        health -= amount;
        if (health <= 0)
        {
            Destroy(gameObject);
            GameObject.FindGameObjectWithTag("GameController").GetComponent<GameController>().EnemyDestroyed();
        }

    }
   
}
