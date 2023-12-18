using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class DRAGPLAYER : MonoBehaviour
{
    private bool isDragging = false;
    

    private void OnMouseDown()
    {
        isDragging = true;
    }

    private void OnMouseUp()
    {
        isDragging = false;
    }

    private void FixedUpdate()
    {
        if (isDragging)
        {
            Vector3 mousePosition = Camera.main.ScreenToWorldPoint(Input.mousePosition);
            mousePosition.z = 0f;
            GetComponent<Rigidbody2D>().MovePosition(mousePosition);
        }
    }

    void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Uscita"))
        {
            Debug.Log("Hai raggiunto l'uscita!"); 
            SceneManager.LoadScene("EndLab1");
            
        }
    }
}
