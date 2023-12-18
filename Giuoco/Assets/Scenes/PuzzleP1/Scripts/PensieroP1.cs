using UnityEngine;
using System.Collections;
using TMPro;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class PensieroP1 : MonoBehaviour
{
    public float delay = 0.05f;
    private string initialText = "Your Negative Thought: \n\nMy daily life seems immersed in a monotonous routine, devoid of stimulation and new passions.\n\n There is nothing I can do to change my situation.";

    private string motivationalText = "Motivational Phrase:\n\nEach day is a chance for new discoveries.\n\nLife is filled with adventures, big and small, and you're ready to explore them.\n\nRemember, your partner's support can make tough times more manageable.";
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

        yield return new WaitForSeconds(3f);

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

    public void NextButtonClickP1()
    {
        // Carica la scena "FINALE" dopo il clic sul pulsante
        SceneManager.LoadScene(finaleSceneName);
    }
}
