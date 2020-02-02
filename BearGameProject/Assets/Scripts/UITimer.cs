using UnityEngine;
using UnityEngine.UI;


public class UITimer : MonoBehaviour
{
    public int m_TotalTime;

    private float m_TimeLeft;
    private bool m_HasTriggeredGameOver = false;
    private bool m_bHasStarted = false;

    void Start()
    {
        m_TimeLeft = m_TotalTime;
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

        if ( m_TimeLeft > 0 )
        {
            float percLeft = m_TimeLeft / m_TotalTime;
            float totalDegrees = percLeft * 360;
            transform.localRotation = Quaternion.Euler(-totalDegrees, 0, 0);

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
