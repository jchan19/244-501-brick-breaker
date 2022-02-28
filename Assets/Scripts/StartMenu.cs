using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class StartMenu : MonoBehaviour
{
    // Next Level
    public void StartGame()
    {
        SceneManager.LoadScene("Level" + 1);
    }
    
    //Help Menu Scene
    public void HelpScreen()
    {
        SceneManager.LoadScene("Help Menu");
    }

    // Start Menu Screen
    public void GoBack()
    {
        SceneManager.LoadScene("Start Menu");
    }

    //Start Menu Screen
    public void PlayAgain()
    {
        SceneManager.LoadScene("Start Menu");
    }
    

    // CHEATS
    void Update()
    {

        //Go to start scene 
        if (Input.GetKeyDown(KeyCode.H))
        {
            SceneManager.LoadScene("Start Menu");
        }


        // Go to lose scene
        if (Input.GetKeyDown(KeyCode.G))
        {
            SceneManager.LoadScene("LoseScene");
        }

        // Go to win scene
        if (Input.GetKeyDown(KeyCode.Y))
        {
            SceneManager.LoadScene("WinScene");
        }
    }
}
