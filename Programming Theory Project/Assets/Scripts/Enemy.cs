using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    public float speed;

    void FixedUpdate()
    {
        Move();
    }
    public virtual void Move()
    {
        transform.Translate(Vector3.forward * speed);
    }
}
