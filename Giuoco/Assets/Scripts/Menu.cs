using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Menu : MonoBehaviour
{
    // Start is called before the first frame update
    public void Start()
    {
        
    }

    // Update is called once per frame
    public void Update()
    {
        
    }
    
    public void onQuitButton() {
        Application.Quit();
    }

    public void onPlayButton(string nameScene) {
        SceneManager.LoadScene(nameScene);
        
    }
}