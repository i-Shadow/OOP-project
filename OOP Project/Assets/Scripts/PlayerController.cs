using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;


public class PlayerController : MonoBehaviour
{
    public float speed = 0.02f;
    public float jumpForce = 80f;
    
    public bool isOnGround;
    
    
    private Rigidbody playerRb;
    
    private bool triggerFlag = false;
    
    

    // Start is called before the first frame update
    void Start()
    {
        playerRb = GetComponent<Rigidbody>();
        

    }

    // Update is called once per frame
    void Update()
    {
        if (!GameManager.Instance.gameOver)
        {
            MovePlayer();
            
        }
    }

    private void OnCollisionEnter(Collision collision)
    {
        // Back to ground after jumping
        if (collision.gameObject.CompareTag("Ground"))
        {
            isOnGround = true;
            playerRb.velocity = Vector3.zero;
        }

        
    }

    private void OnTriggerEnter(Collider other)
    {
        if(other.CompareTag("Consumable") || other.CompareTag("Enemy") || other.CompareTag("Obstacle"))
        {
            Destroy(other.gameObject);
            playerRb.velocity = Vector3.zero;

            if (other.CompareTag("Consumable"))
            {
                if (GameManager.Instance.lives < GameManager.Instance.maxLives) GameManager.Instance.lives++;
            }
            else if (other.CompareTag("Enemy") | other.CompareTag("Obstacle"))
            {
                if ((GameManager.Instance.lives > GameManager.Instance.minLives)&&!triggerFlag)
                {
                    GameManager.Instance.lives--;
                    triggerFlag = true;
                    StartCoroutine(EnemyDelay());
                }
            }

            
        }

    }

    IEnumerator EnemyDelay()
    {
        while (true)
        {

            yield return new WaitForSeconds((float)0.1);
            triggerFlag = false;
        }

    }

    // Player movements according to input keys
    private void MovePlayer()
    {
        // Movement from side to side
        float horizontalInput = Input.GetAxis("Horizontal");
        
        if (transform.position.x >= -10 && transform.position.x <= 9 && isOnGround)
        {
            transform.Translate(Vector3.right * speed * horizontalInput);
        } 
        else
        {
            if (transform.position.x < -10) transform.position = new Vector3(-10, transform.position.y, transform.position.z);
            if (transform.position.x > 9) transform.position = new Vector3(9, transform.position.y, transform.position.z);
        }

        // Jumping
        if (Input.GetKeyDown(KeyCode.UpArrow) && !GameManager.Instance.gameOver)
        {
            if (isOnGround)
            {
                playerRb.AddForce(Vector3.up * jumpForce, ForceMode.Impulse);
                isOnGround = false;
            }
            
        }
    }

    

    
    
}
