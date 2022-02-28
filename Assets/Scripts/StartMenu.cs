using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class StartMenu : MonoBehaviour
{
    public void StartGame()
    {
        SceneManager.LoadScene("Level" + 1);
    }
    
    public void HelpScreen()
    {
        SceneManager.LoadScene("Help Menu");
    }

    public void GoBack()
    {
        SceneManager.LoadScene("Start Menu");
    }

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
