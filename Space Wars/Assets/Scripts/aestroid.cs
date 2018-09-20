using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class aestroid : MonoBehaviour {

    public GameObject SpawnPoint;
    public GameObject DestoryPoint;
    public GameObject StroidPrefab;
    public float spawnMin;
    public float spawnMax;
    private float sinceLastSpawn;
  
   
    private bool spawnAsteriod = false; 
    
	// Use this for initialization
	void Start () {
        

    }
	
	// Update is called once per frame
	void Update () {
        
        
        spawnAsteriod = spawnStroid();
        spawnStroid();
        sinceLastSpawn += Time.deltaTime;
    }
    private bool spawnStroid ()
    {
        
        if (sinceLastSpawn >= spawnMin)
        {
            
            float x = Random.Range(-DestoryPoint.transform.position.x, DestoryPoint.transform.position.x);
            float y = Random.Range(-DestoryPoint.transform.position.y, DestoryPoint.transform.position.y);
            Instantiate(StroidPrefab, new Vector3(x, y,0), Quaternion.identity);
            sinceLastSpawn = 0.0f;
            return true;
        }
        else { return false; }

    }


}
