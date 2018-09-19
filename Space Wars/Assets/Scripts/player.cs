using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class player : MonoBehaviour {


    public GameObject nose;
    public GameObject bulletPrefab;
    public GameObject bombPrefab;
    public GameObject minePrefab;
    public float turnRadiusSpeed;
    public float speed;
    public float bulletDelay;
    public float bombDelay;
    public float mineDelay;

    private float elapsedSinceShot;
    private float elapsedSinceBomb;
    private float elapsedSinceMine;

    //public float boostSpeed; boosting wip 9/19/18
    //public float boostTimer; boosting wip 9/19/18

    private bool Shooting = false;

    //private bool Boosting = false; boosting wip 9/19/18

	// Use this for initialization
	void Start () {
        //Output the current screen window width in the console
        Debug.Log("Screen Width : " + Screen.width);
        Debug.Log("Screen Height : " + Screen.height);
	}
	
	// Update is called once per frame
	void Update () {
        HandleInput();
        // Boosting = isBoosting(); boosting wip 9/19/18
        elapsedSinceShot += Time.deltaTime;
        elapsedSinceBomb += Time.deltaTime;
        elapsedSinceMine += Time.deltaTime;

        Shooting = isShooting();


        ResetValues();
       
	}

    private void HandleInput(){
        var x = Input.GetAxis("Horizontal") * Time.deltaTime * -turnRadiusSpeed;
        var z = Input.GetAxis("Vertical") * Time.deltaTime * speed;
        transform.Rotate(0, 0, x);
        transform.Translate(0, z, 0);
    }

    /* private bool isBoosting(){           boosting wip 9/19/18
        if(Input.GetKey("right shift") == true){
            boosting = true;
            speed +=  boostSpeed;
            float boostTime += Time.deltaTime;
            if (boostTime >= boostTimer){
                speed -= boostSpeed;
                time = 0;
                Debug.Log(boostSpeed);
                boosting = false;
            }

            return true;
        } else
        {
            var z = Input.GetAxis("Vertical") * Time.deltaTime * speed;
            return false;
        }
        
    }*/

    private bool isShooting(){
        

        if (Input.GetKey("space") == true)
        {
            if (elapsedSinceShot >= bulletDelay)
            {
                bulletPrefab.transform.position = nose.transform.position;
                bulletPrefab.transform.rotation = transform.rotation;
                Instantiate(bulletPrefab);
                elapsedSinceShot = 0.0f;
                return true;
            }
            else
            {
                return false;
            
            }
            

        }
        else if(Input.GetKeyDown("left shift") == true)
        {

            if (elapsedSinceBomb >= bombDelay)
            {
                Instantiate(bombPrefab, transform.position, transform.rotation);
                elapsedSinceBomb = 0.0f;
                return true;
            }else{
                return false;
            }
        }
        else if (Input.GetKeyDown(KeyCode.E) == true)
        {
            if (elapsedSinceMine >= mineDelay)
            {
                minePrefab.transform.position = transform.position;
                Instantiate(minePrefab);
                elapsedSinceMine = 0.0f;
                return true;
            }
            else 
            { 
                return false; 
            }


        }else{
            
            return false;
        }

        
            
    }
    private void ResetValues()
    {
        Shooting = false;

        // Boosting = false; 9/19/18



    }



  



}
