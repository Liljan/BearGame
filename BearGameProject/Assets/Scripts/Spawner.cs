using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spawner : MonoBehaviour
{
    public GameObject m_ObjectToSpawn;
    public Transform m_SpawnLocation;

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
        GameObject spawnedObj = Instantiate(m_ObjectToSpawn, m_SpawnLocation.position, m_SpawnLocation.rotation);
        m_SpawnedObjects.Add(spawnedObj);
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
