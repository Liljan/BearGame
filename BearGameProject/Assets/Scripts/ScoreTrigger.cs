using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ScoreTrigger : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnTriggerEnter(Collider bearCollider)
    {
        if(bearCollider.tag != "Bear")
            return;

        // Validate the bear
        BearScript bear = bearCollider.gameObject.GetComponent<BearScript>();

        //if(bearIisComplete())
        //    EventManager.TriggerEvent("IncreaseScore");

        // Temp
        EventManager.TriggerEvent("IncreaseScore");
    }
}
