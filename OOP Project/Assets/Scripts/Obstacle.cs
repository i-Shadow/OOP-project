using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Obstacle : Enemy
{
    public override void EnemyMove()
    {
        speed = 10;
        transform.Translate(Vector3.right * Time.deltaTime * speed);

        if (transform.position.z < destroyLimit)
        {
            Destroy(gameObject);
        }
    }
}
