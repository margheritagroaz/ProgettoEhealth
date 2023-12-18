using UnityEngine;
using UnityEngine.UI;
using System.Collections.Generic;
using UnityEngine.SceneManagement;
public static class GlobalData
{
    public static string username;
}
public class QuestionManager : MonoBehaviour
{
    public Text domandaText;
    public Button[] rispostaButtons;
    public InputField inputUsername;
    public Button invioButton;

    private List<int> risposte = new List<int>();
    private int indiceRisposta = 0;
    private int sommaRisposte = 0;
    private string username = "";

    private List<List<string>> risposteAssociate = new List<List<string>>()
    {
        new List<string> {" ", " ", " ", " "},
        new List<string> {"18-24", "25-34", "35-44", "Older than 45"},
        new List<string> {"Female", "Male", "Non-binary", "Prefer not to say"},
        new List<string> {"Single", "Married", "Divorced/Widowed/Separated", "Prefer not to say"},
        new List<string> {"Middle School Graduate", "High School Graduate", "Bachelor's Degree", "Master's Degree"},
        new List<string> {"0-18 k/year", "18-26 k/year", "27-45 k/year", ">45 k/year"},

    };

    private static QuestionManager _instance;
    public static QuestionManager Instance
    {
        get
        {
            if (_instance == null)
            {
                _instance = FindObjectOfType<QuestionManager>();
                if (_instance == null)
                {
                    GameObject go = new GameObject("QuestionManager");
                    _instance = go.AddComponent<QuestionManager>();
                }
            }
            return _instance;
        }
    }

    private void Start()
    {
        MostraProssimaDomandaQuestionManager();

        inputUsername.onEndEdit.AddListener(OnInputUsernameEndEdit);

        // Aggiungi un listener per il click del pulsante "Invio"
        invioButton.onClick.AddListener(OnInvioButtonClick);
    }

    private void OnInputUsernameEndEdit(string value)
    {
        Debug.Log($"Username inserito: {value}");
        // Attiva il pulsante "Invio" quando l'utente inserisce lo username
        username = value;
        invioButton.interactable = true;
    }

    private void OnInvioButtonClick()
    {
        // Gestisci il click del pulsante "Invio"
        MostraProssimaDomandaQuestionManager();
        // Disabilita il pulsante "Invio" dopo il click
        invioButton.interactable = false;
    }

    public void RispostaSelezionataQuestionManager(int valoreRisposta)
    {
        risposte.Add(valoreRisposta);
        sommaRisposte += valoreRisposta;
        inputUsername.text = $"{username}";
        MostraProssimaDomandaQuestionManager();
    }

    private void MostraProssimaDomandaQuestionManager()
    {
        if (indiceRisposta < domande.Length)
        {
            domandaText.text = domande[indiceRisposta];

            for (int i = 0; i < rispostaButtons.Length; i++)
            {
                rispostaButtons[i].GetComponentInChildren<Text>().text = risposteAssociate[indiceRisposta][i];
            }

            indiceRisposta++;
        }
        else
        {
            Debug.Log("Fine del gioco. Risposte: " + string.Join(", ", risposte));
            SceneManager.LoadScene("Questionario");
            risposte.Clear();
            sommaRisposte = 0;
            indiceRisposta = 0;
            inputUsername.text = "";
            // Resetta lo username
            GlobalData.username = username;
            Debug.Log($"GlobalData.username: {GlobalData.username}");
            username = "";
        }
    }

    private string[] domande = new string[]
    {
        "Hello, tell us something about you. How would you prefer to be addressed in the game??",
        "What age group do you fall into?",
        "What is your gender identity?",
        "How would you describe your current relationship status?",
        "What is your highest level of education completed?",
        "What is your annual household income before taxes?"
    };
}
