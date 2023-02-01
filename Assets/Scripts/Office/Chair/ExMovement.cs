using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ExMovement : MonoBehaviour
{
    // Start is called before the first frame update
    private AsteroidBehavior AsteroidBoundary = AsteroidBehavior.getInstance();
    public float asteroid_speed = .1f;
    private Vector3 newPos;

    void Start()
    {
        Debug.Log("TestingColliders");
        Debug.Log("z: " + transform.position.z);
        Debug.Log("x: " + transform.position.x);
    }

    // Update is called once per frame
    void Update()
    {
        // Keyboard commands
        Vector3 p = movement();
        p *= asteroid_speed;

        //set the new position value equal to the old position value
        newPos = transform.position;

        transform.Translate(p);

        //Check if the camera is going to go out of bounds with the room's objects
        //if the function returns false, the player does not move that direction
        //if the function returns true, the player is able to move that direction
        if (AsteroidBoundary.valid_movement(transform.position))
        {
            newPos.z = transform.position.z;
            newPos.x = transform.position.x;

        }

        transform.position = newPos;
    }

    private Vector3 movement()
    {
        Vector3 velocity = new Vector3();
        if (Input.GetKey(KeyCode.W))
        {
            velocity += new Vector3(0, 0, 1);
        }
        if (Input.GetKey(KeyCode.S))
        {
            velocity += new Vector3(0, 0, -1);
        }
        if (Input.GetKey(KeyCode.A))
        {
            velocity += new Vector3(-1, 0, 0);
        }
        if (Input.GetKey(KeyCode.D))
        {
            velocity += new Vector3(1, 0, 0);
        }

        return velocity;
    }
}
