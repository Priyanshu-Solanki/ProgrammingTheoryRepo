using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Destroy : MonoBehaviour
{
    private GameObject player;
    private bool destroyed;
    private void Start()
    {
        player = GameObject.Find("Player");
        destroyed = false;
    }
    public void Update()
    {
        if(!destroyed)
        {
            if(player.transform.position.z > (transform.position.z + 30.0f))
            {
                Destroy(gameObject);
                destroyed = true;
            }
        }
    }
}
