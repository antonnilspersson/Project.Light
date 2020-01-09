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

    public bool playOnce;
    

    void Start()
    {
        BoneWalkAudio.clip = BoneWalk;
        BoneWalkAudio.loop = true;
        BoneWalkAudio.volume = 0.09f;

        BoneChargeAudio.clip = BoneCharge;
        BoneChargeAudio.loop = true;
        BoneChargeAudio.volume = 0.06f;
    }
    

    void Update()
    {
        charging = this.gameObject.GetComponent<Minion>().bigBoiChargyChargy;

        //if(this.gameObject.GetComponent<Minion>().distanceToPlayer <= 25 && !playOnce)
        //{
        //    FindObjectOfType<AudioManager>().Play("Mystery", 0f, 0.5f);
        //    playOnce = true;
        //}

        if (charging && hostile)
        {
            BoneChargeAudio.Play();
            BoneWalkAudio.Stop();
            hostile = false;

        }
        else if (!charging && !hostile)
        {
            BoneWalkAudio.Play();
            BoneChargeAudio.Stop();
            hostile = true;
        }


    }
}
