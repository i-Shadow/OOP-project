using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Cat : Enemy
{
    public override void EnemyMove()
    {
        speed = 15;
        transform.Translate(Vector3.forward * Time.deltaTime * speed);

        if (transform.position.z < destroyLimit)
        {
            Destroy(gameObject);
        }
    }
}
