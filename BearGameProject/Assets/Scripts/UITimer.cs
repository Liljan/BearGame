using UnityEngine;
using UnityEngine.UI;


public class UITimer : MonoBehaviour
{
    public Text m_TimerText;
    public int m_TotalTime;

    private float m_TimeLeft = 60.0f;
    private bool m_HasTriggeredGameOver = false;
    private bool m_bHasStarted = false;

    void Start()
    {
        m_TimerText.text = m_TimeLeft.ToString("0");

        EventManager.StartListening("ResetGame", ResetTimer);
        EventManager.StartListening("StartGame", StartTimer);
    }

    // Update is called once per frame
    void Update()
    {
        if(m_HasTriggeredGameOver)
            return;

        if(!m_bHasStarted)
            return;

        m_TimeLeft -= Time.deltaTime;

        string seconds = (m_TimeLeft % 60).ToString("0");

        if (m_TimeLeft > 0.0f )
        {
            m_TimerText.text = seconds;
        } else
        {
            m_HasTriggeredGameOver = true;
            EventManager.TriggerEvent("GameOver");
        }
    }

    private void StartTimer()
    {
        m_bHasStarted = true;
    }

    private void ResetTimer()
    {
        // reset the time
        m_TimeLeft = m_TotalTime;
        m_TimerText.text = m_TimeLeft.ToString("0");
        m_HasTriggeredGameOver = false;
        m_bHasStarted = false;
    }
}
