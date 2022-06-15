using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RoadSpawn : MonoBehaviour
{
    public GameObject road;
    [SerializeField] float roadspawnZ = 330;


    public void OnTriggerEnter(Collider other)
    {
        if(other.gameObject.CompareTag("Player"))
        {
            SpawnRoad();
            roadspawnZ += 30;
            transform.position += new Vector3(0, 0, 30);
        }

    }
    public void SpawnRoad()
    {
        Instantiate(road, new Vector3(0, 0, roadspawnZ), road.transform.rotation);
    }

}
