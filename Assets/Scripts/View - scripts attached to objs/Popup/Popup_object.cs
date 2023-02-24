using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Popup_object : MonoBehaviour
{
    private popup_controller popupC = popup_controller.getInstance();
    private Interact_Distance ID = Interact_Distance.GetInsance();
    private GameObject childwithImage;

    private void Awake()
    {
        GameObject currentObj = gameObject;
        GameObject childObj;


        for(int i = 0; i < transform.childCount; i++)
        {
            childObj= transform.GetChild(i).gameObject;
            if(childObj.GetComponent<Image>() != null)
            {
                childwithImage = childObj;
                break;
            }
        }
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
            popupC.display_popup(childwithImage.GetComponent<Image>());
        }
    }
}
