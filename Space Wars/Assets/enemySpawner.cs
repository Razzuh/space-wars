using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class enemySpawner : MonoBehaviour {


    

    public GameObject SpawnPoint;
    public GameObject DestoryPoint;

    
   
    public GameObject[] enemyPrefab;
  


    public float spawnMin;
    public float spawnMax;
    private float sinceLastSpawn;


    private bool spawnEnemy = false;

    // Use this for initialization
    void Start()
    {


    }

    // Update is called once per frame
    void Update()
    {


        spawnEnemy = spawnEnemies();
        spawnEnemies();
        sinceLastSpawn += Time.deltaTime;

       
    }







    private bool spawnEnemies()
    {

        if (sinceLastSpawn >= spawnMin)
        {

            float x = Random.Range(-DestoryPoint.transform.position.x, DestoryPoint.transform.position.x);
            float y = Random.Range(-DestoryPoint.transform.position.y, DestoryPoint.transform.position.y);



         Instantiate(enemyPrefab[UnityEngine.Random.Range(0, enemyPrefab.Length - 1)], new Vector3(x, y, 0), Quaternion.identity);

        



            sinceLastSpawn = 0.0f;
            return true;
        }

        else { return false; }

    }



   
}
