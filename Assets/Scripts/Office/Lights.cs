using GitHub.Unity;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Lights : MonoBehaviour
{
    // Start is called before the first frame update
    private ArrayList night_lights = new ArrayList();
    private ArrayList day_lights = new ArrayList();
    private bool isDay = true;
    private void Awake()
    {
        //get all of the object references first
        night_lights.Add(GameObject.Find("sun light"));
        day_lights.Add(GameObject.Find("ceiling fan light"));
    }
    void Start()
    {
        for(int i = 0; i < night_lights.Count; i++)
        {
            ((GameObject)night_lights[i]).SetActive(false);
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnMouseDown()
    {
        if (isDay)
        {
            //if it is "day", set it to "night"
            isDay= false;
            for()
        }
    }
}
