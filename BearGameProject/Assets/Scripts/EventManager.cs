using UnityEngine;
using UnityEngine.Events;
using System.Collections;
using System.Collections.Generic;

public class EventManager : MonoBehaviour
{
    private Dictionary<string, UnityEvent> m_EventDictionary;

    private static EventManager sm_EventManager;

    public static EventManager Instance
    {
        get
        {
            if(!sm_EventManager)
            {
                sm_EventManager = FindObjectOfType(typeof(EventManager)) as EventManager;

                if(!sm_EventManager)
                    Debug.LogError("There needs to be one active EventManger script on a GameObject in your scene.");
                else
                    sm_EventManager.Init();
            }

            return sm_EventManager;
        }
    }

    void Init()
    {
        if(m_EventDictionary == null)
            m_EventDictionary = new Dictionary<string, UnityEvent>();
    }

    public static void StartListening(string eventName, UnityAction listener)
    {
        UnityEvent thisEvent = null;
        if(Instance.m_EventDictionary.TryGetValue(eventName, out thisEvent))
        {
            thisEvent.AddListener(listener);
        }
        else
        {
            thisEvent = new UnityEvent();
            thisEvent.AddListener(listener);
            Instance.m_EventDictionary.Add(eventName, thisEvent);
        }
    }

    public static void StopListening(string eventName, UnityAction listener)
    {
        if(sm_EventManager == null)
            return;

        UnityEvent thisEvent = null;

        if(Instance.m_EventDictionary.TryGetValue(eventName, out thisEvent))
            thisEvent.RemoveListener(listener);
    }

    public static void TriggerEvent(string eventName)
    {
        UnityEvent thisEvent = null;

        if(Instance.m_EventDictionary.TryGetValue(eventName, out thisEvent))
            thisEvent.Invoke();
    }

}