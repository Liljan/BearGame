using System.Collections;
using UnityEngine;
using TMPro;

public class UICountdown : MonoBehaviour
{
    [SerializeField]
    private TextMeshProUGUI m_Text;

    [SerializeField]
    private string m_MessageText;

    [SerializeField]
    private int m_CountDownTime;
    private bool m_IsActive = false;

    void Start()
    {
        m_IsActive = false;
        m_Text.gameObject.SetActive(false);

        EventManager.StartListening("ResetGame", Init);
    }

    private void Init()
    {
        m_Text.gameObject.SetActive(true);

        StartCoroutine(Countdown());
    }

    IEnumerator Countdown()
    {
        for(int i = m_CountDownTime; i > 0; i--)
        {
            m_Text.text = i.ToString();
            yield return new WaitForSeconds(1.0f);
        }

        m_Text.text = m_MessageText;
        yield return new WaitForSeconds(1.0f);

        m_Text.gameObject.SetActive(false);

        EventManager.TriggerEvent("CountdownComplete");
    }
}
