using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public Spawner m_Spawner;

    private static GameManager sm_GameManager;

    public static GameManager Instance
    {
        get
        {
            if(!sm_GameManager)
            {
                FindObjectOfType<GameManager>();

                sm_GameManager = FindObjectOfType(typeof(GameManager)) as GameManager;

                if(!sm_GameManager)
                    Debug.LogError("There needs to be one active GameManager script on a GameObject in your scene.");
                else
                    sm_GameManager.Init();
            }

            return sm_GameManager;
        }
    }

    void Init()
    {
        // The function which is called once the beginning
    }

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void StartGame()
    {
        Debug.Log("The game has started");
        m_Spawner.SpawnObjects();
    }

    public void EndGame()
    {
        Debug.Log("The game has ended");
        m_Spawner.ClearObjects();
    }
}
