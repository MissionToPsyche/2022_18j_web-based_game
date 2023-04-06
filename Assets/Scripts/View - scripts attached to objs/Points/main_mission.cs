using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class main_mission : MonoBehaviour
{
    private bool collected = false;
    private point_controller pointC = point_controller.getInstance();
    private Interact_Distance ID = Interact_Distance.GetInsance();

    private void Start()
    {
        if(!(pointC.currentSequence() == name))
        {
            GetComponent<Collider>().enabled = false;
        }
    }
    private void OnMouseDown()
    {
        if(ID.checkDistance(5, gameObject))
        {
            if (collected == false)
            {
                collected = true;
                pointC.incScore(gameObject);
            }
        }
    }
    private void Update()
    {
        if (pointC.currentSequence() == name)
        {
            GetComponent<Collider>().enabled = true;
        }
    }
}
