using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlantHealthAdjuster : MonoBehaviour
{
    // Health Variables
    private GameObject player;
    private MovementScript playerScript;
    public int regen = 2;
    private bool Enabled = false;
    public Text text;
    Color color;

    // Temp Variables - should be added to player class
    private float maxOxygen = 100f;
    private float minOxygen = 0f;

    void Start()
    {
        player = GameObject.FindWithTag("Player");
        playerScript = player.GetComponent<MovementScript>();
        text.text = "Oxygen levels going down";
        color = text.color;
    }

    void Update()
    {
        if (Enabled)
        {
            if(playerScript.Oxygen <= maxOxygen)
                playerScript.Oxygen += regen * Time.deltaTime;

            if(playerScript.Oxygen > maxOxygen)
                playerScript.Oxygen = maxOxygen;

            color.a -= Time.deltaTime;
            if (color.a <= 0)
                color.a = 0;
        }
        else
        {
            color.a += Time.deltaTime;

            if(color.a >= 0.2f)
                color.a = Mathf.Lerp(0.2f, 1, Mathf.PingPong((Time.time), 1));
        }

        text.color = color;
    }

    // Does not work when you leave one plants area but is still
    // inside another ones - needs fixing
    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Player")
        {
            Enabled = true;
        } 
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.gameObject.tag == "Player")
        {
            Enabled = false;
        }
    }
}
