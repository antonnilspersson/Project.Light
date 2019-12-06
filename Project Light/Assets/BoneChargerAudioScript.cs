using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BoneChargerAudioScript : MonoBehaviour
{
    public AudioClip BoneWalk;
    public AudioClip BoneCharge;
    //public AudioClip BoneDying;

    public AudioSource BoneWalkAudio;
    public AudioSource BoneChargeAudio;
    //public AudioSource BoneDyingAudio;

    public bool charging;
    public bool hostile = false;
    //public bool dying = false;
    
    public AIChargeAttack BoneScript;
    public TargetScript BoneTarget;

    //private GameObject BoneCharger;

    void Start()
    {
        //BoneCharger = this.gameObject;

        BoneWalkAudio.clip = BoneWalk;
        BoneWalkAudio.loop = true;
        BoneWalkAudio.volume = 1.0f;

        BoneChargeAudio.clip = BoneCharge;
        BoneChargeAudio.loop = true;
        BoneChargeAudio.volume = 0.7f;

        //BoneDyingAudio.clip = BoneDying;
        //BoneDyingAudio.loop = false;
        //BoneDyingAudio.volume = 0.1f;
    }

    //void SetCharging()
    //{
    //    mediumBoiWalkAudio.Stop();
    //    mediumBoiWalkAudio.volume = 0.7f;
    //    mediumBoiWalkAudio.clip = mediumBoiCharge;
    //}

    //void SetWalking()
    //{
    //    mediumBoiWalkAudio.Stop();
    //    mediumBoiWalkAudio.clip = mediumBoiWalk;
    //}

    void Update()
    {
        //dying = BoneTarget.DeadMonster;
        charging = BoneScript.attacking;

        //if (dying)
        //{
        //    BoneDyingAudio.Play();
        //}

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
