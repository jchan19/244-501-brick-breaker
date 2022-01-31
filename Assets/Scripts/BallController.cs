using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BallController : MonoBehaviour
{
     //required variables
    public bool ballLaunched = false;
    public Rigidbody2D ballRigidBody;
    public Vector2[] startDirections;
    public int randomNumber;
    public float ballForce;
    public Vector3 startPosition;
    public GameMaster gameMaster;
   

    // Start is called before the first frame update
    void Start()
    {
        ballRigidBody = GetComponent<Rigidbody2D>();
        gameMaster.GetComponent<GameMaster>();
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space) && !ballLaunched)
        {
            //launch ball
            randomNumber = Random.Range(0, startDirections.Length);
            ballRigidBody.AddForce(startDirections[randomNumber] * ballForce, ForceMode2D.Impulse);
            ballLaunched = true;

        }
    }
    private void OnTriggerEnter2D(Collider2D other)
    {
        // if ball passes the player on the bottom
        // respawns ball to initial position
        // also loses one life

        if (other.gameObject.tag == "DefeatZone")
        {
           
            ballRigidBody.velocity = Vector3.zero;
            gameMaster.playerLives -= 1;
            transform.position = startPosition;
            ballLaunched = false;

        }
    }

 
}
