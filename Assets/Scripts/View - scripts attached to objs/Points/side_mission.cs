using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class side_mission : MonoBehaviour
{
    private bool collected = false;
    private point_controller pointC = point_controller.getInstance();
    private Interact_Distance ID = Interact_Distance.GetInsance();
    private void OnMouseDown()
    {
        if (ID.checkDistance(5, gameObject))
        {
            if (collected == false)
            {
                collected = true;
                pointC.incScore(gameObject);
            }
        }
    }
}
