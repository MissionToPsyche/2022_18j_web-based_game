using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting.YamlDotNet.Core;
using UnityEngine;

public class space_explorer_camera : MonoBehaviour
{
    private camera_controller camC = camera_controller.getInstance();
    private teleport_controller tpC = teleport_controller.getInstance();
    public bool paused = false;
    private Vector3 originalPos;
    // Start is called before the first frame update
    void Start()
    {
        Cursor.lockState = CursorLockMode.Locked;
        originalPos= transform.position;
        camC.setCamera(gameObject.scene.name);
    }

    // Update is called once per frame
    void Update()
    {
        if(paused) return;
        var mouseMoveY = -1 * Input.GetAxis("Mouse Y");
        var mouseMoveX = Input.GetAxis("Mouse X");
        Look(mouseMoveY, mouseMoveX);
        if(originalPos != transform.position)
        {
            // player has teleported
            originalPos = transform.position;
            tpC.reset();
        }
    }
    private void Look(float y, float x)
    {
        //first slot 0 for testing purposes
        var mouseMove = new Vector3(y, x, 0) * camC.getSensitivity();
        Vector3 temp = transform.eulerAngles + mouseMove;
        if (temp.x < 90f || temp.x > 270f)
        {
            transform.eulerAngles = temp;
        }
    }
    
}
