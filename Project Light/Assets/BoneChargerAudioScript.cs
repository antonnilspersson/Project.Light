using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BoneChargerAudioScript : MonoBehaviour
{
    public AudioClip BoneWalk;
    public AudioClip BoneCharge;

    public AudioSource BoneWalkAudio;
    public AudioSource BoneChargeAudio;

    public bool charging;
    public bool hostile = false;
    
    public AIChargeAttack BoneScript;
    public TargetScript BoneTarget;
    

    void Start()
    {

        BoneWalkAudio.clip = BoneWalk;
        BoneWalkAudio.loop = true;
        BoneWalkAudio.volume = 1.0f;

        BoneChargeAudio.clip = BoneCharge;
        BoneChargeAudio.loop = true;
        BoneChargeAudio.volume = 0.7f;
        
    }
    

    void Update()
    {
        charging = BoneScript.attacking;

        if (charging && hostile)
        {
            BoneChargeAudio.Play();
            hostile = false;

        }
        else if (!charging && !hostile)
        {
            BoneWalkAudio.Play();
            hostile = true;
        }


    }
}
