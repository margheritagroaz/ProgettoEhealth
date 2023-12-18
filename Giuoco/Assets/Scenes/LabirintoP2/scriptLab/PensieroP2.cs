using UnityEngine;
using System.Collections;
using TMPro;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class PensieroP2 : MonoBehaviour
{
    public float delay = 0.05f;
     private string initialText = "Your Negative Thought: \n\nMy mind is a whirlwind of anxious thoughts, unable to focus on anything concrete.\n\nEvery moment is a struggle, with the constant tension of not being able to relax.";

    private string motivationalText = "Motivational Phrase: \n\n Every breath brings calmness, every focus brings control.\nFace challenges with clarity and determination.\n\nYour mind is stronger than any storm.\n\nSeek your partner's support for added strength in tough times.";
    private string currentText = "";
    public TextMeshProUGUI textDisplay;
    public Button nextButton;
    public string finaleSceneName = "FINALE";


    void Start()
    {
        StartCoroutine(ShowInitialText());
    }

    IEnumerator ShowInitialText()
    {
        for (int i = 0; i <= initialText.Length; i++)
        {
            currentText = initialText.Substring(0, i);
            textDisplay.text = currentText;
            yield return new WaitForSeconds(delay);
        }

        yield return new WaitForSeconds(1f);

        StartCoroutine(ShowMotivationalText());
    }

    IEnumerator ShowMotivationalText()
    {
        textDisplay.text = "";

        for (int i = 0; i <= motivationalText.Length; i++)
        {
            currentText = motivationalText.Substring(0, i);
            textDisplay.text = currentText;
            yield return new WaitForSeconds(delay);
        }
        // Dopo il testo motivazionale, rendi il pulsante interactable
        nextButton.interactable = true;
    }

    public void NextButtonClickP2()
    {
        // Carica la scena "FINALE" dopo il clic sul pulsante
        SceneManager.LoadScene(finaleSceneName);
    }
}