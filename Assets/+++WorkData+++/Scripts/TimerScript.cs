
using TMPro;
using UnityEngine;
using UnityEngine.PlayerLoop;
using UnityEngine.UI;

public class TimerManager : MonoBehaviour
{
    public float timeRemaining = 60f; // Starttime
    // Reference to a UI Text
    public TextMeshProUGUI timerText;  
    
    public UIManager uiManager;

    void Update()
    {
        // Count down
        if (timeRemaining >= 0)
        {
            timeRemaining -= Time.deltaTime;
            UpdateTimerUI();
        }
        else
        {
          
            // possible lose
            TimeUp();
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
    void TimeUp()
    {
       
       
        
          uiManager.ShowLosePanel();
        

    }
}
