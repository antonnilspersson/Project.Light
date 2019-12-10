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
        charging = this.gameObject.GetComponent<Minion>().bigBoiChargyChargy;
        //Debug.Log("'Big boi is charging' ---> " + charging.ToString());

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
