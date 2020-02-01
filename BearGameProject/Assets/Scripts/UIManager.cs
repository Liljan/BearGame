using UnityEngine;
using UnityEngine.Events;
using UnityEngine.UI;

public class UIManager : MonoBehaviour
{
    private int _currentScore = 0;
    
    // Create handle to text field in score
    [SerializeField]
    private Text _scoreText;

    [SerializeField]
    private UnityAction _bearButtonListener;

    void Awake()
    {
        _bearButtonListener = new UnityAction(completedBear);
    }

    void OnEnable()
    {
        EventManager.StartListening("completedBear", _bearButtonListener);
    }

     // Start is called before the first frame update
    void Start()
    {
        // Assign score UI text component to handle
        _scoreText.text = "Score: " + _currentScore.ToString();
    }

    // Update is called once per frame
    void Update()
    {
        // Check the event system for new bear
        if (Input.GetKeyDown("f"))
            EventManager.TriggerEvent("completedBear");
    }

    void completedBear()
    {
        _currentScore += 1;
        _scoreText.text = "Score: " + _currentScore;
    }
}
