using System.Collections;
using TMPro; // Assicurati di avere il TextMeshPro installato da Package Manager
using UnityEngine;
using UnityEngine.SceneManagement;

public class WELCOMELABIRINTO : MonoBehaviour
{
    public float delay = 0.05f; // Ritardo tra ogni carattere
    private string fullText = "We designed this level to stimulate your mind in a positive way.\n\n Find your way out of the maze.\n\n Imagine each step as the untangling of unnecessary thoughts, guiding you to ultimate serenity.\n\n Are you ready?\nFocus and have fun!"; // Testo completo da mostrare
    private string currentText = ""; // Testo attualmente visualizzato
    public TextMeshProUGUI welcomeText; // Componente TextMeshPro per visualizzare il testo
    
    void Start()
    {
        Debug.Log("TYpewriter started\n");
        StartCoroutine(ShowText());
    }

    IEnumerator ShowText()
    {
        for (int i = 0; i <= fullText.Length; i++)
        {
            currentText = fullText.Substring(0, i);
            welcomeText.text = currentText;
            yield return new WaitForSeconds(delay);
        }

        SceneManager.LoadScene("LABIRINTO1"); //Carico il primo livello
    }
}


