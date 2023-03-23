using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class teleport_controller
{
    private static teleport_controller tpC = new teleport_controller();
    private List<string> planetsVisited = new List<string>();
    private bool teleport= false;
    private bool Win = false;
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
        return planetsVisited.Count == 8;
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

    public void WinLose(float finalscore)
    {
        if(finalscore > 1200)
        {
            Win= true;
        }
    }
}
