using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraMovement : MonoBehaviour
{
    // Adapted from https://gist.github.com/gunderson/d7f096bd07874f31671306318019d996
    [Header("Camera Settings")]
    public float camSpeed = 0.1f;
    public float camSensitivity = 0.25f;

    public bool paused;

    private Vector3 lastMousePos = new Vector3(255, 255, 255);
    
    // Start is called before the first frame update
    void Start()
    {
        paused = false;
        Cursor.lockState = CursorLockMode.Locked;
    }

    // Update is called once per frame
    void Update()
    {
        if(paused){
            return;
        }

        var mouseMoveY = -1 * Input.GetAxis("Mouse Y");
        var mouseMoveX = Input.GetAxis("Mouse X");

        var mouseMove = new Vector3(mouseMoveY, mouseMoveX, 0) * camSensitivity;
        transform.eulerAngles = transform.eulerAngles + mouseMove;

        // Keyboard commands
        Vector3 p = GetBaseInput();
        p *= camSpeed;

        Vector3 newPos = transform.position;

        transform.Translate(p);
        newPos.x = transform.position.x;
        newPos.z = transform.position.z;
        transform.position = newPos;
        
    }

    private Vector3 GetBaseInput() {
        Vector3 velocity = new Vector3();
        if (Input.GetKey (KeyCode.W)){
            velocity += new Vector3(0, 0, 1);
        }
        if (Input.GetKey (KeyCode.S)){
            velocity += new Vector3(0, 0, -1);
        }
        if (Input.GetKey (KeyCode.A)){
            velocity += new Vector3(-1, 0, 0);
        }
        if (Input.GetKey (KeyCode.D)){
            velocity += new Vector3(1, 0, 0);
        }
        return velocity;
    }

    public void Pause() {
        Cursor.lockState = CursorLockMode.None;
        paused = true;
    }

    public void Resume(){
        Cursor.lockState = CursorLockMode.Locked;
        paused = false;
    }
}
