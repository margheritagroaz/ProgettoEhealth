using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class RispostaButtonQuestionM : MonoBehaviour
{
    public int valoreRisposta;

    void Start()
    {
        // Assicurati che il pulsante abbia un listener per il click
        Button button = GetComponent<Button>();
        button.onClick.AddListener(SelezionaRispostaQuestionM);
    }

    void SelezionaRispostaQuestionM()
    {
        // Quando il pulsante viene premuto, chiama la funzione RispostaSelezionata nello script GameManager
        QuestionManager.Instance.RispostaSelezionataQuestionManager(valoreRisposta);
    }
}