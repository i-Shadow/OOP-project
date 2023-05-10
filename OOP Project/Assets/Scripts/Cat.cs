using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Cat : Enemy
{
    public GameObject player;
    Vector3 playerDirection;
    [SerializeField] int catSpeed = 100;
        public override void EnemyMove()
    {
        player = GameObject.Find("Player");       
        
        
        if (transform.position.z < -30)
        {
            playerDirection = new Vector3(0, transform.position.y, transform.position.z).normalized;
        } else playerDirection = (player.transform.position - transform.position).normalized;
     
        Quaternion tempLookRotation = Quaternion.LookRotation(new Vector3(playerDirection.x, 0.0f, playerDirection.z));
        
        transform.rotation = Quaternion.Lerp(gameObject.transform.rotation, tempLookRotation, Time.deltaTime * speedRotation);
        
        objectRb.AddForce(playerDirection * catSpeed);

        if ((transform.position.z < destroyLimit) | GameManager.Instance.gameOver)
        {
            Destroy(gameObject);
        }
    }
}
