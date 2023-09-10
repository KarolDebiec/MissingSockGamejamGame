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
    public float rotationSpeed = 2f;
    void Update()
    {
        float moveHorizontal = Input.GetAxis("Horizontal");
        float moveVertical = Input.GetAxis("Vertical");
        Vector3 movement = new Vector3(moveHorizontal, 0.0f, moveVertical);
        if (moveHorizontal + moveVertical != 0)
        {
            movement.Normalize();
            Quaternion targetRotation = Quaternion.LookRotation(movement);
            transform.rotation = Quaternion.Slerp(transform.rotation, targetRotation, Time.deltaTime * rotationSpeed);
        }

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
