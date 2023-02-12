using System.Collections;
using System.Collections.Generic;
using UnityEditorInternal;
using UnityEngine;

public class Popup_MainClass
{
    
    private static Popup_MainClass PM = new Popup_MainClass();
    private Popup_MainClass() { }
    public static Popup_MainClass GetInstance()
    {
        return PM;
    }

    public void onUpdate(GameObject Popup)
    {
        if (Input.GetKey(KeyCode.Space) && Popup.activeSelf)
        {
            Popup.SetActive(false);
        }
    }

    public void onClick(GameObject Popup)
    {
        Popup.SetActive(true);
    }
}
