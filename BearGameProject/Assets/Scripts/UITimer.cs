using UnityEngine;
using UnityEngine.UI;


public class UITimer : MonoBehaviour
{
    public Text m_TimerText;
    public int m_TotalTime;

    private float m_TimeLeft = 60.0f;
    private bool m_HasTriggeredGameOver = false;

    void Start()
    {
        EventManager.StartListening("ResetGame", ResetTimer);
    }

    // Update is called once per frame
    void Update()
    {
        if (m_HasTriggeredGameOver)
            return;

        m_TimeLeft -= Time.deltaTime;

        string seconds = (m_TimeLeft % 60).ToString("0");

        if ((m_TimeLeft % 60) > 0 )
        {
            m_TimerText.text = seconds;
        } else
        {
            m_HasTriggeredGameOver = true;
            EventManager.TriggerEvent("GameOver");
        }
    }

    private void ResetTimer()
    {
        // reset the time
        m_TimeLeft = m_TotalTime;
        m_HasTriggeredGameOver = false;
    }
}
