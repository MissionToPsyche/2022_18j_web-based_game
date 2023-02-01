using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Calendar_Popup : MonoBehaviour
{
    // Start is called before the first frame update
    Calendar_Info cal_popup;
    void Start()
    {
        cal_popup = GameObject.FindObjectOfType<Calendar_Info>();
        cal_popup.invisible();

    }

    // Update is called once per frame
    void Update()
    {
        if(Input.GetKey(KeyCode.Space) & cal_popup.getvisibility())
        {
            cal_popup.invisible();
        }
    }
    private void OnMouseDown()
    {
        //When clicked, show popup information
        cal_popup.visible();
    }

}
