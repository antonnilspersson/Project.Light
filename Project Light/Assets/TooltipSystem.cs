using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TooltipSystem : MonoBehaviour
{
    public Camera tooltipCam;

    private float range = 4;

    public Text iText;
    public Text pText;
    public Text sText;

    public Inventory inventory;


    GameObject item;
    GameObject plant;
    GameObject plantspot;
    PlaceHolderPickup php;

    void Start()
    {
        iText.text = "";
        pText.text = "";
        sText.text = "";
    }

    void Update()
    {
        TooltipLoot();
        TooltipPlant();
        pSpot();
    }


    void TooltipLoot()
    {
        LayerMask iMask = LayerMask.GetMask("Usable");
        
        LayerMask sMask = LayerMask.GetMask("UsableObject");

        RaycastHit hit;

        if (Physics.SphereCast(tooltipCam.transform.position - tooltipCam.transform.forward * 2, 1f, tooltipCam.transform.forward, out hit, 3f, iMask))
        {
            GameObject target = hit.transform.gameObject;

            LootScript loot;


            loot = target.GetComponent<LootScript>();

            iText.text = "Press [E] to loot " + loot.itemName;
        }
        else
        {
            iText.text = "";
        }
    }

    void TooltipPlant()
    {
        RaycastHit hit;
        LayerMask pMask = LayerMask.GetMask("Item");

        if (Physics.SphereCast(tooltipCam.transform.position - tooltipCam.transform.forward * 2, 1f, tooltipCam.transform.forward, out hit, 5f, pMask))
        {
            plant = hit.transform.gameObject;

            if (Inventory.water <= 0)
                pText.text = "Press [Q] to pick up the plant. \n Find water to gather seeds";

            if (Inventory.water > 0)
                pText.text = "Press [Q] to pick up the plant. \n Press [G] to water the plant";
        }
        else
        {
            pText.text = "";
            plant = null;
        }

    }

    void pSpot()
    {
        RaycastHit hit;
        LayerMask sMask = LayerMask.GetMask("UsableObject");

        if (Physics.SphereCast(tooltipCam.transform.position - tooltipCam.transform.forward * 2, 1f, tooltipCam.transform.forward, out hit, 5f, sMask))
        {
            plantspot = hit.transform.gameObject;
            PlantSeed seed = plantspot.GetComponent<PlantSeed>();

            if(!seed.spawned)
            {
                if (Inventory.seeds <= 0)
                    sText.text = "Require seeds to plant a new tree.";

                if (Inventory.seeds > 0)
                    sText.text = "Press [E] to plant the seed.";
            }
            else
                sText.text = "";
        }
        else
        {
            sText.text = "";
            plantspot = null;
        }
    }
}
