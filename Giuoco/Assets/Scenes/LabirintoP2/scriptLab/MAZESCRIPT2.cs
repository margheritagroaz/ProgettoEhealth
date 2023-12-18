using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MAZESCRIPT2 : MonoBehaviour
{
    void Awake()
    {       
    }

    public void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Palla")) //Verifico se l'oggetto labirinto entra il collisione con l'oggetto con il tag Palla
        {
            //Palla ha colliso con labirinto, utente perde
            GameOver();
        }
        
    }

    void GameOver()
    {
        Debug.Log("La palla ha colpito il muro!");
        SceneManager.LoadScene("LOSSPOPUP2");
    }

    
}
