using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public Spawner m_Spawner;

    private static GameManager sm_GameManager;

    // The game states:
    // 1) Main menu
    // 2) Pre-Gameplay State
    // 3) 


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
        EventManager.StartListening("GameOver", GotoGameOverState);

        GotoPreGameState();
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown("1"))
            Spawn();
    }

    public void ResetGame()
    {
        EventManager.TriggerEvent("ResetGame");
    }

    public void GotoPreGameState()
    {
        StartCoroutine(PreGamePlayState());
    }

    public void GotoGameOverState()
    {
        Debug.Log("The game is over");
        ResetGame();
    }

    public void GotoGameplayState()
    {
        EventManager.TriggerEvent("StartGame");
        // The game is playing
        // Then the timer calls the game to end.
    }

    IEnumerator PreGamePlayState()
    {
        ResetGame();

        yield return new WaitForSeconds(1.0f);
        Debug.Log("Get ready...");
        yield return new WaitForSeconds(1.0f);
        Debug.Log("Go!");

        GotoGameplayState();
    }

    public void Spawn()
    {
        m_Spawner.SpawnObjects();
    }
}
