using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SoundTracker : MonoBehaviour
{
    public int speed;
    
    public AudioClip WalkFast;
    public AudioClip WalkSlow;
    public AudioClip grassJump;

    public AudioSource jumpSource;
    public AudioSource stepsSource;
    public AudioSource crouchSource;

    public bool[] WASD = new bool[4];
    public bool walking = false;

    private float oldTimer = 0f;
    private float newTimer = 0f;

    private bool isCrouching = false;

    private GameObject player;
    private MovementScript playerScript;

    void Start()
    {
        for(int i = 0; i < 4; i++)
        {
            WASD[i] = false;
        }

        jumpSource.spatialBlend = 1;
        stepsSource.spatialBlend = 1;
        crouchSource.spatialBlend = 1;

        jumpSource.volume = 0.1f;
        stepsSource.volume = 0.06f;
        crouchSource.volume = 0.12f;

        jumpSource.clip = grassJump;
        stepsSource.clip = WalkFast;
        crouchSource.clip = WalkSlow;

        player = GameObject.FindWithTag("Player");
        
    }

    void Update()
    {
        playerScript = player.GetComponent<MovementScript>();

        isCrouching = this.gameObject.GetComponent<MovementScript>().isCrouching;

        CheckForMovement();

        PlayAmbience();

        CheckForWalk();

        CheckForJump();
        
        MovementChange();
    }

    void PlayAmbience()
    {
        if (oldTimer == 0f)
        {
            oldTimer = Time.time;
        }

        newTimer = Time.time;

        int r = UnityEngine.Random.Range(1, 3);

        if (newTimer - oldTimer >= 180f)
        {
            if (r == 1)
                FindObjectOfType<AudioManager>().Play("Ambience1");
            else if (r == 2)
                FindObjectOfType<AudioManager>().Play("Ambience4");
            else
                Debug.Log("Something went wrong in SOUNDTRACKER");

            oldTimer = 0f;
        }
    }

    void MovementChange()
    {
        if(stepsSource.isPlaying && isCrouching)
        {
            crouchSource.Play();
            stepsSource.Stop();
        }

        if(crouchSource.isPlaying && !isCrouching)
        {
            crouchSource.Stop();
            stepsSource.Play();
        }
    }

    void CheckForMovement()
    {
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
    }

    void CheckForJump()
    {
        if (Input.GetKeyDown(KeyCode.Space) && !jumpSource.isPlaying) //JUMPING CHECK
        {
            jumpSource.PlayDelayed(0.5f);
        }

        if(playerScript.isJumping)
        {
            crouchSource.volume = 0.0f;
            stepsSource.volume = 0.0f;
        }

        if(!playerScript.isJumping)
        {
            stepsSource.volume = 0.06f;
            crouchSource.volume = 0.12f;
        }
        
    }
    
    void CheckForWalk()
    {
        if (Input.GetKeyDown(KeyCode.W) && !stepsSource.isPlaying) // WALKING CHECKS
        {
            if(isCrouching)
            {
                stepsSource.Stop();
                crouchSource.Play();
            }
            else if(!isCrouching)
            {
                stepsSource.Play();
                crouchSource.Stop();
            }
        }

        if (Input.GetKeyDown(KeyCode.A) && !stepsSource.isPlaying) //-||-
        {
            if (isCrouching)
            {
                stepsSource.Stop();
                crouchSource.Play();
            }
            else
            {
                stepsSource.Play();
                crouchSource.Stop();
            }
        }

        if (Input.GetKeyDown(KeyCode.S) && !stepsSource.isPlaying)  //-||-
        {
            if (isCrouching)
            {
                stepsSource.Stop();
                crouchSource.Play();
            }
            else
            {
                stepsSource.Play();
                crouchSource.Stop();
            }
        }

        if (Input.GetKeyDown(KeyCode.D) && !stepsSource.isPlaying) //-||-
        {
            if (isCrouching)
            {
                stepsSource.Stop();
                crouchSource.Play();
            }
            else
            {
                stepsSource.Play();
                crouchSource.Stop();
            }
        }

        if (WASD[0] == false && WASD[1] == false && WASD[2] == false && WASD[3] == false) //CHECK IF NOT WALKING
        {
            stepsSource.Stop();
            crouchSource.Stop();
        }
    }
}
