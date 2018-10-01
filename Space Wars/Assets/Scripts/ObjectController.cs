using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObjectController : MonoBehaviour {
	
	// Update is called once per frame
	void Update () {
		if(transform.position.x > 9)
        {
            transform.position = new Vector3(-9, transform.position.y, 0);
        }
        else if(transform.position.x < -9)
        {
            transform.position = new Vector3(9, transform.position.y, 0);
        }
        else if(transform.position.y > 10)
        {
            transform.position = new Vector3(transform.position.x, -10, 0);
        }
        else if(transform.position.y < -10)
        {
            transform.position = new Vector3(transform.position.x, 10, 0);
        }
	}
}
