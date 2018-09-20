using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class stroids : MonoBehaviour {
    public float StroidRotate;
    public float StroidSpeed;
    private float rotate;
    private Rigidbody2D rigb;

    // Use this for initialization
    void Start () {
        rigb = GetComponent<Rigidbody2D>();
       
        rotate = Random.Range(-StroidRotate, StroidRotate);
        rigb.velocity = transform.forward * StroidSpeed;
    }
	
	// Update is called once per frame
	void Update () {
        transform.Rotate(0, 0, rotate);
    }
}
