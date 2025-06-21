
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class TimerManager : MonoBehaviour
{
    public float timeRemaining = 50f; // Starttime
    // Reference to a UI Text
    public TextMeshProUGUI timerText;           

    void Update()
    {
        // Count down
        if (timeRemaining > 0)
        {
            timeRemaining -= Time.deltaTime;
            UpdateTimerUI();
        }
        else
        {
            timeRemaining = 0;
            // possible lose
        }
    }

    public void AddTime()
    {
        timeRemaining += 2;
        UpdateTimerUI();
    }

    void UpdateTimerUI()
    {
        timerText.text = Mathf.Ceil(timeRemaining).ToString();
    }
}
