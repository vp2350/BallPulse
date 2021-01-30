using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraFollow : MonoBehaviour
{
    public Transform ball;
    public Transform platformZ;

    // Called when the ball is intialized 
    void Awake()
    {
    }

    //Called on the first frame
    void start()
    {
        //Centers camera on ball
        Vector3 centerPos = Camera.main.ViewportToWorldPoint(new Vector3(ball.position.x, ball.position.x, platformZ.position.z));
        transform.position = centerPos;
    }

    // Update is called in line with the amount of physics frames
    void FixedUpdate()
    {
        //Moves camera to ball's current coordinates

        /**
         * Obtaining ball position
         * Z-value is always set to the platform's, since it is the 'deepest' layer. 
         * Ensures that all game objects are shown on camera. 
         */
        Vector3 ballPos = new Vector3(ball.position.x, ball.position.x, platformZ.position.z);
        transform.position = ballPos;
    }
}
