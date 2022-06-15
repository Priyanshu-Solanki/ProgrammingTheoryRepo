using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CarSpawn : MonoBehaviour
{
    public GameObject[] enemyCar;
    public float carSpawnZ = 345f;
    private GameManager gameManager;
    

    public void OnTriggerEnter(Collider other)
    {
        if(other.gameObject.CompareTag("Player"))
        {
            SpawnEnemy();
            carSpawnZ += Random.Range(150,350);
            transform.position += new Vector3(0, 0, Random.Range(150.0f,300.0f));
        }

    }
    public void SpawnEnemy()
    {
        gameManager = GameObject.Find("GameManager").GetComponent<GameManager>();
        int spawnX = Random.Range(-2, 2);
        int index = Random.Range(0, enemyCar.Length);
        if(MainManager.instance.oneWay)
        {
            Instantiate(enemyCar[index], new Vector3(spawnX * 6, enemyCar[index].transform.position.y, carSpawnZ), enemyCar[index].transform.rotation * Quaternion.Euler(0, 180f, 0));
        }
        else if(MainManager.instance.twoWay)
        {
            if (spawnX < 0)
            {
                Instantiate(enemyCar[index], new Vector3(spawnX * 6, enemyCar[index].transform.position.y, carSpawnZ), enemyCar[index].transform.rotation);
            }
            else
            {
                Instantiate(enemyCar[index], new Vector3(spawnX * 6, enemyCar[index].transform.position.y, carSpawnZ), enemyCar[index].transform.rotation * Quaternion.Euler(0, 180f, 0));
            }
        }
  
    }
}
