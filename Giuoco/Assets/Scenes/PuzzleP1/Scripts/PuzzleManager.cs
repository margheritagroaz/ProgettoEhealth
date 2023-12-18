using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PuzzlePiece
{
    public GameObject piece;
    public bool placed;

    public PuzzlePiece(GameObject o)
    {
        piece = o;
        placed = false;
    }
}

public class PuzzleManager : MonoBehaviour
{
    [Header("Scene Transition")]
    [SerializeField] private string nextSceneName; // Campo serializzato per il nome della scena successiva

    public AudioManager audioManager;
    public List<GameObject> cells;
    public List<GameObject> pieces;

    private Dictionary<string, PuzzlePiece> correctPieces = new Dictionary<string, PuzzlePiece>();
    private int totalPlaced = 0;

    // Start is called before the first frame update
    void Start()
    {
        audioManager = FindObjectOfType<AudioManager>();
        for (int i = 0; i < cells.Count; i++)
        {
            Debug.Log("ID cell: " + cells[i].name + " ID puzzle: " + pieces[i].name);
            correctPieces.Add(cells[i].name, new PuzzlePiece(pieces[i]));

        }

        // Re-arrange puzzle pieces
        swapPositions();
    }

    void swapPositions()
    {
        System.Random rand = new System.Random();
        List<Vector2> uniquePositions = new List<Vector2>();

        foreach (GameObject piece in pieces)
        {
            uniquePositions.Add(piece.transform.position);
        }

        for (int i = 0; i < uniquePositions.Count; i++)
        {
            int r = rand.Next(i, uniquePositions.Count);
            Vector2 temp = uniquePositions[r];
            uniquePositions[r] = uniquePositions[i];
            uniquePositions[i] = temp;
        }

        for (int i = 0; i < pieces.Count; i++)
        {
            pieces[i].transform.position = uniquePositions[i];
            Debug.Log(pieces[i].transform.position);
        }
    }

    // Update is called once per frame
    void Update()
    {
        RaycastHit2D ray = Physics2D.Raycast(Camera.main.ScreenToWorldPoint(Input.mousePosition), Vector2.zero);
        if (Input.GetMouseButtonUp(0))
        {
            // Se la posizione della piece selezionata è all'interno dell'area della cella, sposta la posizione alla posizione della cella
            if (ray.collider != null)
            {
                if (ray.transform.CompareTag("puzzle_piece"))
                {
                    for (int i = 0; i < cells.Count; i++)
                    {
                        if (pieceOverlapped(ray.transform.gameObject, cells[i]))
                        {
                            ray.transform.localPosition = cells[i].transform.localPosition;
                            if (correctPieces[cells[i].name].piece.name == ray.transform.gameObject.name)
                            {
                                totalPlaced++;
                                ray.transform.gameObject.tag = "puzzle_piece_undraggable";
                            }
                            checkWin();
                        }
                    }
                }
            }
        }
    }

    private bool pieceOverlapped(GameObject piece, GameObject cell)
    {
        if ((Mathf.Abs(cell.transform.localPosition.x - piece.transform.localPosition.x) < (getSpriteX(cell) * 0.3)) &&
            (Mathf.Abs(cell.transform.localPosition.y - piece.transform.localPosition.y) < (getSpriteY(cell) * 0.3)))
        {
            return true;
        }
        else
            return false;
    }

    private void checkWin()
    {
        if (totalPlaced == cells.Count)
        {
            if (!string.IsNullOrEmpty(nextSceneName)) // Controlla se il nome della scena successiva è fornito
            {
                SceneManager.LoadScene(nextSceneName); // Carica la scena specificata successiva
            }
            else
            {
                Debug.LogWarning("Il nome della scena successiva non è stato fornito nell'Inspector.");
            }
        }
    }

    private float getSpriteX(GameObject obj)
    {
        return obj.GetComponent<SpriteRenderer>().bounds.size.x;
    }

    private float getSpriteY(GameObject obj)
    {
        return obj.GetComponent<SpriteRenderer>().bounds.size.y;
    }
}
