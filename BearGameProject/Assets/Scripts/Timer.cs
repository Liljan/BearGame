using UnityEngine;
using UnityEngine.UI;


public class Timer : MonoBehaviour
{

    public Text timerText;
    public int totalTime;

    // Start is called before the first frame update
    void Start()
    {
        totalTime = 25;
    }

    public int setTime(int seconds)
    {
        totalTime += seconds;
        return totalTime;
    }

    // Update is called once per frame
    void Update()
    {
        float t = totalTime - Time.time;
        string seconds = (t % 60).ToString("0");

        if ((t % 60) > 1 )
        {
            timerText.text = seconds;
        } else
        {

        }


        
    }
}
