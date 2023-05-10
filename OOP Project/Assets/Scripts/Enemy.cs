using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    protected float speed = 50.0f;
    protected Rigidbody objectRb;
    protected float destroyLimit = -40f;
    protected int speedRotation = 5;
    // Start is called before the first frame update
    void Start()
    {
        objectRb = GetComponent<Rigidbody>();
       
    }

    // Update is called once per frame
    void FixedUpdate()
    { 
        if (gameObject.CompareTag("Enemy"))
        {
            EnemyMove();
        }
    }

    private void Update()
    {
        if (gameObject.CompareTag("Obstacle") || gameObject.CompareTag("Consumable"))
        {
            EnemyMove();
        }
    }

    public virtual void EnemyMove()
    {
      
        if ((transform.position.z < destroyLimit) | GameManager.Instance.gameOver)
        {
            Destroy(gameObject);
        }
    }

    private void OnCollisionEnter(Collision other)
    {
        if (other.gameObject.CompareTag("Enemy") || other.gameObject.CompareTag("Consumable") || other.gameObject.CompareTag("Obstacle"))
        {
            Physics.IgnoreCollision(gameObject.GetComponent<BoxCollider>(), other.gameObject.GetComponent<BoxCollider>());
            
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Consumable") | other.CompareTag("Enemy") | other.gameObject.CompareTag("Obstacle"))
        {
            Physics.IgnoreCollision(gameObject.GetComponent<BoxCollider>(), other.gameObject.GetComponent<BoxCollider>());
        }
        if (other.CompareTag("Player"))
        {
            Destroy(gameObject);
        }
        
    }

}
