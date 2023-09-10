using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SlimeController : EnemyController
{
    public float speed;
    public int damage;
    public GameObject player;
    public float damageInterval;
    private float intervalTime = 0;
    public bool waitForAttack = false;
    public float pushDistance = 1f;
    public float rotationSpeed = 10f;
    // Start is called before the first frame update
    void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player");
    }

    // Update is called once per frame
    void Update()
    {
        if (player != null && !waitForAttack)
        {
            Vector3 direction = player.transform.position - transform.position;
            Quaternion targetRotation = Quaternion.LookRotation(direction);
            transform.rotation = Quaternion.Slerp(transform.rotation, targetRotation, Time.deltaTime * rotationSpeed);


            transform.position = Vector3.MoveTowards(transform.position, player.transform.position, speed * Time.deltaTime);
        }
        if(waitForAttack)
        {
            intervalTime += Time.deltaTime;
            if (intervalTime > damageInterval)
            {
                waitForAttack = false;
                intervalTime = 0;
            }
        }
    }

    private void OnCollisionEnter(Collision collision)
    {
        if(collision.transform.tag == "Player")
        {
            collision.gameObject.GetComponent<PlayerController>().DamagePlayer(damage);
            waitForAttack = true;
            Vector3 pushDirection = new Vector3(player.transform.position.x - transform.position.x,0, player.transform.position.z - transform.position.z);
            player.transform.position += pushDirection.normalized * pushDistance;
        }
    }
}
