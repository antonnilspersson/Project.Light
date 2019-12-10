using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class WaterInteraction : MonoBehaviour
{
    // Water Variables
    public bool hasWater;

    // Common Variables
    private bool triggered;

    // Seed Variables
    private UnityEvent spawnSeeds;
    public GameObject smallSeed;
    private GameObject spawnedSeed;
    private Vector3 originPoint;
    private Vector3 lastPoint;
    public int groupSize = 1;
    public float seedRadius = 3f;
    public float personalSeedRadius = 2f;

    void Start()
    {
        if(spawnSeeds == null)
            spawnSeeds = new UnityEvent();

        spawnSeeds.AddListener(Seeds);
    }

    // Update is called once per frame
    void Update()
    {
        WaterMechanic();
    }

    void WaterMechanic()
    {
        if (triggered)
        {
            if (Input.GetKeyDown(KeyCode.G))
            {
                if (Inventory.water > 0)
                {
                    Inventory.seeds += 1;
                    Inventory.water -= 1;
                }
            }
        }
    }

    void Seeds()
    {
        if(smallSeed != null)
            CreateGroup();
    }

    void CreateGroup()
    {
        originPoint = gameObject.transform.position;

        for(int i = 0; i < groupSize; i++)
            CreateSeed();
    }

    void CreateSeed()
    {
        originPoint.x += Random.Range(-seedRadius, seedRadius);
        originPoint.z += Random.Range(-seedRadius, seedRadius);
        if(lastPoint != null)
            if(Vector3.Distance(originPoint, lastPoint) < personalSeedRadius)
            {
                originPoint.x += Random.Range(-seedRadius, seedRadius);
                originPoint.z += Random.Range(-seedRadius, seedRadius);
            }
        lastPoint = originPoint;
        spawnedSeed = (GameObject)Instantiate(smallSeed, originPoint, Quaternion.identity);
    }

    void GradeAndSeedSpawn()
    {
        spawnSeeds.Invoke();
    }

    private void OnTriggerEnter(Collider other)
    {
        if(other.gameObject.tag == "Inventory")
            triggered = true;
    }

    private void OnTriggerExit(Collider other)
    {
        if(other.gameObject.tag == "Inventory")
            triggered = false;
    }
}
