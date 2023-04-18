using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class disappear : MonoBehaviour
{
    private light_controller lightC = light_controller.getInstance();
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        // if the lights are turned off, and the mesh renderer is 
        // not gone yet, disable it and the box collider
        if (!lightC.isDay() && GetComponent<MeshRenderer>().enabled)
        {
            GetComponent<MeshRenderer>().enabled = false;
            if (GetComponent<BoxCollider>())
            {
                GetComponent<BoxCollider>().enabled = false;
            }
            if (GetComponent<MeshCollider>())
            {
                GetComponent<MeshCollider>().enabled = false;
            }
        }
        // if the lights are on, and the mesh renderer is not
        // enabled yet, enabled it and the box collider
        else if (lightC.isDay() && !GetComponent<MeshRenderer>().enabled)
        {
            GetComponent<MeshRenderer>().enabled = true; 
            if (GetComponent<BoxCollider>())
            {
                GetComponent<BoxCollider>().enabled = true;
            }
            if (GetComponent<MeshCollider>())
            {
                GetComponent<MeshCollider>().enabled = true;
            }
        }
    }
}
