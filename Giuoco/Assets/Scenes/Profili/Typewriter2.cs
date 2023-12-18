using UnityEngine;
using System.Collections;
using TMPro;

public class Typewriter2 : MonoBehaviour
{
    public float delay = 0.05f; // Ritardo tra ogni carattere
    private string fullText = "Welcome to MindCraft <username>, where your emotions take shape. You emerge as a thoughtful and aware person facing some daily challenges.  A negative thought has touched your mind and darkened it.\nYour mission is delicate: go over the levels and discover the negative thought behind the shadow.\n\nBe brave, <username>, and remember that even in darkness, you will find the strength to shine. Ready?";
    private string currentText = ""; // Aggiunto punto e virgola mancante
    public TextMeshProUGUI textDisplay;
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
            // Aspetta prima di iniziare la prossima parte
            yield return new WaitForSeconds(1f);
    }
}