using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveRightCliff : BackgroundMove
{
    
    public override void Move()
    {
        startPosition = new Vector3(transform.position.x, transform.position.y, -100);
        transform.Translate(Vector3.forward * speed * Time.deltaTime);

        if (transform.position.z < startPosition.z)
        {
            transform.position = startPosition + new Vector3(0, 0, repeatInterval * 2f);
        }
    }
}
