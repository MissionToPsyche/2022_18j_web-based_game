using log4net.DateFormatter;
using PlasticGui.WorkspaceWindow.Home;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class InView : MonoBehaviour
{
    // Start is called before the first frame update
    private Camera spaceCam;
    private GameObject PlanetPopup;
    private GameObject PlanetVisited;
    private GameObject Points;
    private teleport_controller tpC = teleport_controller.getInstance();

    private bool visited = false;
    private Vector3 originalPos;
    private bool zoomedIn = false;
    public float ZoomEnhancer = .2f;

    void Start()
    {
        spaceCam = GameObject.Find("Space Camera").GetComponent<Camera>();
        PlanetPopup = GameObject.Find("Planet Popup").gameObject;
        Points = GameObject.Find("Light Minutes");
        PlanetVisited = GameObject.Find(name + "Txt").gameObject;
        originalPos = transform.position;

    }

    // Update is called once per frame
    void Update()
    {
        zoomIn();
        if (tpC.isTeleport())
        {
            transform.position= originalPos;
        }
    }

    private void OnMouseDown()
    {
        // teleport to planet
        // add distance to total
        // mark as visited
        travelTo();
        tpC.teleporting();
        teleport();
    }
    private void zoomIn()
    {
        // if the planet is within the camera's x and y view
        // and the planets are in the direction the camera is facing
        // there are ranges planets need to be in inorder to travel to them
        // if they are too far, your fuel will not last to get to the planet         && (travelDist() < 500 && travelDist() > 30) 
        // if they are too close, you will overshoot the planet                     
        Vector3 viewPos = spaceCam.WorldToViewportPoint(transform.position);
        if ((viewPos.x >= 0 && viewPos.x <= 1 && viewPos.y >= 0 && viewPos.y <= 1) && inPosition() && (totalDist() > spaceCam.farClipPlane))
        {
            // if the planet hasn't been zoomed in yet
            if (!zoomedIn)
            {

                zoomedIn = true;
                // scaling down the planet locations to be within
                // camera view, will display facts about planet when in views
                float cameraMaxView = spaceCam.farClipPlane;
                float angle = Mathf.Asin((spaceCam.transform.position.x - originalPos.x) / totalDist());
                float newdist = ((totalDist() - cameraMaxView) / totalDist() * cameraMaxView);
                float newx = newdist * Mathf.Sin(angle);
                float newz = newdist * Mathf.Cos(angle);
                if(originalPos.z < 0)
                {
                    newz *= -1;
                }
                if(originalPos.x < 0)
                {
                    newx *= -1;
                }

                Vector3 camera = spaceCam.transform.position;
                transform.position = new Vector3(camera.x + (newx * ZoomEnhancer), originalPos.y, camera.z + (newz * ZoomEnhancer));

                // debugging purposes
                Debug.Log(name + "'s Old values");
                Debug.Log("tdist: " + totalDist());
                Debug.Log("xdist: " + originalPos.x);
                Debug.Log("zdist: " + originalPos.z);
                Debug.Log(name + "'s New values");
                Debug.Log("NT: " + newdist);
                Debug.Log("NX: " + newx);
                Debug.Log("NZ: " + newz + "\n");

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

    private float travelDist()
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
        float totalDist = ((Mathf.Sqrt((diffScaled.x * diffScaled.x) + (diffScaled.y * diffScaled.y)) * scaleKM) / 100) / 17987547.48f;
        return totalDist;

    }
    private float totalDist()
    {
        // get the x and z distance of planet
        // and camera
        Vector2 cam = new Vector2(spaceCam.transform.position.x, spaceCam.transform.position.z);
        Vector2 planet = new Vector2(originalPos.x, originalPos.z);

        Vector2 diffScaled = new Vector2((cam.x - planet.x), (cam.y - planet.y));

        // use hypotenuse equation to find total distance across
        // divide by 100 because of the object scaling
        // divided by 17987547.48f to convert km to light minutes
        // c = sqrt( a^2 + b^2)
        float totalDist = Mathf.Sqrt((diffScaled.x * diffScaled.x) + (diffScaled.y * diffScaled.y));
        return totalDist;

    }

    private void createText()
    {
        // display informative text when the planet is on screen
        // create a string to hold the distance value from the camera position
        // to the planet
        Vector3 textPos = spaceCam.WorldToScreenPoint(transform.position);
        string[] addDist = transform.GetChild(0).GetComponent<TextMeshProUGUI>().text.Split('-');
        string newTxt = addDist[0] + travelDist().ToString("0.00") + addDist[1];

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
    private void destroyText()
    {
        GameObject planetTxt = GameObject.Find(name + " distance");
        if (planetTxt != null)
        {
            Destroy(planetTxt);
        }
    }
    private void travelTo()
    {
        // when the planet is visited, cross off
        // the name of the planet
        // if its the first time visiting, add to the distance
        // if not, do not increment total distance
        if (!visited)
        {
            visited = true;
            PlanetVisited.GetComponent<TextMeshProUGUI>().color = new Color(1, 1, 1, .10f);

            // add to the total distance
            string[] formatPoints = Points.GetComponent<TextMeshProUGUI>().text.Split(' ');
            float currentPoints = float.Parse(formatPoints[0]);
            currentPoints += travelDist();
            string formatedPoints = currentPoints.ToString("0.00") + " " + formatPoints[1];
            Points.GetComponent<TextMeshProUGUI>().text = formatedPoints;

        }
    }
    private void teleport()
    {
        spaceCam.transform.position = new Vector3(originalPos.x, originalPos.y + 10, originalPos.z);
    }

    private bool inPosition()
    {
        if(spaceCam.transform.forward.z < 0 && transform.position.z < 0)
        {
            return true;
        }
        if (spaceCam.transform.forward.z >= 0 && transform.position.z >= 0)
        {
            return true;
        }
        return false;
    }
}
