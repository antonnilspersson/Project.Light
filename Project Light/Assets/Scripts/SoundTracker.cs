using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SoundTracker : MonoBehaviour
{
    public int speed;
    
    public AudioClip grassWalk;
    public AudioClip grassJump;

    public AudioSource jumpSource;
    public AudioSource stepsSource;

    public bool[] WASD = new bool[4];
    public bool walking = false;

    private float oldTimer = 0f;
    private float newTimer = 0f;
    

    void Start()
    {
        for(int i = 0; i < 4; i++)
        {
            WASD[i] = false;
        }

        jumpSource.spatialBlend = 1;
        stepsSource.spatialBlend = 1;

        jumpSource.volume = 0.2f;
        stepsSource.volume = 0.6f;

        jumpSource.clip = grassJump;
        stepsSource.clip = grassWalk;
    }

    void PlayAmbience()
    {
        if(oldTimer == 0f)
        {
            oldTimer = Time.time;
        }
        
        newTimer = Time.time;

        int r = UnityEngine.Random.Range(1, 4);

        if(newTimer - oldTimer >= 180f)
        {
            if (r == 1)
                FindObjectOfType<AudioManager>().Play("Ambience1");
            else if (r == 2)
                FindObjectOfType<AudioManager>().Play("Ambience2");
            else if (r == 3)
                FindObjectOfType<AudioManager>().Play("Ambience4");
            else
                Debug.Log("Something went wrong in SOUNDTRACKER");
            
            oldTimer = 0f;
        }
    }

    void Update()
    {
        PlayAmbience();

        if (Input.GetKeyDown(KeyCode.W))
        {
            WASD[0] = true;
        }
        if (Input.GetKeyUp(KeyCode.W))
        {
            WASD[0] = false;
        }

        if (Input.GetKeyDown(KeyCode.A))
        {
            WASD[1] = true;
        }
        if (Input.GetKeyUp(KeyCode.A))
        {
            WASD[1] = false;
        }

        if (Input.GetKeyDown(KeyCode.S))
        {
            WASD[2] = true;
        }
        if (Input.GetKeyUp(KeyCode.S))
        {
            WASD[2] = false;
        }

        if (Input.GetKeyDown(KeyCode.D))
        {
            WASD[3] = true;
        }
        if (Input.GetKeyUp(KeyCode.D))
        {
            WASD[3] = false;
        }

        if (Input.GetKeyDown(KeyCode.Space) && !jumpSource.isPlaying) //JUMPING CHECK
        {
            jumpSource.PlayDelayed(0.7f);
        }

        if (Input.GetKeyDown(KeyCode.W) && !stepsSource.isPlaying) // WALKING CHECKS
        {
            stepsSource.Play();
        }

        if (Input.GetKeyDown(KeyCode.A) && !stepsSource.isPlaying) //-||-
        {
            stepsSource.Play();
        }

        if (Input.GetKeyDown(KeyCode.S) && !stepsSource.isPlaying)  //-||-
        {
            stepsSource.Play();
        }

        if (Input.GetKeyDown(KeyCode.D) && !stepsSource.isPlaying) //-||-
        {
            stepsSource.Play();
        }

        if (WASD[0] == false && WASD[1] == false && WASD[2] == false && WASD[3] == false) //CHECK IF NOT WALKING
        {
            stepsSource.Stop();
        }

    }
}
