using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class side_mission : MonoBehaviour
{
    private bool collected = false;
    private point_controller pointC = point_controller.getInstance();
    private void OnMouseDown()
    {
        if(collected == false)
        {
            collected = true;
            pointC.incScore(gameObject);
        }
    }
}
