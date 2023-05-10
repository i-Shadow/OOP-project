using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BackgroundMove : MonoBehaviour
{
    protected Vector3 startPosition;
    protected float repeatInterval;
    protected float speed = 10;
    // Start is called before the first frame update
    void Start()
    {
        startPosition = new Vector3(transform.position.x, transform.position.y, transform.position.z) ;
        repeatInterval = GetComponent<BoxCollider>().size.z;
    }

    // Update is called once per frame
    void Update()
    {
       if (!GameManager.Instance.gameOver)
        {
            Move();
        }
    }

    public virtual void Move()
    {
        transform.Translate(Vector3.back * speed * Time.deltaTime);

        if (transform.position.z < startPosition.z - repeatInterval)
        {
            transform.position = startPosition + new Vector3(0, 0, repeatInterval * 2);
        }
    }
}
