using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameMaster : MonoBehaviour
{
    public float playerPoints;
    public float maxLevelPoints;
    public float playerLives = 3;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        //When player loses all lives, move to losing screen
        if (playerLives <= 0)
        {
            SceneManager.LoadScene("LoseScene");
        }
        //When player gets more than or equal to the required points, move to winning screen
        if (playerPoints >= maxLevelPoints)
        {
            SceneManager.LoadScene("WinScene");
        }
    }
}
