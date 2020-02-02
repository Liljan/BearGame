using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BearSpawnOnClick : MonoBehaviour
{
    public Spawner spawner;

    private void OnMouseDown()
    {
        Spawn();
    }

    void Spawn()
    {
        spawner.SpawnObjects();
    }
}
