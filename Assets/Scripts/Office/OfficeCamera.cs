using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class OfficeCamera: MonoBehaviour
{
    // Adapted from https://gist.github.com/gunderson/d7f096bd07874f31671306318019d996
    [Header("Camera Settings")]

    //All objects with the applicable script will be input into this arraylist
    private ArrayList roomobject_boundaries= new ArrayList();

    //Default camera values
    private float camSpeed = 0.1f;
    private float camSensitivity = 0.25f;
    private float ZCam;
    private float XCam;

    public bool paused;
    private Vector3 lastMousePos = new Vector3(255, 255, 255);
    private Vector3 lastCameraPos;
    private Vector3 newPos;

    // Start is called before the first frame update
    void Start()
    {
        paused = false;
        Cursor.lockState = CursorLockMode.Locked;

        setAngle(OfficeSpawning.CameraAngle);
        setPosition(OfficeSpawning.CameraPos);
    }

    // Update is called once per frame
    void Update()
    {
        if (paused)
        {
            return;
        }

        var mouseMoveY = -1 * Input.GetAxis("Mouse Y");
        var mouseMoveX = Input.GetAxis("Mouse X");

        var mouseMove = new Vector3(mouseMoveY, mouseMoveX, 0) * camSensitivity;
        transform.eulerAngles = transform.eulerAngles + mouseMove;

        // Keyboard commands
        Vector3 p = GetBaseInput();
        p *= camSpeed;

        //set the new position value equal to the old position value
        newPos = transform.position;

        transform.Translate(p);

        //Check if the camera is going to go out of bounds with the room's objects
        if (checkObjectBounds(transform.position)) {
            newPos.z = transform.position.z;
            newPos.x = transform.position.x;
        }


        transform.position = newPos;
    }

    private Vector3 GetBaseInput()
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

    public void Pause()
    {
        Cursor.lockState = CursorLockMode.None;
        paused = true;
    }

    public void Resume()
    {
        Cursor.lockState = CursorLockMode.Locked;
        paused = false;
    }


    public void addCamBoundaries(float []Arr)
    {
        roomobject_boundaries.Add(Arr);
    }

    private bool checkObjectBounds(Vector3 camPos)
    {
        for (int i = 0; i < roomobject_boundaries.Count; i++)
        {
            float[] Arr = (float[])roomobject_boundaries[i];
            double Zmax = Math.Round((Arr[0] + Arr[4]), 2);
            double Zmin = Math.Round((Arr[1] - Arr[4]), 2);
            double Xmax = Math.Round((Arr[2] + Arr[4]), 2);
            double Xmin = Math.Round((Arr[3] - Arr[4]), 2);

            if((camPos.z > Zmin && camPos.z < Zmax) && (camPos.x > Xmin && camPos.x < Xmax))
            {
                return false;
            }
        }
        return true;
    }

    private void setPosition(Vector3 position)
    {
        transform.position = position;
    }
    private void setAngle(Vector3 angle)
    {
        transform.eulerAngles= angle;
    }

    public Vector3 getPosition()
    {
        return transform.position;
    }
    public Vector3 getAngle()
    { 
        return transform.eulerAngles; 
    }
}
/*
 * //if the x value is not out of bounds, move the camera
            if ((transform.position.x > (camXMinimum + camWallBoundry)) && (transform.position.x < (camXMaximum - camWallBoundry)))
            {
                newPos.x = transform.position.x;
            }

            //if the z value is not out of bounds, move the camera
            if ((transform.position.z > (camZMinimum + camWallBoundry)) && (transform.position.z < (camZMaximum - camWallBoundry)))
            {
                newPos.z = transform.position.z;
            }
*/
