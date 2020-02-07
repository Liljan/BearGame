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
        EventManager.StartListening("CountdownComplete", GotoGameplayState);
        EventManager.StartListening("GameOver", GotoPostGameState);

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

    public void GotoPostGameState()
    {
        Debug.Log("PostGameState");

        StartCoroutine(PostGamePlayState());
    }

    public void GotoGameplayState()
    {
        EventManager.TriggerEvent("StartGame");
        m_Spawner.SpawnObjects();
        // The game is playing
        // Then the timer calls the game to end.
    }

    public void GotoGameOverState()
    {
        // Go to the high score menu or something...
        GotoPreGameState();
    }

    IEnumerator PreGamePlayState()
    {
        ResetGame();

        yield return null;
    }

    IEnumerator PostGamePlayState()
    {
        bool hasBearsOnBelt = true;

        while(hasBearsOnBelt)
        {
            hasBearsOnBelt = m_Spawner.HasObjectsOnBelt();
            yield return new WaitForSeconds(0.1f);
        }

        Debug.Log("The game is over... Restarting in 1 second");
        yield return new WaitForSeconds(2.0f);

        GotoGameOverState();
    }

    public void Spawn()
    {
        m_Spawner.SpawnObjects();
    }
}
