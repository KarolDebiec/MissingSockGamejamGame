using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShootingWeapon : MonoBehaviour
{
    public GameObject bulletPrefab;
    public int damage;
    public bool shoot = false;
    public GameObject bulletOffset;
    public float bulletSpeed = 20f;

    public float fireRate = 0.5f;
    private float nextFireTime = 0f;
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space) && Time.time >= nextFireTime)
        {
            nextFireTime = Time.time + 1f / fireRate;
        
            GameObject bulletInstance = Instantiate(bulletPrefab, bulletOffset.transform.position, Quaternion.identity);
            BulletController bulletScript = bulletInstance.GetComponent<BulletController>();
            if (bulletScript != null)
            {
                bulletScript.direction = transform.forward;
                bulletScript.speed = bulletSpeed;
            }
            shoot = false;
        }
    }
}
