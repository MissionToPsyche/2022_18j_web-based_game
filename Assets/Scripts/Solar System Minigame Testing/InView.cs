using log4net.DateFormatter;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InView : MonoBehaviour
{
    // Start is called before the first frame update
    private Camera spaceCam;
    private Vector3 originalPos;
    private bool zoomedIn = false;
    private float PlanetMax_X = 7900000;
    private float PlanetMax_Z = 3500000;


    void Start()
    {
        spaceCam = GameObject.Find("Space Camera").GetComponent<Camera>();
        originalPos = transform.position;

        Debug.Log(name + "'s orig position: " + transform.position);
    }

    // Update is called once per frame
    void Update()
    {
        // if the planet is within the camera's x and y view
        Vector3 viewPos = spaceCam.WorldToViewportPoint(transform.position);
        if((viewPos.x >= 0 && viewPos.x <= 1 && viewPos.y >= 0 && viewPos.y <= 1))
        {
            // if the planet hasn't been zoomed in yet
            if (!zoomedIn)
            {
                zoomedIn = true;

                // scaling down the planet locations to be within
                // camera view, will display facts about planet when in view
                float cameraMaxView = spaceCam.farClipPlane;
                float frac_X = transform.position.x / PlanetMax_X;
                float frac_Z = transform.position.z / PlanetMax_Z;
                float x_Addon = cameraMaxView * frac_X;
                float z_Addon = cameraMaxView * frac_Z;

                // change planet position
                // in otherwords, zoom in planet
                Vector3 camera = spaceCam.transform.position;
                transform.position = new Vector3(camera.x + x_Addon, transform.position.y, camera.z + z_Addon);
                Debug.Log(name + "'s new pos: " + transform.position);
            }

            // display informative text when the planet is on screen
            Vector3 textPos = spaceCam.WorldToScreenPoint(transform.position);
            Debug.Log("the text will be at position: (" + textPos.x + " ," + textPos.y + ")");


        }
        else
        {
            zoomedIn = false;
            transform.position = originalPos; 

        }
    }
}
