using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.SceneManagement;

public class INTRODUCTION2LEVEL : MonoBehaviour
{
    public float delay = 0.1f; // Ritardo tra ogni carattere
    private string fullText = "<username>, you have crossed the first level with strength and resilience.\n\n This is just the beginning of your journey, face the next level with the same determination.\n\n Way to go!"; // Testo completo da mostrare
    private string currentText = ""; // Testo attualmente visualizzato
    public TextMeshProUGUI introsecondLevelText; // Componente TextMeshPro per visualizzare il testo

    void Start()
    {
        // Aggiungi lo username alla stringa fullText
        fullText = fullText.Replace("<username>", GlobalData.username);
        StartCoroutine(ShowText());
    }

    IEnumerator ShowText()
    {
        for (int i = 0; i <= fullText.Length; i++)
        {
            currentText = fullText.Substring(0, i);
            introsecondLevelText.text = currentText;
            yield return new WaitForSeconds(delay);
        }

        SceneManager.LoadScene("LABIRINTO2"); //Carico secondo livello
    }
}
