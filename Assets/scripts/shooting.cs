using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class shooting : MonoBehaviour
{

    public AudioSource sfxNoise;
    public Transform firePoint;
    public GameObject bullet;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if(Input.GetButtonDown("Fire1"))
        {
            fireTank();
        }
    }

    void fireTank()
    {
        Instantiate(bullet, firePoint.position, firePoint.rotation);
        sfxNoise.Play();
    }
}
