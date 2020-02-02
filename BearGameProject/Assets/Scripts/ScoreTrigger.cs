using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ScoreTrigger : MonoBehaviour
{
    public Spawner m_Spawner;

    // Start is called before the first frame update
    void Start()
    {
        Debug.Assert(m_Spawner, "The Score trigger must have a Spawner attached to it");
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnTriggerEnter(Collider bearCollider)
    {
        Debug.Log("BearFinished");

        if(bearCollider.tag != "Bear")
            return;

        // Validate the bear
        BearScript bear = bearCollider.gameObject.GetComponentInChildren<BearScript>();

        if (bear.PassedGoal)
            return;

        if(bear.IsBearCompleted())
        {
            EventManager.TriggerEvent("BearScore");
        }
        else
        {
            EventManager.TriggerEvent("BearFailed");
        }

        bear.PassedGoal = true;

        // Hack. To reach the base of the object (the parent) the Bear hierarchy structure
        // must look like this.
        GameObject objectBase = bear.transform.parent.gameObject;
        m_Spawner.RemoveBearFromBelt(objectBase);
    }
}
