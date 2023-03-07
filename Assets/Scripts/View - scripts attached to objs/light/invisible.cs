using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class invisible : MonoBehaviour
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
        // not gone yet, disable it
        if (!lightC.isDay() && GetComponent<MeshRenderer>().enabled)
        {
            GetComponent<MeshRenderer>().enabled = false;
        }
        // if the lights are on, and the mesh renderer is not
        // enabled yet, enabled it
        else if(lightC.isDay() && !GetComponent<MeshRenderer>().enabled)
        {
            GetComponent<MeshRenderer>().enabled = true;
        }
    }
}
