using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Calendar_Popup : MonoBehaviour
{
    // Start is called before the first frame update
    GameObject cal_pop;
    Popup_MainClass PM = Popup_MainClass.GetInstance();
    Interact_Distance ID = Interact_Distance.GetInsance();

    private void Awake()
    {
        cal_pop = GameObject.Find("cal popup");
    }
    void Start()
    {
        cal_pop.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        PM.onUpdate(cal_pop);
    }
    private void OnMouseDown()
    {
        //When clicked, show popup information
        // if the player is within a certain horizontal distance from the safe
        // they can interact with it
        if (ID.checkDistance(5, gameObject, FindObjectOfType<OfficeCamera>().gameObject))
        {
            PM.onClick(cal_pop);
        }
    }

}
