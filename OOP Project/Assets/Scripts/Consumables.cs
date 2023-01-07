using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Consumables : Enemy
{
    public override void EnemyMove()
    {
        speed = 10;
        transform.Translate(Vector3.back * Time.deltaTime * speed);

        if (transform.position.z < destroyLimit)
        {
            Destroy(gameObject);
        }
    }
}
