using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Dog : Enemy
{
    public GameObject player;
    Vector3 playerDirection;
    [SerializeField] int dogSpeed = 50;
    public override void EnemyMove()
    {
        player = GameObject.Find("Player");
        speed = 30;
        if (transform.position.z < -30)
        {
            playerDirection = new Vector3(0, transform.position.y, transform.position.z).normalized;
        }
        else playerDirection = (player.transform.position - transform.position).normalized;
        
        Quaternion tempLookRotation = Quaternion.LookRotation(new Vector3(playerDirection.x, 0.0f, playerDirection.z));
        transform.rotation = Quaternion.Lerp(gameObject.transform.rotation, tempLookRotation, Time.deltaTime * speedRotation);
        objectRb.AddForce(playerDirection * dogSpeed);
       
        if ((transform.position.z < destroyLimit) | GameManager.Instance.gameOver)
        {
            Destroy(gameObject);
        }
    }
}
