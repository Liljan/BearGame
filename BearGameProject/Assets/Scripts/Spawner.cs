using System.Collections;
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
    private List<GameObject> m_ObjectIDsOnBelt = new List<GameObject>();

    // Start is called before the first frame update
    void Start()
    {
        //EventManager.StartListening("TimesUp", ClearObjects);
        EventManager.StartListening("ResetGame", ClearObjects);
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void SpawnObjects()
    {
        GameObject spawnedObj = Instantiate(m_ObjectToSpawn, m_StartPoint.position, m_StartPoint.rotation);
        int ID = spawnedObj.GetInstanceID();
        m_SpawnedObjects.Add(spawnedObj);
        m_ObjectIDsOnBelt.Add(spawnedObj);

        Mover mover = spawnedObj.GetComponentInChildren<Mover>();

        Debug.Assert(mover, "The spawned object has no Mover script");
        mover.SetStartPoint(m_StartPoint);
        mover.SetDropPoint(m_DropPoint);
        mover.SetEndPoint(m_EndPoint);

        mover.StartFalling();

        EventManager.TriggerEvent("BearSpawn");
    }


    public void ClearObjects()
    {
        foreach(GameObject gameObject in m_SpawnedObjects)
        {
            Destroy(gameObject);
        }

        // Use the garbage collection
        m_SpawnedObjects.Clear();
        m_ObjectIDsOnBelt.Clear();
    }

    public void RemoveBearFromBelt(GameObject obj)
    {
        m_ObjectIDsOnBelt.Remove(obj);
    }

    public bool HasObjectsOnBelt()
    {
        return m_ObjectIDsOnBelt.Count != 0;
    }

}
