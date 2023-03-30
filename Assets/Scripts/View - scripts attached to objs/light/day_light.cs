using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class day_light : MonoBehaviour
{
    private light_controller lightC = light_controller.getInstance();
    // Start is called before the first frame update
    void Start()
    {
        lightC.addDayLight(name);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
