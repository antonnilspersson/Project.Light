using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LightDegeneration : MonoBehaviour
{
    public Light light;
    public MovementScript player;
    public float maxRange = 20;
    public float minRange = 5;
    private float currentRange;

    void Start()
    {
        currentRange = maxRange;
    }

    void Update()
    {
        currentRange = (player.Oxygen/100) * maxRange;
        if(currentRange <= minRange)
            currentRange = minRange;

        light.range = currentRange;
    }
}
