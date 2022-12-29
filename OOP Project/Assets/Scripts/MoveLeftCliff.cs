using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveLeftCliff : BackgroundMove
{
    
    public override void Move()
    {
        startPosition = new Vector3(transform.position.x, transform.position.y, -80);
        transform.Translate(Vector3.back * speed * Time.deltaTime);

        if (transform.position.z < startPosition.z)
        {
            transform.position = startPosition + new Vector3(0, 0, repeatInterval * 2f);
        }
    }
}
