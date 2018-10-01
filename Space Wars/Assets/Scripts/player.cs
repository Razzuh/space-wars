using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class player : MonoBehaviour {

    public GameObject bullet;
    public GameObject nose;
    public GameObject bulletPrefab;
    public GameObject bombPrefab;
    public GameObject minePrefab;
    public float turnRadiusSpeed;
    public float speed;
    public float bulletDelay;
    public float bombDelay;
    public float mineDelay;
    public const int maxHealth = 100;
    public int currentHealth = maxHealth;

    private float elapsedSinceShot;
    private float elapsedSinceBomb;
    private float elapsedSinceMine;
    private GameController gc;


    private bool Shooting = false;

    

	// Use this for initialization
	void Start () {
        //Output the current screen window width in the console
        Debug.Log("Screen Width : " + Screen.width);
        Debug.Log("Screen Height : " + Screen.height);

        GameObject gcObject = GameObject.FindWithTag("GameController");

        gc = gcObject.GetComponent<GameController>();
    }
	
	// Update is called once per frame
	void Update () {
        
        
        elapsedSinceShot += Time.deltaTime;
        elapsedSinceBomb += Time.deltaTime;
        elapsedSinceMine += Time.deltaTime;

        Shooting = isShooting();
        HandleInput();

        ResetValues();
       
	}

    private void HandleInput(){
        var x = Input.GetAxis("Horizontal") * Time.deltaTime * -turnRadiusSpeed;
        var z = Input.GetAxis("Vertical") * Time.deltaTime * speed;
        transform.Rotate(0, 0, x);
        transform.Translate(0, z, 0);
    }
    

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

    void OnTriggerEnter2D(Collider2D c)
    {
        if (c.gameObject.tag != "Bullet")
        {
            //transform.position = new Vector3(0, 0, 0);

            GetComponent<Rigidbody2D>().velocity = new Vector3(0, 0, 0);

            gc.LoseHealth();
        }
    }





    private void ResetValues()
    {
        Shooting = false;

        



    }

    

  



}
