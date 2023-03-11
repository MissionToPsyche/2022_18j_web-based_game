using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class teleport_controller
{
    private static teleport_controller tpC = new teleport_controller();
    private bool teleport= false;

    private teleport_controller() { }
    public static teleport_controller getInstance() { return tpC; }

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
}
