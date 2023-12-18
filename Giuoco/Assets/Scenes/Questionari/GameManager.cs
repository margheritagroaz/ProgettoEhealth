using UnityEngine;
using UnityEngine.UI;
using System.Collections.Generic;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    public Text domandaText;
    public Button[] rispostaButtons;

    private List<int> rispostePHQ = new List<int>();
    private List<int> risposteGAD = new List<int>();
    private int indiceRisposta = 0;
    private int sommaRispostePHQ = 0;
    private int sommaRisposteGAD = 0;

    // Singleton pattern
    private static GameManager _instance;
    public static GameManager Instance
    {
        get
        {
            if (_instance == null)
            {
                _instance = FindObjectOfType<GameManager>();
                if (_instance == null)
                {
                    GameObject go = new GameObject("GameManager");
                    _instance = go.AddComponent<GameManager>();
                }
            }
            return _instance;
        }
    }

    private void Start()
    {
        ResetGameState();
        MostraProssimaDomanda();
    }

    private void ResetGameState()
    {
        indiceRisposta = 0;
        // You might need to reset other game state variables here if necessary
    }
    public void RispostaSelezionataGameManager(int valoreRisposta)
    {
        if (indiceRisposta < 9)
        {
            rispostePHQ.Add(valoreRisposta);
            sommaRispostePHQ += valoreRisposta;
        }
        else
        {
            risposteGAD.Add(valoreRisposta);
            sommaRisposteGAD += valoreRisposta;
        }

        MostraProssimaDomanda();
        Debug.Log("Risposta selezionata. Prossima domanda.");
    }

    private void MostraProssimaDomanda()
    {
        if (indiceRisposta < 15)
        {
            domandaText.text = domande[indiceRisposta];
            indiceRisposta++;
        }
        else
        {
            // Fine del gioco
            Debug.Log("Fine del gioco. Risposte PHQ: " + string.Join(", ", rispostePHQ));
            Debug.Log("Fine del gioco. Risposte GAD: " + string.Join(", ", risposteGAD));

            // Calcola i risultati finali
            int risultatoPHQ = sommaRispostePHQ;
            int risultatoGAD = sommaRisposteGAD;

            // Determina quale scena aprire in base ai risultati
            if (risultatoGAD < 4 || risultatoPHQ < 4)
            {
                SceneManager.LoadScene("PROFILO1");
            }
            else if (risultatoGAD > 9 || risultatoPHQ > 9)
            {
                SceneManager.LoadScene("PROFILO3");
            }
            else
            {
                SceneManager.LoadScene("PROFILO2");
            }
        }
    }

    private string[] domande = new string[]
    {
        //PHQ
        "During the last two weeks, how many days have you had little interest or pleasure in doing things?",
        "During the last two weeks, how many days have you felt down, depressed, or hopeless?",
        "During the last two weeks, how many days have you had trouble falling asleep, staying asleep, or sleeping too much?",
        "During the last two weeks, how many days have you felt tired or had little energy?",
        "During the last two weeks, how many days have you had a poor appetite or overeaten?",
        "During the last two weeks, how many days have you felt angry with yourself or like a failure, or that you've let yourself or your family down?",
        "During the last two weeks, how many days have you had trouble concentrating on things like reading the newspaper or watching TV?",
        "During the last two weeks, how many days have you had movements or spoken so slowly that other people could have noticed? Or, on the contrary, have you been so fidgety or restless that you've been moving much more than usual?",
        "During the last two weeks, have you thought that it would be better to be dead or to hurt yourself in some way?",
        // GAD
        "During the last two weeks, how many days have you felt nervous, anxious, or tense?",
        "During the last two weeks, how many days have you been unable to stop worrying or to keep worries under control?",
        "During the last two weeks, how many days have you worried too much about different things?",
        "During the last two weeks, how many days have you had trouble relaxing?",
        "During the last two weeks, how many days have you been so restless that it was hard to sit still?",
        "During the last two weeks, how many days have you become easily annoyed or irritable?",
        "During the last two weeks, how many days have you been afraid that something terrible might happen?"
    };
}

