using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HelpersLittleHelper : MonoBehaviour
{
    public Text helperText;
    public GameObject gun;
    public GameObject crossbow;

    // Update is called once per frame
    void Update()
    {
        if(!gun.activeInHierarchy && !crossbow.activeInHierarchy)
            helperText.text = "";
    }
}
