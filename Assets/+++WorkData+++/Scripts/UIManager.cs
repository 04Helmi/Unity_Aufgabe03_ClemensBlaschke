using UnityEngine;
using UnityEngine.SceneManagement;

public class UIManager : MonoBehaviour
{

    public GameObject WinPanel;
    public GameObject LosePanel;
    public string mainMenuScene = "MainMenuScene";
    public string gameScene = "SampleScene";

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("WinArea"))
        {
            Debug.Log("player Won");
        }
        FindObjectOfType<UIManager>().ShowWinPanel();
    }

    public void ShowWinPanel()
    {
        WinPanel.SetActive(true);
    }

    public void ShowLosePanel()
    {
        LosePanel.SetActive(true);
    }

    public void TryAgain()
    {
        SceneManager.LoadScene(gameScene);
    }

    public void GoToMainMenu()
    {
        SceneManager.LoadScene(mainMenuScene);
    }
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
