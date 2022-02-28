using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PowerUp : MonoBehaviour
{
    public float speed;


    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        //Falls down
        transform.Translate(new Vector2(0f, -1f) * Time.deltaTime * speed);
        
        //Destory when reaches bottom
        if(transform.position.y < -7f)
        {
            Destroy(gameObject);
        }
    }
}
