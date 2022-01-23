using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class targetController : MonoBehaviour
{

    public float moveSpeed = 0.0f;
    public int moveUp = 1;
    //public float timeGameStart = 120.0f;
    //public float timeGameEnd = 820.0f;
    //public float timeGameFinish = 940.0f;
    private playerController playerConHit;
   

    // Start is called before the first frame update
    void Start()
    {
        playerConHit = GameObject.Find("character").GetComponent<playerController>();
        if(playerConHit != null)
        {
            Debug.Log("playerController Found");
        }
    }

    // Update is called once per frame
    void Update()
    {
        if(moveUp == 1)
        {
            transform.position = new Vector2(transform.position.x, transform.position.y+moveSpeed);
        }
        else
        {
            transform.position = new Vector2(transform.position.x, transform.position.y-moveSpeed);
        }

        /*
        if(timeGameFinish > 0)
        {
            timeGameFinish -= Time.deltaTime;
        }
        else
        {
            timeGameFinish = 0;
        }
        */
        
    }

    void OnCollisionEnter2D(Collision2D col)
    { 
        if(col.gameObject.tag == "wall")
        {
            moveUp = moveUp*-1;
            //Debug.Log("moveUp"+moveUp);
        }

        if(col.gameObject.tag == "bullet")
        {
            playerConHit.targetImpact();
            Debug.Log("target broke");
            Destroy(gameObject);
        }

    }

}
