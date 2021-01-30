using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BallCollisionManager : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.gameObject.tag == "Goal") //Stops ball from moving and simulating physics.
        {
            Rigidbody2D rigidbody = gameObject.GetComponent<Rigidbody2D>();

            gameObject.GetComponent<moveScript>().enabled = false;
            rigidbody.bodyType = RigidbodyType2D.Kinematic;
            rigidbody.velocity = Vector2.zero;
            rigidbody.angularVelocity = 0.0f;
        }
    }
}
