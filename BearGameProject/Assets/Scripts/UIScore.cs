using UnityEngine;
using UnityEngine.Events;
using UnityEngine.UI;
using TMPro;

public class UIScore : MonoBehaviour
{
    private int m_CurrentScore = 0;
    
    // Create handle to text field in score
    //[SerializeField]
    //private Text m_ScoreText;

    [SerializeField]
    private GameObject m_scoreGo;
    private TextMeshPro m_scoreMesh;

    // Start is called before the first frame update
    void Start()
    {
        m_CurrentScore = 0;

        EventManager.StartListening("BearScore", CompletedBear);
        EventManager.StartListening("ResetGame", ResetScore);

        m_scoreMesh = m_scoreGo.GetComponent<TextMeshPro>();

        // Assign score UI text component to handle
        //m_ScoreText.text = m_CurrentScore.ToString();
        m_scoreMesh.text = m_CurrentScore.ToString();
    }

    // Update is called once per frame
    void Update()
    {
    }

    void CompletedBear()
    {
        m_CurrentScore += 1;
        //m_ScoreText.text = m_CurrentScore.ToString();
        m_scoreMesh.text = m_CurrentScore.ToString();
    }

    void ResetScore()
    {
        m_CurrentScore = 0;
        //m_ScoreText.text = m_CurrentScore.ToString();
        m_scoreMesh.text = m_CurrentScore.ToString();
    }
}
