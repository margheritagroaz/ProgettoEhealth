using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AudioManager : MonoBehaviour
{
    public AudioSource backgroundMusic;
    public AudioSource pieceMovedMusic;
    // Start is called before the first frame update
    void Start()
    {
        backgroundMusic.Play();
    }

    public void pieceMovedSound() 
    {
            pieceMovedMusic.Play();
    }
}
