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

    public Transform speedPowerUp;
    public Transform enlargePowerUp;

    private AudioSource[] sounds;
    private AudioSource ballBounceAudio;
    private AudioSource launchAudio;
    private AudioSource ballDeathAudio;
    private AudioSource speedSound;


    // Start is called before the first frame update
    void Start()
    {
        ballRigidBody = GetComponent<Rigidbody2D>();
        gameMaster.GetComponent<GameMaster>();
        sounds = GetComponents<AudioSource>();
        ballBounceAudio = sounds[0];
        launchAudio = sounds[1];
        ballDeathAudio = sounds[2];
        speedSound = sounds[3];
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
            launchAudio.Play();
        }

        // Cheat code to reset ball
        if (Input.GetKeyDown(KeyCode.R))
        {
            ballRigidBody.velocity = Vector3.zero;
            transform.position = startPosition;
            ballLaunched = false;
        }
    }
    private void OnTriggerEnter2D(Collider2D other)
    {
        // if ball passes the player on the bottom
        // respawns ball to initial position
        // also loses one life

        if (other.gameObject.tag == "DefeatZone")
        {
            ballDeathAudio.Play();
            ballRigidBody.velocity = Vector3.zero;
            gameMaster.playerLives -= 1;

            // Calls the updatelives method in gamemaster to subtract 1 from the current lives on text
            gameMaster.UpdateLives(-1);

            transform.position = startPosition;
            ballLaunched = false;

        }

        if (other.gameObject.tag == "SpeedUp")
        {
            ballForce += 4;
            Destroy(other.gameObject);
            speedSound.Play();
            if (ballLaunched == false)
            {
                ballForce -= 4;
            }

        }

    }

    private void OnCollisionEnter2D(Collision2D other)
    {
        // Random chance to spawn powerup
        if (other.gameObject.tag == "Bricks")
    {
        int randChance = Random.Range(1, 500);
        if (randChance < 25)
        {
            Instantiate(speedPowerUp, other.transform.position, other.transform.rotation);
        }
        if (randChance < 75)
        {
            Instantiate(enlargePowerUp, other.transform.position, other.transform.rotation);
        }
    }

        ballBounceAudio.Play();
    }


}
