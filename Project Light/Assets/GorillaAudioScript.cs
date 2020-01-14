using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GorillaAudioScript : MonoBehaviour
{
    public AudioClip GorillaWalk;
    public AudioClip GorillaCharge;

    public AudioSource GorillaWalkAudio;
    public AudioSource GorillaChargeAudio;

    public bool charging;
    public bool hostile = false;

    public AIChargeAttack GorillaChargeScript;


    void Start()
    {
        GorillaWalkAudio.clip = GorillaWalk;
        GorillaWalkAudio.loop = true;
        GorillaWalkAudio.volume = 0.4f;
        GorillaWalkAudio.pitch = 0.5f;

        GorillaChargeAudio.clip = GorillaCharge;
        GorillaChargeAudio.loop = true;
        GorillaChargeAudio.volume = 0.4f;
        GorillaChargeAudio.pitch = 0.5f;
    }


    void Update()
    {
        charging = GorillaChargeScript.attacking;

        if (charging && hostile)
        {
            GorillaChargeAudio.Play();
            hostile = false;

        }
        else if (!charging && !hostile)
        {
            GorillaWalkAudio.Play();
            hostile = true;
        }


    }
}
