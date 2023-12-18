using UnityEngine;
using System.Collections;
using TMPro;
using UnityEngine.SceneManagement;

public class TypewriterPuzzle : MonoBehaviour
{
    public float delay = 0.05f;
    private string fullText = "We designed this level to stimulate your mind in a positive way.\n\nPut the puzzle back together and imagine each piece as a precious memory to be rediscovered.\n\nRemember, this is a time designed for fun and relaxation.\n\n Ready?";
    private string currentText = ""; // Aggiunto punto e virgola mancante
    public TextMeshProUGUI textDisplay;
    public string nextSceneName = "Puzzle facile";   // qui metti nome scena

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
            textDisplay.text = currentText;
            yield return new WaitForSeconds(delay);
        }

        yield return new WaitForSeconds(1f);
        SceneManager.LoadScene(nextSceneName);
    }
}