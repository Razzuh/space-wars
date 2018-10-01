using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class leftSide : MonoBehaviour {

    // Use this for initialization
    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.tag == "Player")
        {
            other.gameObject.transform.position = new Vector3(10.4f, other.gameObject.transform.position.y, -.5f);
        }
    }

}

