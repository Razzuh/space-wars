using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class enemy : MonoBehaviour
{




    public GameObject player;

    public GameObject bulletPrefab;
    public GameObject bombPrefab;
    public GameObject minePrefab;


    public float attackTime;
    public float targetTimer;
    public float health;
    public float speed;
    public float bulletDelay;
    public float bombDelay;
    public float mineDelay;

    public bool shooter;
    public bool bomber;
    public bool miner;




    public Transform nose;
    private Rigidbody2D eb;

    private float timeElasped;
    private float attackTimer;
    private float elapsedSinceShot;
    private float elapsedSinceBomb;
    private float elapsedSinceMine;


    // Use this for initialization
    void Start()
    {
        eb = GetComponent<Rigidbody2D>();



    }



    // Update is called once per frame
    void FixedUpdate()
    {







        timeElasped += Time.deltaTime;
        elapsedSinceShot += Time.deltaTime;
        elapsedSinceBomb += Time.deltaTime;
        elapsedSinceMine += Time.deltaTime;


        aiMovement();

        if (timeElasped >= targetTimer)
        {
            eb.velocity = transform.up * speed;

            attackTimer += Time.deltaTime;
            Shooting();
            //reset timer
            if (attackTime <= attackTimer)
            {
                timeElasped = 0.0f;
                attackTimer = 0.0f;
            }


        }
        else
        {


            Debug.Log("shooting");
        }







        //transform.LookAt(Vector3.forward, new Vector3( nose.position.y - player.position.y, player.position.x, 0.0f));

        /*Vector3 enemyPos = transform.position;
        enemyPos.z = player.position.z - nose.position.z;

        transform.position = enemyPos;
        //transform.LookAt(player);
        */

    }


    public void aiMovement()
    {

        Vector3 playerPos = player.transform.position;

        Vector3 target = playerPos;

        Vector3 norTar = (target - transform.position).normalized;
        float angle = Mathf.Atan2(norTar.y, norTar.x) * Mathf.Rad2Deg;

        Quaternion rotation = new Quaternion();
        rotation.eulerAngles = new Vector3(0, 0, angle - 90);
        transform.rotation = rotation;



    }





    public bool Shooting()
    {
        if (shooter == true)
        {
            if (elapsedSinceShot >= bulletDelay)
            {
                bulletPrefab.transform.position = nose.transform.position;
                bulletPrefab.transform.rotation = transform.rotation;
                Instantiate(bulletPrefab);
                elapsedSinceShot = 0.0f;
                return true;
            }
        }
        else if (bomber == true)
        {

            if (elapsedSinceBomb >= bombDelay)
            {
                Instantiate(bombPrefab, transform.position, transform.rotation);
                elapsedSinceBomb = 0.0f;
                return true;
            }
            else
            {
                return false;
            }
        }
        else if (miner == true)
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


        }

        {
            return false;

        }
    }

    void OnCollisionEnter2D(Collision2D c)
    {
        if (c.gameObject.tag.Equals("Bullet"))
        {
            Destroy(c.gameObject);




            Destroy(gameObject);
        }
    }
}
