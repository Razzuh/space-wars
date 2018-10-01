using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class mine : MonoBehaviour {

    public  float rotationspeed;
	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
        
        transform.Rotate(0, 0, rotationspeed);
	}
}
