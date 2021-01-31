using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SliderManager : MonoBehaviour
{
    //Public variables
    public float range; //How far to one side the platform will go.
    public float speed; //How long, in seconds it takes from the platform to go from starting position to first extreme, or 1/4 of full cycle time.
    public bool horizontal; //Platforms are by default horizontal. Setting this to true will rotate the object 90 degrees, and make it move up and down instead of side to side.

    //Private variables
    private int negater;
    private Vector2 startingPos;
    private float delta;
    private Rigidbody2D rigidbody;
    void Start()
    {
        negater = 1; //Turns negative when platform needs to turn.
        delta = range / speed; //How far the platform moves in one second.
        startingPos = transform.position; //Store starting position for measurement.
        rigidbody = this.GetComponent<Rigidbody2D>();
        if(horizontal) //Rotate platform if needed.
        {
            transform.Rotate(0.0f, 0.0f, 90.0f, Space.World);
        }
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        if(horizontal)
        {
            updateHorizontal();
        }
        else
        {
            updateVertical();
        }
    }

    private void updateHorizontal()
    {
        rigidbody.MovePosition(transform.position + new Vector3(delta * Time.deltaTime * negater, 0.0f, 0.0f));
        if(transform.position.x  + delta * Time.deltaTime * negater > startingPos.x + range || transform.position.x + delta * Time.deltaTime * negater < startingPos.x - range)
        {
            negater = -negater;
        }
    }

    private void updateVertical()
    {
        rigidbody.MovePosition(transform.position + new Vector3(0.0f, delta * Time.deltaTime * negater, 0.0f));
        if (transform.position.y + delta * Time.deltaTime * negater > startingPos.y + range || transform.position.y  + delta * Time.deltaTime * negater < startingPos.y - range)
        {
            negater = -negater;
        }
    }
}
