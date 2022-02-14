using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class GameMaster : MonoBehaviour
{
    public float playerPoints;
    public float maxLevelPoints;
    public float playerLives = 3;

    public Text livesText;
    public Text scoreText;

    public int level = 1;



    // Start is called before the first frame update
    void Start()
    {
        // Displays the text lives and score with their actual numbers
        livesText.text = "Lives: " + playerLives;
        scoreText.text = "Score: " + playerPoints;
    }

    // Update is called once per frame
    void Update()
    {
        //When player loses all lives, move to losing screen
        if (playerLives <= 0)
        {
            SceneManager.LoadScene("LoseScene");
        }
        //When player gets more than or equal to the required points, move to next level or winning screen 
        if (playerPoints >= maxLevelPoints)
        {
            // Loads next level
            if (this.level <= 5)
            {
                LoadLevel(this.level + 1);
            }
            // Loads to winning scene 
            if (this.level > 5 )
            SceneManager.LoadScene("WinScene");
  
        }

        //Cheats

        // Go to next level cheat
        if (Input.GetKeyDown(KeyCode.N))
        {
            LoadLevel(this.level + 1);
        }

        //Go to start scene cheat

        if (Input.GetKeyDown(KeyCode.H))
        {
            SceneManager.LoadScene("Start Menu");
        }
    }

    // Updates the lives text whenever player loses or gains a life
    public void UpdateLives(int changeInLives)
    {
        livesText.text += changeInLives;

        livesText.text = "Lives: " + playerLives;
    }

    // Updates the score text whenever player gains points

    public void UpdateScore(float points)
    {
        scoreText.text += points;

        scoreText.text = "Score: " + playerPoints;
    }

    // Load level method
    public void LoadLevel(int level)
    {
        this.level = level;
        SceneManager.LoadScene("Level" + level); ;
    }
}
