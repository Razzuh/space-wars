using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ProjectileSpawn : MonoBehaviour
{

    public Transform destroyPoint;
    private GameObject cloneProj;
    public float FireRate;
    public float FireSpeed;
    private Rigidbody2D rb;


    // Use this for initialization
    void Start()
    {   rb = GetComponent<Rigidbody2D>();
       

    }

    // Update is called once per frame
    void Update()
    {

        rb.velocity = transform.up * FireSpeed;

        Destroy();


    }

    private void Destroy()
    {
        Vector3 ProjPos = transform.position;

        if (ProjPos.x >= destroyPoint.position.x || ProjPos.x <= -destroyPoint.position.x)
        {
            Destroy(this.gameObject);
        }
        else if (ProjPos.y >= destroyPoint.position.y || ProjPos.y <= -destroyPoint.position.y)
        {
            Destroy(this.gameObject);
        }  
    }

}