using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class PlayerController : MonoBehaviour
{
    public int health;
    public Slider healthSlider;
    public float speed = 5.0f;
    public Transform leftWeaponSpot; 
    public Transform rightWeaponSpot;
    void Update()
    {
        float moveHorizontal = Input.GetAxis("Horizontal");
        float moveVertical = Input.GetAxis("Vertical");

        Vector3 movement = new Vector3(moveHorizontal, 0.0f, moveVertical);
        movement.Normalize();
        transform.Translate(movement * speed * Time.deltaTime, Space.World);
    }

    public void DamagePlayer(int amount)
    {
        health -= amount;
        healthSlider.value = health;
        if (health <= 0)
        {
            OnDie();
        }
    }
    void OnDie()
    {
        Debug.Log("player died");
    }
}
