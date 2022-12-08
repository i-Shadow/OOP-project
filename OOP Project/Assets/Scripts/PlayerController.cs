using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public float speed;
    public float jumpForce;
    public bool gameOver;
    private bool doubleJump;
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
            doubleJump = false;
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
        playerRb.AddForce(Vector3.right * speed * horizontalInput);

        // Jumping and double-jumping
        if (Input.GetKeyDown(KeyCode.UpArrow) && !gameOver)
        {
            if (isOnGround)
            {
                playerRb.AddForce(Vector3.up * jumpForce, ForceMode.Impulse);
                isOnGround = false;
                doubleJump = true;
            }
            else if (doubleJump && !isOnGround)
            {
                playerRb.AddForce(Vector3.up * jumpForce / 2, ForceMode.Impulse);
                doubleJump = false;
            }

        }
    }

    
}
