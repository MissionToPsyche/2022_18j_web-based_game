using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class teleport_controller
{
    private static teleport_controller tpC = new teleport_controller();
    private List<string> planetsVisited = new List<string>();
    private bool teleport= false;
    private teleport_controller() { }
    public static teleport_controller getInstance() { return tpC; }

    public void addPlanet(string name)
    {
        if (!checkVisited(name))
        {
            planetsVisited.Add(name);
        }
    }
    private bool checkVisited(string name)
    {
        return planetsVisited.Contains(name);
    }
    public bool allPlanetsVisited()
    {
        // for the sake of the demo, it will be set to 5 planets reset back to 8 later
        return planetsVisited.Count == 5;
    }
    public void teleporting()
    {
        this.teleport = true;
    }
    public bool isTeleport()
    {
        return this.teleport;
    }
    public void reset()
    {
        this.teleport = false;
    }

    public int WinLose(float finalscore)
    {
        // player needs to get within top 1/3 to gain points on space explorer mission
        // determined to be aroud 810 as (highest - lowest)/3
        if(finalscore < 810)
        {
            // 640 is approximately just below the lowest score possible
            // get the percent error then convert it to the inverted percent
            // this is the mulitplier with the base value
            // if the player gets close to 640, they nearly get all 500 points

            return (int)((1 - (Mathf.Abs(finalscore - 640) / 640)) * 500);
        }

        return 0;
    }
}
