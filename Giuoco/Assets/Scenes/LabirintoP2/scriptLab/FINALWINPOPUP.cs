using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.SceneManagement;

public class FINALWINPOPUP : MonoBehaviour
{
    public float delay = 0.05f; // Ritardo tra ogni carattere
    private string fullText = "Extraordinary, <username>!\n\n You have enlightened your mind.\n The time has come to reveal the thought.\n\nAre you ready to face it?"; // Testo completo da mostrare
    private string currentText = ""; // Testo attualmente visualizzato
    public TextMeshProUGUI finalwinText; // Componente TextMeshPro per visualizzare il testo

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
            finalwinText.text = currentText;
            yield return new WaitForSeconds(delay);
        }
    }
}
