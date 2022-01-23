using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class playerController : MonoBehaviour
{
    
    public float moveSpeed = 10.0f;
    
    public Rigidbody2D player;
    
    public AudioSource music;
    public AudioSource sfx1;
    public AudioSource sfx2;
    public AudioSource sfx3;

    public Text newText;
    public float timeGameStart = 100.0f;
    public float timeGameEnd = 100.0f;
    public float timeGameFinish = 100.0f;
    [SerializeField] private Image customImage1;
    [SerializeField] private Image customImage2;
    [SerializeField] private Image customImage3;
    private bool targetHit;

    private bool win;
    private bool lose;

    private bool audioPlaying = false;
    private bool clipPlaying = false;


    // Start is called before the first frame update
    void Start()
    {
        Application.targetFrameRate = 60;

        //targetHit = GameObject.Find("target").GetComponent<targetController>();

        customImage2.enabled = false;
        customImage3.enabled = false;
        music = GetComponent<AudioSource>();
        //music.Play();
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        MovePlayer();

        if (Input.GetKey("escape"))
        {
            Application.Quit();
        }
        if(timeGameFinish > 1)
        {
            timeGameFinish -= Time.deltaTime;
            float seconds = Mathf.FloorToInt(timeGameFinish % 60);
            string timeSeconds = (seconds-1).ToString();
            
            if(timeGameFinish < timeGameStart)
            {
                newText.text = timeSeconds;
            }
            else
            {
                newText.text = "";
            }
        }

        if (targetHit == true && lose != true)
        {
            timeGameFinish = 0;
            //Debug.Log("gameEnd win");
            customImage2.enabled = true;
            playSound1();
            clipPlaying = true;
            music.Stop();
        }
        else if(targetHit == false && timeGameFinish < 2 && win != true)
        {
            timeGameFinish = 0;
            //Debug.Log("gameEnd Lose");
            customImage3.enabled = true;
            playSound2();
            clipPlaying = true;
            music.Stop();
        }
        
        if(timeGameFinish > timeGameStart)
        {
            customImage1.enabled = true;
        }
        else
        {
            customImage1.enabled = false;
            playMusic();
            audioPlaying = true;
        }
        
    }

    public void MovePlayer()
    {
        player.velocity = new Vector2(Input.GetAxis("Horizontal"), Input.GetAxis("Vertical")) * moveSpeed;
    }

    public void targetImpact()
    {
        //Debug.Log("targetHit true");
        targetHit = true;
    }

    public void playMusic()
    {
        if(audioPlaying == false)
        {
            music.Play();
        }
    }

    public void playSound1()
    {
        if(clipPlaying == false)
        {
            //Debug.Log("sound1 supposedly played");
            sfx1.Play();
        }
    }
    
    public void playSound2()
    {
        if(clipPlaying == false)
        {
            //Debug.Log("sound2 supposedly played");
            sfx2.Play();
        }
    }
}
