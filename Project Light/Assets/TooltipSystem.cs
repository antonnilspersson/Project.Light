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

    public Inventory inventory;


    GameObject item;
    GameObject plant;
    PlaceHolderPickup php;

    void Start()
    {
        iText.text = "";
        pText.text = "";
    }

    // Update is called once per frame
    void Update()
    {
        TooltipUsable();
    }


    void TooltipUsable()
    {
        LayerMask iMask = LayerMask.GetMask("Usable");
        LayerMask pMask = LayerMask.GetMask("Item");

        RaycastHit hit;

        if (Physics.SphereCast(tooltipCam.transform.position - tooltipCam.transform.forward * 2, 1f, tooltipCam.transform.forward, out hit, 3f, iMask))
        {
            Debug.Log(hit.transform.name);


            iText.text = "Press [E] to loot "+ hit.transform.name;
        }
        else
        {
            iText.text = "";
        }

        if (Physics.SphereCast(tooltipCam.transform.position - tooltipCam.transform.forward * 2, 1f, tooltipCam.transform.forward, out hit, 5f, pMask))
        {
            Debug.Log(hit.transform.name);

            plant = hit.transform.gameObject;

            if (Inventory.water <= 0)
                pText.text = "Press [Q] to pick up the plant. \n Find water to gain seeds";

            if (Inventory.water > 0)
                    pText.text = "Press [Q] to pick up the plant. \n Press [G] to water the plant";
        }
        else
        {
            pText.text = "";
            plant = null;
        }
    }

    void TooltipPlant()
    {
        RaycastHit hit;

        //if (Physics.Raycast(tooltipCam.transform.position, tooltipCam.transform.forward, out hit, range, pMask))
        //{
        //    Debug.Log(hit.transform.name);

        //    plant = hit.transform.gameObject;

        //    text.text = "Press [Q] to loot " + plant.name;
        //}
        
    }
}
