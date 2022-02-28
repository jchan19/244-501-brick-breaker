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
        sizeSound = paddleSounds[0];
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
        

        // If collides with Enlarge powerup
        if (other.CompareTag("Enlarge"))
        {
            sizeSound.Play();
            Destroy(other.gameObject);
            StartCoroutine(ChangeSize());
        }

    }

    // Scaling Paddle Size
    public IEnumerator ChangeSize()
    {

        // Increase paddle size
        Vector3 add = new Vector3(3f, 0f, 3f);

        transform.localScale = new Vector3(transform.localScale.x + add.x,
                                           transform.localScale.y + add.y,
                                           transform.localScale.z + add.z);
        // Powerup timer
        yield return new WaitForSeconds(6f); 

        //Return original paddle size
        transform.localScale = new Vector3(transform.localScale.x - add.x,
                                           transform.localScale.y - add.y,
                                           transform.localScale.z - add.z);
    }
}
