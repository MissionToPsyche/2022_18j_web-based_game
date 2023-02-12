using log4net.Util;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Interact_Distance
{
    //Singleton
    private static Interact_Distance instance = new Interact_Distance();
    private Interact_Distance() { }
    public static Interact_Distance GetInsance()
    {
        return instance;
    }

    //Check if camera distance is within the set interaction distance of the GameObject
    public bool checkDistance(int distance, GameObject interactObj, GameObject camera)
    {
        //When clicked, show popup information
        Vector3 campos = camera.GetComponent<OfficeCamera>().getPosition();
        Vector3 camang = camera.GetComponent<OfficeCamera>().getAngle();

        // the player cannot interact with the object at any distance
        float x_diff = Mathf.Abs(interactObj.transform.position.x - campos.x);
        float z_diff = Mathf.Abs(interactObj.transform.position.z - campos.z);

        if (z_diff < distance && x_diff < distance)
        {
            return true;
        }

        return false;
    }
}
