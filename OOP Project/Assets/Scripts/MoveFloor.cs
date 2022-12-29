using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveFloor : BackgroundMove
{
    // Start is called before the first frame update
    public override void Move()
    {
        startPosition = new Vector3(transform.position.x, transform.position.y, -90);
        transform.Translate(Vector3.back * speed * Time.deltaTime);

        if (transform.position.z < startPosition.z)
        {
            transform.position = startPosition + new Vector3(0, 0, repeatInterval * 18.5f);
        }
    }
}
