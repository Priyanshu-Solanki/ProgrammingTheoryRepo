using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyMovement : Enemy
{
    public override void Move()
    {
        transform.Translate(Vector3.right * speed);
    }
}
