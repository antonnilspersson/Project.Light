using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FinalPlant : MonoBehaviour
{
    public EnemyManager em;
    public WinManager wm;
    public PlantManager pm;
    public GameObject mainPlant;
    public GameObject hand;
    public Camera cam;
    private bool triggered = false;

    bool IsMainPlantHeld()
    {
        if(mainPlant.transform.parent == hand)
            return true;
        return false;
    }

    private bool IsLookingAtSpot()
    {
        Ray ray = new Ray(cam.transform.position, cam.transform.forward);
        RaycastHit hit;
        if(Physics.Raycast(ray, out hit, 4))
            if(hit.collider.gameObject == gameObject)
                return true;
        return false;
    }

    void OnTriggerEnter(Collider other)
    {
        if(other.gameObject.tag == "Player")
            if (pm.currentPlanted >= pm.maxPlanted)
                wm.HasWon = true;  
    }
}
