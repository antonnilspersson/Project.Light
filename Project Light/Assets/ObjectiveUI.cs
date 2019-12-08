using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ObjectiveUI : MonoBehaviour
{
    public PlantSeed[] seeds;
    public Text[] objectives;

    int somethingInt = 0;
    int warehouseInt = 0;
    int statueInt = 0;
    int trainInt = 0;
    int finalInt = 0;

    void Update()
    {
        if(seeds[0].spawned)
            somethingInt = 1;
        if (seeds[1].spawned)
            warehouseInt = 1;
        if (seeds[2].spawned)
            statueInt = 1;
        if (seeds[3].spawned)
            trainInt = 1;

        objectives[0].text = "Start: " + somethingInt + "/1";
        objectives[1].text = "Warehouse: " + trainInt + "/1";
        objectives[2].text = "Statue: " + statueInt + "/1";
        objectives[3].text = "Trainyard: " + warehouseInt + "/1";
        objectives[4].text = "";


        if (warehouseInt == 1 && statueInt == 1 && somethingInt == 1 && trainInt == 1)
        {
            objectives[0].text = "";
            objectives[1].text = "";
            objectives[2].text = "";
            objectives[3].text = "";
            objectives[4].text = "Mothertree: " + finalInt + "/0";
        }
    }
}
