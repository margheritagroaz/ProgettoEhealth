using System.Collections;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LOSSTIME : MonoBehaviour
{
    public float delay = 0.05f; // Ritardo tra ogni carattere
    private string fullText = "Oops!\n \n  Don't give up, another adventure awaits!\n Retry and conquer!";
    private string currentText = ""; // Testo attualmente visualizzato
    public TextMeshProUGUI losspopupText; // Componente TextMeshPro per visualizzare il testo
    public string nextSceneName = "LEV2Memory"; // Nome predefinito della scena da caricare

    void Start()
    {
        Debug.Log("Typewriter started\n");
        StartCoroutine(ShowText());
    }

    IEnumerator ShowText()
    {
        for (int i = 0; i <= fullText.Length; i++)
        {
            currentText = fullText.Substring(0, i);
            losspopupText.text = currentText;
            yield return new WaitForSeconds(delay);
        }

        // Carica la scena specificata dalla variabile nextSceneName
        SceneManager.LoadScene(nextSceneName);
    }
}
