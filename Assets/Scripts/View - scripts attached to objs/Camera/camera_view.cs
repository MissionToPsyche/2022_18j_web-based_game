using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class camera_view: MonoBehaviour
{
    // Adapted from https://gist.github.com/gunderson/d7f096bd07874f31671306318019d996
    [Header("Camera Settings")]

    //Default camera values

    public bool paused;
    private Vector3 lastMousePos = new Vector3(255, 255, 255);
    private Vector3 lastCameraPos;
    private Vector3 newPos;
    public Vector3 p;
    public Vector3 velocity;
    camera_controller camC = camera_controller.getInstance();

    // Start is called before the first frame update
    private void Awake()
    {
        camC.setCamera(gameObject.scene.name);
    }
    void Start()
    { 
        paused = false;
        Cursor.lockState = CursorLockMode.Locked;

        // when the scene loads, set the camera's angle and position
        transform.position = camC.getCamPos();
        transform.eulerAngles = camC.getCamAng();
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

        var mouseMove = new Vector3(mouseMoveY, mouseMoveX, 0) * camC.getSensitivity();
        transform.eulerAngles = transform.eulerAngles + mouseMove;

        // Keyboard commands
        GetBaseInput();
    }

    private void GetBaseInput()
    {
        if (Input.GetKey(KeyCode.W))
        {
            moveForward();
        }
        if (Input.GetKey(KeyCode.S))
        {
            moveBackword();
        }
        if (Input.GetKey(KeyCode.A))
        {
            moveLeft();
        }
        if (Input.GetKey(KeyCode.D))
        {
            moveRight();
        }
    }

    public void moveForward()
    {
        p = new Vector3(0, 0, 1);
        p *= camC.getSpeed();

        //set the new position value equal to the old position value
        newPos = transform.position;

        transform.Translate(p);

        //Check if the camera is going to go out of bounds with the room's objects
        if (!camC.pathBlocked(transform.position))
        {
            newPos.z = transform.position.z;
            newPos.x = transform.position.x;
            Debug.Log("Here");
            //saves the camera's data to the model camera class
            camC.saveCamPos(newPos);
            camC.savecamAng(transform.eulerAngles);
        }
        transform.position = newPos;
    }

    public void moveBackword()
    {
        p = new Vector3(0, 0, -1);
        p *= camC.getSpeed();

        //set the new position value equal to the old position value
        newPos = transform.position;

        transform.Translate(p);

        //Check if the camera is going to go out of bounds with the room's objects
        if (!camC.pathBlocked(transform.position))
        {
            newPos.z = transform.position.z;
            newPos.x = transform.position.x;
            Debug.Log("Here");
            //saves the camera's data to the model camera class
            camC.saveCamPos(newPos);
            camC.savecamAng(transform.eulerAngles);
        }
        transform.position = newPos;
    }

    public void moveLeft()
    {
        p = new Vector3(-1, 0, 0);
        p *= camC.getSpeed();

        //set the new position value equal to the old position value
        newPos = transform.position;

        transform.Translate(p);

        //Check if the camera is going to go out of bounds with the room's objects
        if (!camC.pathBlocked(transform.position))
        {
            newPos.z = transform.position.z;
            newPos.x = transform.position.x;
            Debug.Log("Here");
            //saves the camera's data to the model camera class
            camC.saveCamPos(newPos);
            camC.savecamAng(transform.eulerAngles);
        }
        transform.position = newPos;
    }

    public void moveRight()
    {
        p = new Vector3(1, 0, 0);
        p *= camC.getSpeed();

        //set the new position value equal to the old position value
        newPos = transform.position;

        transform.Translate(p);

        //Check if the camera is going to go out of bounds with the room's objects
        if (!camC.pathBlocked(transform.position))
        {
            newPos.z = transform.position.z;
            newPos.x = transform.position.x;
            Debug.Log("Here");
            //saves the camera's data to the model camera class
            camC.saveCamPos(newPos);
            camC.savecamAng(transform.eulerAngles);
        }
        transform.position = newPos;
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
}
