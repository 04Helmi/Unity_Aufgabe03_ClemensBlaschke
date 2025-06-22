using UnityEngine;

public class WinPlattform : MonoBehaviour
{
    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("WinArea"))
        {
            Debug.Log("player Won");
        }
        FindObjectOfType<UIManager>().ShowWinPanel();
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
