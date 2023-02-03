using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public static class OfficeSpawning 
{
    // get the spawning vectors of where the player last left off in the scene
    // determined by if the player clicks on certain objects
    // can be used to enter the room from a door, or to reload scene after doing a minigame
    private static Vector3 camera_pos = new Vector3(7.01f, 58.051f, 40.1f);
    private static Vector3 camera_angle = new Vector3(0f, 132.963f, 0f);

    public static Vector3 CameraPos { 
        get { return camera_pos; }
        set { camera_pos = value; }
    }

    public static Vector3 CameraAngle
    {
        get { return camera_angle; }
        set { camera_angle = value; }
    }
}
