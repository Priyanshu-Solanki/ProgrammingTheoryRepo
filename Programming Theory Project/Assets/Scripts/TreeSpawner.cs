using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TreeSpawner : MonoBehaviour
{
        public GameObject[] treePrefabs;
        private int index;
        private int spawnZ = 0;


    public void Start()
    {
        for(int i = 0; i<30; i++)
        {
            SpawnTree();
        }
    }
    public void OnTriggerEnter(Collider other)
        {
            SpawnTree();
            transform.position += new Vector3(0, 0, 5);
        }
        public void SpawnTree()
        {
            index = Random.Range(0, treePrefabs.Length);
            Instantiate(treePrefabs[index], new Vector3(Random.Range(-80,-20),0, spawnZ), treePrefabs[index].transform.rotation);
            Instantiate(treePrefabs[index], new Vector3(Random.Range(15,80), 0, spawnZ), treePrefabs[index].transform.rotation);
        spawnZ += 5;
        }

}
