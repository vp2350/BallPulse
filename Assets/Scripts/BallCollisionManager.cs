using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BallCollisionManager : MonoBehaviour
{
    public Transform ball; 
    public Vector3 initialPos; 
   
    
    // Start is called before the first frame update
    void Start()
    {
        //storing ball's position at the start of the level. 
        initialPos =  new Vector3(ball.position.x, ball.position.y,
            ball.position.z); 
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        //Stops ball from moving and simulating physics.
        Rigidbody2D rigidbody = gameObject.GetComponent<Rigidbody2D>();

        gameObject.GetComponent<moveScript>().enabled = false;
        rigidbody.bodyType = RigidbodyType2D.Kinematic;
        rigidbody.velocity = Vector2.zero;
        rigidbody.angularVelocity = 0.0f;

        if (collision.gameObject.tag == "Goal") 
        {
            UnityEngine.SceneManagement.SceneManager.LoadScene("LevelTwo");
        }
        if (collision.gameObject.tag == "EndGoal")
        {
            UnityEngine.SceneManagement.SceneManager.LoadScene("EndScreen");
        }

        if (collision.gameObject.tag == "Hazard")
        {
            //resets the ball's position
            gameObject.GetComponent<moveScript>().enabled = true;
            rigidbody.bodyType = RigidbodyType2D.Dynamic;

            ball.position = initialPos; 
        }
    }
}
