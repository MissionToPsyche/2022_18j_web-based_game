using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class light_switch : MonoBehaviour
{
    private light_controller lightC = light_controller.getInstance();


    private void OnMouseDown()
    {
        lightC.lightSwitched();
    }
}
