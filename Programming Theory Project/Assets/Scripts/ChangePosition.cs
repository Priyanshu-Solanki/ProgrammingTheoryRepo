using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChangePosition : MonoBehaviour
{
    private GameObject player;
    public float newPositionZ;
    void Start()
    {
        player = GameObject.Find("Player");
    }

    void Update()
    {
        if(player.transform.position.z > (transform.position.z + 60.0f))
        {
            transform.position += new Vector3(0, 0, newPositionZ);
        }
    }
}
