using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AddButtonss : MonoBehaviour
{
    [SerializeField]
    private Transform puzzleField;

    [SerializeField]
    private GameObject button;

    private void Awake()
    {
        for (int i = 0; i < 10; i++) // Fix: Rimuovi l'errore di sintassi in questa riga
        {
            GameObject _button = Instantiate(button);
            _button.name = "" + i;
            _button.transform.SetParent(puzzleField, false);
        }
    }

    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {

    }
}
