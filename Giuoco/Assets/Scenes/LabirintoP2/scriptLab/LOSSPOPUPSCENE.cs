using System.Collections;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LOSSPOPUPSCENE : MonoBehaviour
{
    public float delay = 0.1f; // Ritardo tra ogni carattere
    private string fullText = "Oops!\n \n  Don't give up, another adventure awaits!\n Retry and conquere!"; // Testo completo da mostrare
    private string currentText = ""; // Testo attualmente visualizzato
    public TextMeshProUGUI losspopupText; // Componente TextMeshPro per visualizzare il testo
    

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
            losspopupText.text = currentText;
            yield return new WaitForSeconds(delay);
        }
        SceneManager.LoadScene("LABIRINTO1"); //Ricarico la scena del labirinto da capo 
            
        
    }
    
}
