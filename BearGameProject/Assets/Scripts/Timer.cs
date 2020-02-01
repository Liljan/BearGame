using UnityEngine;
using UnityEngine.UI;


public class Timer : MonoBehaviour
{

    public Text timerText;
    public int totalTime;

    // Update is called once per frame
    void Update()
    {
        float t = totalTime - Time.time;
        string seconds = (t % 60).ToString("0");

        if ((t % 60) > 0 )
        {
            timerText.text = seconds;
        } else
        {
            EventManager.TriggerEvent("EndOfTheGame");
        }

    }
}
