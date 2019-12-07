using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TestSpawnBoss : MonoBehaviour
{
    public GameObject player;

    void Update()
    {
        var direction = player.transform.position - transform.position;
        direction.Normalize();
    }
}
