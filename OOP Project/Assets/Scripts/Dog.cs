using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Dog : Enemy
{
    public override void EnemyMove()
    {
        speed = 13;
        transform.Translate(Vector3.forward * Time.deltaTime * speed);

        if (transform.position.z < destroyLimit)
        {
            Destroy(gameObject);
        }
    }
}
