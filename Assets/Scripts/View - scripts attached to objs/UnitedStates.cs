using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UnitedStates : MonoBehaviour
{
    private inventory_controller invC = inventory_controller.getInstance();
    private Interact_Distance ID = Interact_Distance.GetInsance();
    private popup_controller popupC = popup_controller.getInstance();
    private scene_controller sceneC = scene_controller.getInstance();
    private void OnMouseDown()
    {
        if(ID.checkDistance(5, gameObject) && !popupC.isPopupVisible())
        {
            string SItem = invC.selectedItem();

            if(SItem != null)
            {
                for(int i = 0; i < gameObject.transform.childCount; i++)
                {
                    if(SItem == (gameObject.transform.GetChild(i).name + "_Inv")){
                        //popup info about states, gets the child being used, then gets that childs image
                        //enable mesh renderer
                        GameObject child = gameObject.transform.GetChild(i).gameObject;

                        popupC.display_popup(child.transform.GetChild(0).GetComponent<Image>());
                        child.GetComponent<MeshRenderer>().enabled = true;
                        child.GetComponent<BoxCollider>().enabled = true;

                        sceneC.changeData(child.name, child.transform.position, child.transform.eulerAngles, true, true);
                        invC.useItem();
                    }
                }
            }
        }

    }
}
