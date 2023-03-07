using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class light_controller
{
    private static light_controller lightC = new light_controller();
    private light_controller() { }
    public static light_controller getInstance() { return lightC; }

    private List<Light> night_lights = new List<Light>();
    private List<Light> day_lights = new List<Light>();
    bool isDayLight = true;

    public void addNightLight(Light light)
    {
        light.enabled= false;
        night_lights.Add(light);
    }
    public void addDayLight(Light light)
    {
        light.enabled= true;
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
            foreach(Light day in day_lights)
            {
                day.enabled = true;
            }
            foreach(Light night in night_lights)
            {
                night.enabled = false;
            }
        }
        else
        {
            isDayLight = false;
            //turn on night lights
            //turn off day lights
            //disable meshRender and boxcollider(some) - invisible (walls), disappear(interactable items)
            foreach (Light day in day_lights)
            {
                day.enabled = false;
            }
            foreach (Light night in night_lights)
            {
                night.enabled = true;
            }
        }
    }
    public bool isDay()
    {
        return isDayLight;
    }
}
