using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class night_light : MonoBehaviour
{
    private light_controller lightC = light_controller.getInstance();
    // Start is called before the first frame update
    void Start()
    {
        lightC.addNightLight(GetComponent<Light>());
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
