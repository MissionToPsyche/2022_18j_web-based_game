using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WhiteBoard_Popup : MonoBehaviour
{
    // Start is called before the first frame update
    GameObject wb_pop;
    private Popup_MainClass PM = Popup_MainClass.GetInstance();
    private Interact_Distance ID = Interact_Distance.GetInsance();

    private void Awake()
    {
        wb_pop = GameObject.Find("WB popup");

    }
    void Start()
    {
        wb_pop = GameObject.Find("WB popup");
        wb_pop.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        PM.onUpdate(wb_pop);
    }
    private void OnMouseDown()
    {
        //When clicked, show popup information
        // if the player is within a certain horizontal distance from the safe
        // they can interact with it
        if (ID.checkDistance(5, gameObject))
        {
            PM.onClick(wb_pop);
        }
    }
}
