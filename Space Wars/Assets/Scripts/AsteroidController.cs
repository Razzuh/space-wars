using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AsteroidController : MonoBehaviour {

	//public GameObject smallAsteroid;

	private GameController gc;

	// Use this for initialization
	void Start () {
		GameObject gameControllerObject = GameObject.FindWithTag ("GameController");

		gc = gameControllerObject.GetComponent <GameController>();

		GetComponent<Rigidbody2D>().AddForce(transform.up * Random.Range(-50.0f, 150.0f));

		GetComponent<Rigidbody2D>().angularVelocity = Random.Range(-0.0f, 90.0f);
	}





    void OnCollisionEnter2D(Collision2D c)
    {
        if (c.gameObject.tag.Equals("Bullet"))
        {
            Destroy(c.gameObject);

            gc.DecreaseAsteroids();

            gc.AddScore();

            Destroy(gameObject);

            //if (tag.Equals ("LAsteroid"))
            //{
            //    //Instantiate(smallAsteroid, new Vector3(transform.position.x - .5f, transform.position.y - .5f, 0), Quaternion.Euler(0, 0, 90));

            //    //Instantiate(smallAsteroid, new Vector3(transform.position.x + .5f, transform.position.y + .0f, 0), Quaternion.Euler(0, 0, 0));

            //    //Instantiate(smallAsteroid, new Vector3(transform.position.x + .5f, transform.position.y - .5f, 0), Quaternion.Euler(0, 0, 270));

            //    //gc.SplitAsteroid();

            //} else
            //{
            //    gc.DecreaseAsteroids();
            //}
        }
    }
}
