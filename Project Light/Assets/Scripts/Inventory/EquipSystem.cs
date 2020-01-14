using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class EquipSystem : MonoBehaviour
{
    public List<GameObject> equippable;

    public PlaceHolderPickup plant;
    Inventory ammo;

    public int equipSlot = 1;

    private ShootScript crossbow;
    private GunScript revolver;
    private GunScript rifle;

    private void Start()
    {
        ammo = gameObject.GetComponent<Inventory>();
        equippable[0] = null;

        crossbow = equippable[1].GetComponent<ShootScript>();
        revolver = equippable[2].GetComponent<GunScript>();
        rifle = equippable[3].GetComponent<GunScript>();
    }

    void Update()
    {
        EquipSlot();
        Equipped();
    }

    private void EquipSlot()
    {
        if (Input.GetKeyDown(KeyCode.Alpha1) || PlaceHolderPickup.PickedUp)
            if (!rifle.isReloading && !revolver.isReloading && !crossbow.isReloading)
                equipSlot = 1;

        if (Input.GetKeyDown(KeyCode.Alpha2) && ammo.crossbow > 0)
            if (!rifle.isReloading && !revolver.isReloading)
            {
                if (PlaceHolderPickup.PickedUp)
                    plant.ReleaseItem();

                equipSlot = 2;
            }

        if (Input.GetKeyDown(KeyCode.Alpha3) && ammo.gun > 0)
            if (!rifle.isReloading && !crossbow.isReloading)
            {
                if (PlaceHolderPickup.PickedUp)
                    plant.ReleaseItem();

                equipSlot = 3;
            }

        if (Input.GetKeyDown(KeyCode.Alpha4) && ammo.rifle > 0)
            if(!revolver.isReloading && !crossbow.isReloading)
            {
                if (PlaceHolderPickup.PickedUp)
                    plant.ReleaseItem();

                equipSlot = 4;
            }
    }

    private void Equipped()
    {

        if (equipSlot == 2)
        {
            equippable[1].SetActive(true);
        }
        else
            equippable[1].SetActive(false);

        if (equipSlot == 3)
        {
            equippable[2].SetActive(true);

        }
        else
        {
            equippable[2].SetActive(false);
        }

        if (equipSlot == 4)
        {
            equippable[3].SetActive(true);

        }
        else
        {
            equippable[3].SetActive(false);

        }

    }
}
