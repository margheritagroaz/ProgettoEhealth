using UnityEngine;
using System.Collections;
using TMPro;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class PensieroP3 : MonoBehaviour
{
    public float delay = 0.05f;
    private string initialText = "Your Negative Thought: \n\nI am trapped in a vortex of futility and excessive guilt.\n\nI feel the weight of fears and the difficulty of finding serenity.";

    private string motivationalText = "Motivational Phrase: \n\nIn the darkness of fears and doubts, each step I take is a step toward light, toward a renewed awareness of my authenticity and worth.\n\nI can overcome these challenges because my inner light is stronger than any darkness.";
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

    public void NextButtonClickP3()
    {
        // Carica la scena "FINALE" dopo il clic sul pulsante
        SceneManager.LoadScene(finaleSceneName);
    }
}
