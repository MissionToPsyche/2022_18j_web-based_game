using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class light_controller
{
    private static light_controller lightC = new light_controller();
    private light_controller() { }
    public static light_controller getInstance() { return lightC; }

    private List<string> night_lights = new List<string>();
    private List<string> day_lights = new List<string>();
    private bool isDayLight = true;

    public void addNightLight(string light)
    {
        GameObject.Find(light).GetComponent<Light>().enabled = false;
        night_lights.Add(light);
    }
    public void addDayLight(string light)
    {
        GameObject.Find(light).GetComponent<Light>().enabled = true;
        day_lights.Add(light);
    }

    public void lightSwitched()
    {
        if (!isDayLight)
        {
            isDayLight = true;
            //turn off night lights
            //turn on day lights
            //re-enable meshRender and boxcollider
            foreach(string day in day_lights)
            {
                GameObject.Find(day).GetComponent<Light>().enabled = true;
            }
            foreach(string night in night_lights)
            {
                GameObject.Find(night).GetComponent<Light>().enabled = false;
            }
        }
        else
        {
            isDayLight = false;
            //turn on night lights
            //turn off day lights
            //disable meshRender and boxcollider(some) - invisible (walls), disappear(interactable items)
            foreach (string day in day_lights)
            {
                GameObject.Find(day).GetComponent<Light>().enabled = false;
            }
            foreach (string night in night_lights)
            {
                GameObject.Find(night).GetComponent<Light>().enabled = true;
            }
        }
    }
    public bool isDay()
    {
        return isDayLight;
    }
}
