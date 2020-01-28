﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LootScript : MonoBehaviour
{
    bool Triggered = false;
    public bool pickedUp = false;
    Color startColor = Color.white;
    Color oldColor;
    Renderer render;

    public string itemName;
    string name;
    Inventory inventory;
    GameObject player;
    GameObject health;
    MovementScript healthS;
    HeatMapManager hm;


    private void Start()
    {
        hm = GameObject.FindGameObjectWithTag("GM").GetComponent<HeatMapManager>();
        player = GameObject.FindGameObjectWithTag("Inventory");
        inventory = player.GetComponent<Inventory>();
        health = GameObject.FindGameObjectWithTag("Player");
        healthS = health.GetComponent<MovementScript>();
        render = GetComponent<Renderer>();
        oldColor = startColor;
        render.material.color = oldColor;
    }

    void Update()
    {
        if (Triggered)
        {
            if (Input.GetKeyDown(KeyCode.E))
            {
                //Interact();
                render.material.color = Color.green;
                if(hm.currentCube != null) hm.currentCube.AddItems(15);
                AmmoAdd();
            }
            else
                render.material.color = Color.yellow;
        }
    }


    void AmmoAdd()
    {
        if(itemName == "Crossbow ammo")
        {
            inventory.cbAmmoTotal += Random.Range(5,8);
            Destroy(gameObject);
        }
        if (itemName == "Rifle ammo")
        {
            inventory.rAmmoTotal += Random.Range(5, 8);
            Destroy(gameObject);
        }
        if (itemName == "Revolver ammo")
        {
            inventory.gAmmoTotal += Random.Range(5, 8);
            Destroy(gameObject);
        }
        if (itemName == "Crossbow")
        {
            inventory.crossbow = 1;
            Destroy(gameObject);
        }
        if(itemName == "Revolver")
        {
            inventory.gun = 1;
            Destroy(gameObject);
        }
        if (itemName == "Rifle")
        {
            inventory.rifle = 1;
            Destroy(gameObject);
        }
        if (itemName == "Water")
        {
            Inventory.water += 1;
            Destroy(gameObject);
        }
        if (itemName == "First aid kit")
        {
            healthS.health += 50;
            Destroy(gameObject);
        }
        if(itemName == "Seed")
        {
            Inventory.seeds += 1;
            Destroy(gameObject);
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if(other.gameObject.CompareTag("Inventory"))
        {
            oldColor = render.material.color;
            render.material.color = Color.yellow;
            Triggered = true;
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.gameObject.CompareTag("Inventory"))
        {
            render.material.color = startColor;

            Triggered = false;
        }
        
    }
    //public void Interact()
    //{
    //    Debug.Log("Picking up" + item.name);
    //    bool wasPickeUp = Inventory.instance.Add(item);

    //    if (wasPickeUp)
    //        Destroy(gameObject);
    //}
}
