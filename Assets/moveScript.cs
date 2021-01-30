using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class moveScript : MonoBehaviour
{
    //Public variables
    public AudioSource hitSound;
    //Private variables
    private float waitTime = 0.8f;
    private float timer = 0.0f;
    // Start is called before the first frame update
    public float maxSpeed = 5f;

    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        this.GetComponent<Rigidbody2D>().velocity = Vector3.ClampMagnitude(this.GetComponent<Rigidbody2D>().velocity, maxSpeed);

        timer += Time.deltaTime;
        if (timer > waitTime)
        {

            // Remove the recorded 2 seconds.
            timer = timer - waitTime;
            // Player can control direction
            Vector2 mousePos = Camera.main.ScreenToWorldPoint(Input.mousePosition); //get mouse position

            Vector2 direction = (Vector2)transform.position - mousePos; //get vector from position to mouse pos
            float distanceVector = Vector2.Distance(mousePos, (Vector2)transform.position);
            if (distanceVector < 0.5)
            {
                distanceVector = 0.5f;
                Debug.Log("TRUE");
            }
            if (distanceVector < 10)
                this.GetComponent<Rigidbody2D>().AddForce(direction.normalized * 4 * (1 / (distanceVector)), ForceMode2D.Impulse);

            //Play sound effect
            hitSound.Play();
        }
    }
}