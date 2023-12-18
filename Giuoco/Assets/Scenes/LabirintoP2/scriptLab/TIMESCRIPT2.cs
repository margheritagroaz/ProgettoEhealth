using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using TMPro;

public class TIMERSCRIPTT : MonoBehaviour
{
    public TextMeshProUGUI countdownText;
    public float countdownTime = 45f; // Ora è una variabile pubblica
    public string nextSceneName = "LABIRINTO(LOSSPOPUP2)"; // Nome predefinito della scena da caricare

    void Start()
    {
        if (countdownText == null)
        {
            Debug.Log("Il riferimento al componente Text non è stato assegnato");
            return;
        }

        StartCountdown();
    }

    void Update()
    {
        // Controllo se il tempo è scaduto
        if (countdownTime <= 0f)
        {
            gameObject.SetActive(false); // Nascondo il timer
            // Carica la scena specificata dalla variabile nextSceneName
            SceneManager.LoadScene(nextSceneName);
        }
        // Aggiorno il tempo rimanente 
        countdownTime -= Time.deltaTime;
        // Converto il tempo rimanente in minuti e secondi
        int seconds = Mathf.FloorToInt(countdownTime % 60);
        // Aggiorno il testo del timer: il primo 0 è un segnaposto, gli altri due sono per indicare il num max di cifre
        countdownText.text = string.Format("{0:00}", seconds);
    }

    void StartCountdown()
    {
        // Inizia il conto alla rovescia
        countdownTime = 45f;
    }
}
