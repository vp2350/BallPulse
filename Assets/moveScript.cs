using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class moveScript : MonoBehaviour
{
    private float waitTime = 0.5f;
    private float timer = 0.0f;
    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        
        timer += Time.deltaTime;
        if (timer > waitTime)
        { 

            // Remove the recorded 2 seconds.
            timer = timer - waitTime;
            // Player can control direction
            Vector2 mousePos = Camera.main.ScreenToWorldPoint(Input.mousePosition); //get mouse position

            Vector2 direction = (Vector2)transform.position - mousePos; //get vector from position to mouse pos
            this.GetComponent<Rigidbody2D>().AddForce(direction.normalized*2*(1/(Vector2.Distance(mousePos, (Vector2)transform.position))), ForceMode2D.Impulse);

        }
    }
}
