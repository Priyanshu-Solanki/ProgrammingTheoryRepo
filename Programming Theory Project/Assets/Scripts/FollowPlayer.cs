using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FollowPlayer : MonoBehaviour
{
    public GameObject player;
    public Vector3 offset;

    void LateUpdate()
    {
        transform.position = player.transform.position + offset;
    }
}
