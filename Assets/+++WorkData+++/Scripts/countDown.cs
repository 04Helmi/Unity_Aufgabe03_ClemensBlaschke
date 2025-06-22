using UnityEngine;
using TMPro;  // Verwende TMPro wenn du TextMeshPro benutzt

public class Countdown : MonoBehaviour
{
    public TextMeshProUGUI countdownText;  // Dein Text-UI
    public float countdownTime = 3f;
    public GameObject player;             // Dein Player oder andere Objekte, die am Anfang deaktiviert sind

    void Start()
    {
        player.SetActive(false);          // Player deaktivieren, bis der Countdown vorbei ist
        StartCoroutine(StartCountdown());
    }

    System.Collections.IEnumerator StartCountdown()
    {
        float timer = countdownTime;

        while (timer > 0)
        {
            countdownText.text = Mathf.Ceil(timer).ToString();
            yield return new WaitForSeconds(1f);
            timer--;
        }

        countdownText.text = "GO!";
        yield return new WaitForSeconds(1f);
        countdownText.gameObject.SetActive(false); // ausblenden
        player.SetActive(true);                    // Player aktivieren
    }
}