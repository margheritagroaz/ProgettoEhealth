using UnityEngine;
using UnityEngine.SceneManagement;

public class CambioScena : MonoBehaviour
{

    public void PassaAScena(string scena)
    {
        try
        {
            // Carica la scena 
            SceneManager.LoadScene(scena);
        }
        catch (System.Exception e)
        {
            Debug.LogError($"Errore nel cambiare scena: {e.Message}");
        }
    }

}

