using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Popup_object : MonoBehaviour
{
    private popup_controller popupC = popup_controller.getInstance();
    private Interact_Distance ID = Interact_Distance.GetInsance();
    private GameObject ParentWImage;

    private void Awake()
    {
        GameObject currentObj = gameObject;
        GameObject parentObj = gameObject.transform.parent.gameObject;

        //while the current object has a parent
        while (parentObj.GetComponent<Image>() == null)
        {
            currentObj = parentObj;
            parentObj = currentObj.transform.parent.gameObject;
        }
        ParentWImage = parentObj;
    }
    void Update()
    {
        //if space is pressed, then clear popup
        if(Input.GetKey(KeyCode.Space) & popupC.isPopupVisible())
        {
            popupC.clear_popup();
        }
    }

    private void OnMouseDown()
    {
        if(ID.checkDistance(5, gameObject) && !popupC.isPopupVisible())
        {
            popupC.display_popup(ParentWImage.GetComponent<Image>());
        }
    }
}
