using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BrickWithHits : MonoBehaviour
{
    public int numberOfHits = 0;
    public int maxHits;

    public SpriteRenderer brickSprite;
    public float brickValue;

    public GameMaster gameMaster;
    // Start is called before the first frame update
    void Start()
    {
        brickSprite = GetComponent<SpriteRenderer>();
        gameMaster.GetComponent<GameMaster>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    
  
        private void OnCollisionEnter2D(Collision2D other)
    {
        numberOfHits++;
        brickSprite.color = Color.red;
        if (numberOfHits >= maxHits)
        {
            gameMaster.playerPoints =  gameMaster.playerPoints + brickValue;
            // Calls the update score in gamemaster to update player points depending on brick value
            gameMaster.UpdateScore(brickValue);
            Destroy(this.gameObject);
           
        }




    }

}
