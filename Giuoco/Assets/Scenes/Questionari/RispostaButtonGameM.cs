using UnityEngine;
using UnityEngine.UI;

public class RispostaButtonGameM : MonoBehaviour
{
    public int valoreRisposta;

    void Start()
    {
        // Assicurati che il pulsante abbia un listener per il click
        Button button = GetComponent<Button>();
        button.onClick.AddListener(SelezionaRisposta);
    }

    void SelezionaRisposta()
    {
        // Quando il pulsante viene premuto, chiama la funzione RispostaSelezionata nello script GameManager
        GameManager.Instance.RispostaSelezionataGameManager(valoreRisposta);
    }

}
