using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PaddleController : MonoBehaviour
{
    public float playerInput;
    public float paddleSpeed;

    public GameMaster gameMaster;

    private AudioSource[] paddleSounds;
    private AudioSource speedSound;
    private AudioSource sizeSound;

    // Start is called before the first frame update
    void Start()
    {
        paddleSounds = GetComponents<AudioSource>();
        speedSound = paddleSounds[0];
        sizeSound = paddleSounds[1];
    }

    // Update is called once per frame
    void Update()
    {
        //Allows player to move left and right
        playerInput = Input.GetAxis("Horizontal");
        transform.Translate(Vector3.right * Time.deltaTime * paddleSpeed * playerInput);
    }

    //Collide with Powerup and destroy

    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag ("SpeedUp"))
        {
            speedSound.Play();
            Destroy(other.gameObject);
        }
       
        if (other.CompareTag ("Enlarge"))
        {
            sizeSound.Play();
            Destroy(other.gameObject);
        }

    }

}
