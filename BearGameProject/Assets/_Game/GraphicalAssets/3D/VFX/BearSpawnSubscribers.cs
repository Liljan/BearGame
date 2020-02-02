using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BearSpawnSubscribers : MonoBehaviour
{
    public GameObject spawnLight;
    public float bearLightTime = 0.1f;
    // Start is called before the first frame update
    void Start()
    {
        EventManager.StartListening("BearSpawn", BearHasSpawned);
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown("l"))
            EventManager.TriggerEvent("BearSpawn");
    }

    void BearHasSpawned()
    {
        StartCoroutine(BearLight());
    }

    IEnumerator BearLight()
    {
        spawnLight.SetActive(true);
        yield return new WaitForSeconds(bearLightTime);
        spawnLight.SetActive(false);
    }
}
