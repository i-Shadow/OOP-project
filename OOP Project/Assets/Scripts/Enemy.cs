using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    protected float speed = 50.0f;
    protected Rigidbody objectRb;
    protected float destroyLimit = -45f;
    // Start is called before the first frame update
    void Start()
    {
       // objectRb = GetComponent<Rigidbody>();
       // objectRb.AddForce(Vector3.back * Time.deltaTime * speed, ForceMode.Force);
    }

    // Update is called once per frame
    void Update()
    {

        EnemyMove();
         
    }

    public virtual void EnemyMove()
    {
        transform.Translate(Vector3.back * Time.deltaTime * speed);

        if (transform.position.z < destroyLimit)
        {
            Destroy(gameObject);
        }
    }
}
