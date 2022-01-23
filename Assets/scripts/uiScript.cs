using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class uiScript : MonoBehaviour
{

    public Text newText;
    public float timeGameStart = 100.0f;
    public float timeGameEnd = 100.0f;
    public float timeGameFinish = 100.0f;
    [SerializeField] private Image customImage1;
    [SerializeField] private Image customImage2;
    [SerializeField] private Image customImage3;
    public bool targetHit;

    // Start is called before the first frame update
    void Start()
    {
        customImage2.enabled = false;
        customImage3.enabled = false;
    }

    // Update is called once per frame
    void Update()
    {
        if(timeGameFinish > 1)
        {
            timeGameFinish -= Time.deltaTime;
        }

        if (targetHit == true && timeGameFinish > 2)
        {
            timeGameFinish = 0;
            Debug.Log("gameEnd");
            customImage2.enabled = true;
        }
        else if(targetHit == false && timeGameFinish < 2)
        {
            timeGameFinish = 0;
            Debug.Log("gameEnd");
            customImage3.enabled = true;
        }
        
        if(timeGameFinish > timeGameStart)
        {
            customImage1.enabled = true;
        }
        else
        {
            customImage1.enabled = false;
        }
        

        float seconds = Mathf.FloorToInt(timeGameFinish % 60);
        string timeSeconds = seconds.ToString();
        newText.text = timeSeconds;
    }
}
