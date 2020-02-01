using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spawner : MonoBehaviour
{
    public GameObject m_ObjectToSpawn;
    public Transform m_SpawnLocation;

    private List<GameObject> m_SpawnedObjects;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void SpawnObject()
    {

    }


    public void Reset()
    {
        m_SpawnedObjects.Clear();
    }
    
}
