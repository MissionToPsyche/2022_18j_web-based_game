using log4net.DateFormatter;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class InView : MonoBehaviour
{
    // Start is called before the first frame update
    private Camera spaceCam;
    private GameObject PlanetPopup;
    private Vector3 originalPos;
    private bool zoomedIn = false;
    private float PlanetMax_X = 7900000;
    private float PlanetMax_Z = 3500000;


    void Start()
    {
        spaceCam = GameObject.Find("Space Camera").GetComponent<Camera>();
        PlanetPopup = GameObject.Find("Planet Popup").gameObject;
        originalPos = transform.position;

    }

    // Update is called once per frame
    void Update()
    {
        // if the planet is within the camera's x and y view
        // and the planets are in the direction the camera is facing
        // there are ranges planets need to be in inorder to travel to them
        // if they are too far, your fuel will not last to get to the planet
        // if they are too close, you will overshoot the planet
        Vector3 viewPos = spaceCam.WorldToViewportPoint(transform.position);
        if((viewPos.x >= 0 && viewPos.x <= 1 && viewPos.y >= 0 && viewPos.y <= 1) && 
            ((spaceCam.transform.forward.z < 0 && transform.position.z < 0) || (spaceCam.transform.forward.z > 0 && transform.position.z > 0)) && (travelDist() < 500 && travelDist() > 30))
        {
            // if the planet hasn't been zoomed in yet
            if (!zoomedIn)
            {
                zoomedIn = true;
                Debug.Log(spaceCam.transform.forward);
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
            }
            createText();
        }
        else
        {
            zoomedIn = false;
            transform.position = originalPos; 
            destroyText();
        }
    }

    float travelDist()
    {
        // get the x and z distance of planet
        // and camera
        Vector2 cam = new Vector2(spaceCam.transform.position.x, spaceCam.transform.position.z);
        Vector2 planet = new Vector2(originalPos.x, originalPos.z);

        // get the differences and
        // multiply by the scaled amount determined
        // 1 unit = 547,992.166 km
        float scaleKM = 547992.166f;
        Vector2 diffScaled = new Vector2((cam.x - planet.x), (cam.y - planet.y));

        // use hypotenuse equation to find total distance across
        // divide by 100 because of the object scaling
        // divided by 17987547.48f to convert km to light minutes
        // c = sqrt( a^2 + b^2)
        float totalDist = ((Mathf.Sqrt((diffScaled.x * diffScaled.x) + (diffScaled.y * diffScaled.y)) * scaleKM) / 1000) / 17987547.48f;
        Debug.Log(name + " light minutes away: " + totalDist);
        return totalDist;

    }

    void createText()
    {
        // display informative text when the planet is on screen
        // create a string to hold the distance value from the camera position
        // to the planet
        Vector3 textPos = spaceCam.WorldToScreenPoint(transform.position);
        string[] addDist = transform.GetChild(0).GetComponent<TextMeshProUGUI>().text.Split('-');
        string newTxt = addDist[0] + travelDist().ToString("0") + addDist[1];

        // find if text object exists under "Planet Popup" UI
        // if it does, delete it and create a new text
        // if it doesn't, create a new text
        GameObject planetTxt = GameObject.Find(name + " distance");
        if(planetTxt != null )
        {
            Destroy(planetTxt);
        }
        planetTxt = new GameObject(name + " distance");
        planetTxt.AddComponent<TextMeshProUGUI>().text = newTxt;
        planetTxt.GetComponent<TextMeshProUGUI>().fontSize = 20;
        planetTxt.GetComponent<TextMeshProUGUI>().fontStyle = FontStyles.Italic;
        planetTxt.GetComponent<TextMeshProUGUI>().alignment = TextAlignmentOptions.Center;
        planetTxt.GetComponent<TextMeshProUGUI>().color = new Color(1, 1, 1, .25f);
        planetTxt.transform.position = new Vector3(textPos.x, textPos.y - 40, 0f);
        planetTxt.transform.SetParent(PlanetPopup.transform);

    }
    void destroyText()
    {
        GameObject planetTxt = GameObject.Find(name + " distance");
        if (planetTxt != null)
        {
            Destroy(planetTxt);
        }
    }
}
