using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    float rotationSpeed = 100.0f;
    float speed = 3f;

    public GameObject bullet;

    private GameController gc;

	// Use this for initialization
	void Start ()
    {
        GameObject gcObject = GameObject.FindWithTag("GameController");

        gc = gcObject.GetComponent<GameController>();
	}
	
	// Update is called once per frame
	void FixedUpdate ()
    {
        transform.Rotate(0, 0, -Input.GetAxis("Horizontal") * rotationSpeed * Time.deltaTime);

        GetComponent<Rigidbody2D>().AddForce(transform.up * speed * Input.GetAxis("Vertical"));

        if (Input.GetKeyDown("space"))
            Shoot();
	}

    void OnTriggerEnter2D(Collider2D c)
    {
        if (c.gameObject.tag != "Bullet")
        {
            //transform.position = new Vector3(0, 0, 0);

            GetComponent<Rigidbody2D>().velocity = new Vector3(0, 0, 0);

            gc.LoseHealth();
        }
    }

    void Shoot()
    {
        Instantiate(bullet, new Vector3(transform.position.x, transform.position.y, 0), transform.rotation);
    }
}
