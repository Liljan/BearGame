﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spawner : MonoBehaviour
{
    public GameObject m_ObjectToSpawn;

    public Transform m_StartPoint;
    public Transform m_DropPoint;
    public Transform m_EndPoint;

    public float m_fFallSpeed;
    public float m_fConveyorBeltSpeed;

    private List<GameObject> m_SpawnedObjects = new List<GameObject>();

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void SpawnObjects()
    {
        GameObject spawnedObj = Instantiate(m_ObjectToSpawn, m_StartPoint.position, m_StartPoint.rotation);
        m_SpawnedObjects.Add(spawnedObj);

        Mover mover = spawnedObj.GetComponent<Mover>();

        Debug.Assert(mover, "The spawned object has no Mover script");
        mover.SetStartPoint(m_StartPoint);
        mover.SetDropPoint(m_DropPoint);
        mover.SetEndPoint(m_EndPoint);

        mover.StartFalling();
    }


    public void ClearObjects()
    {
        foreach(GameObject gameObject in m_SpawnedObjects)
        {
            Destroy(gameObject);
        }

        // Use the garbage collection
        m_SpawnedObjects.Clear();
    }

}
