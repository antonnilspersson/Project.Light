﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Inventory : MonoBehaviour
{
    public int gAmmoTotal;
    public int rAmmoTotal;
    public int cbAmmoTotal;
    public int gun = 0;
    public int rifle = 0;
    public int crossbow = 0;
    public static int seeds = 0;
    public static int water = 0;

    public Text waterText;
    public Text seedsText;

    void Update()
    {
        if (gAmmoTotal < 0)
            gAmmoTotal = 0;

        if (rAmmoTotal < 0)
            rAmmoTotal = 0;

        if (cbAmmoTotal < 0)
            cbAmmoTotal = 0;

        if (gun > 1)
            gun = 1;

        if (rifle > 1)
            rifle = 1;

        if (crossbow > 1)
            crossbow = 1;

        waterText.text = ":  " + water.ToString();
        seedsText.text = ":  " + seeds.ToString();
    }
}
