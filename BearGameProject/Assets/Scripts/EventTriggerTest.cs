using UnityEngine;
using System.Collections;

public class EventTriggerTest : MonoBehaviour
{
    void Update()
    {
        if(Input.GetKeyDown("q"))
            EventManager.TriggerEvent("test");

        if(Input.GetKeyDown("o"))
            EventManager.TriggerEvent("Spawn");

        if(Input.GetKeyDown("p"))
            EventManager.TriggerEvent("Destroy");

        if(Input.GetKeyDown("x"))
            EventManager.TriggerEvent("Junk");

        if(Input.GetKeyDown("1"))
            GameManager.Instance.StartGame();

        if(Input.GetKeyDown("2"))
            GameManager.Instance.EndGame();
    }
}
