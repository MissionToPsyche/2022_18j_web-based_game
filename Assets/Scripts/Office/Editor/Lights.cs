using GitHub.Unity;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting.YamlDotNet.Serialization;
using UnityEngine;

public class Lights : MonoBehaviour
{
    // Start is called before the first frame update
    private ArrayList night_lights = new ArrayList();
    private ArrayList day_lights = new ArrayList();
    private Interact_Distance ID = Interact_Distance.GetInsance();

    private bool isDay = true;
    private void Awake()
    {
        //get all of the object references first
        night_lights.Add(GameObject.Find("sun light").GetComponent<Light>());
        day_lights.Add(GameObject.Find("ceiling fan light").GetComponent<Light>());
    }
    void Start()
    {
        for(int i = 0; i < night_lights.Count; i++)
        {
            ((Light)night_lights[i]).enabled = false;
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    private void OnMouseDown()
    {
        Debug.Log("light clicked");
        if (ID.checkDistance(5, gameObject))
        {
            //if it is "day", set it to "night"
            for (int i = 0; i < night_lights.Count; i++)
            {
                ((Light)night_lights[i]).enabled = isDay;
            }
            //change it to night, so isDay is false, so the isDay lights should be off
            isDay = !isDay;
            for (int i = 0; i < night_lights.Count; i++)
            {
                ((Light)day_lights[i]).enabled = isDay;
            }
        }
    }

    private class ArrayList<T>
    {
    }
}
