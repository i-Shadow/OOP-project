using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public float speed = 0.02f;
    public float jumpForce = 80f;
    public bool gameOver;
    public bool isOnGround;
    private Rigidbody playerRb;
        
    // Start is called before the first frame update
    void Start()
    {
        playerRb = GetComponent<Rigidbody>();
           
    }

    // Update is called once per frame
    void Update()
    {
        MovePlayer();

    }

    private void OnCollisionEnter(Collision collision)
    {
        // Back to ground after jumping
        if (collision.gameObject.CompareTag("Ground"))
        {
            isOnGround = true;
        }

        if (collision.gameObject.CompareTag("Enemy"))
        {
            Debug.Log("Player collided with an enemy or obstacle");
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if(other.CompareTag("Consumable"))
        {
            Destroy(other.gameObject);
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
        if (Input.GetKeyDown(KeyCode.UpArrow) && !gameOver)
        {
            if (isOnGround)
            {
                playerRb.AddForce(Vector3.up * jumpForce, ForceMode.Impulse);
                isOnGround = false;
            }
            else if (!isOnGround)
            {
                playerRb.AddForce(Vector3.up * jumpForce / 2, ForceMode.Impulse);
            }

        }
    }

    
}
