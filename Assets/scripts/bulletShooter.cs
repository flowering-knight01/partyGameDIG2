using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class bulletShooter : MonoBehaviour
{   
    //public GameObject bullet;
    public float bulletSpeed = 100f;
    public Rigidbody2D bulletRb;
    public GameObject targetObject;

    // Start is called before the first frame update
    void Start()
    {
        bulletRb.velocity = transform.right * bulletSpeed;
    }

    void OnCollisionEnter2D(Collision2D col)
    {
        if(col.gameObject.tag == "target")
        {
            Destroy(gameObject);
        }
        
        if(col.gameObject.tag == "wall")
        {
            Destroy(gameObject);
        }
    }
}
