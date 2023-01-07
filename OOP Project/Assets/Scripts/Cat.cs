using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Cat : Enemy
{
    public GameObject player;
    public override void EnemyMove()
    {
        player = GameObject.Find("Player");       
        speed = 15;
        Vector3 playerDirection = (transform.position - player.transform.position).normalized;
        transform.Translate(playerDirection * Time.deltaTime * speed);
        transform.Rotate(0, playerDirection.x, 0);
        if (transform.position.z < destroyLimit)
        {
            Destroy(gameObject);
        }
    }
}
