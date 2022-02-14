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
}
