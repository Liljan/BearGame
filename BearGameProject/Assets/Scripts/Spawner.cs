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

    private bool isGameplay = false;

    // Start is called before the first frame update
    void Start()
    {
        EventManager.StartListening("StartGame", StartGame);
        EventManager.StartListening("GameOver", EndGame);
        EventManager.StartListening("BearCompleted", SpawnObjects);
        EventManager.StartListening("BearFailed", SpawnObjects);
        EventManager.StartListening("ResetGame", ClearObjects);
    }

    private void StartGame()
    {
        isGameplay = true;
    }

    private void EndGame()
    {
        isGameplay = false;
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void SpawnObjects()
    {
        if(!isGameplay)
            return;

        GameObject spawnedObj = Instantiate(m_ObjectToSpawn, m_StartPoint.position, m_StartPoint.rotation);
        m_SpawnedObjects.Add(spawnedObj);
        m_ObjectIDsOnBelt.Add(spawnedObj);

        Mover mover = spawnedObj.GetComponentInChildren<Mover>();

        Debug.Assert(mover, "The spawned object has no Mover script");
        mover.SetStartPoint(m_StartPoint);
        mover.SetDropPoint(m_DropPoint);
        mover.SetEndPoint(m_EndPoint);

        mover.StartFalling();

        bool head = Random.value > 0.5 ? true : false;
        bool leftArm = Random.value > 0.5 ? true : false;
        bool rightArm = Random.value > 0.5 ? true : false;
        bool leftLeg = Random.value > 0.5 ? true : false;
        bool rightLeg = Random.value > 0.5 ? true : false;

        // Handle the boring special case
        if (head && leftArm && rightArm && leftLeg && rightLeg)
        {
            head = false;
        }

        BearScript bear = spawnedObj.GetComponentInChildren<BearScript>();
        bear.SetupBearParameters(head, leftArm, rightArm, leftLeg, rightLeg);

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

        isGameplay = false;
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
