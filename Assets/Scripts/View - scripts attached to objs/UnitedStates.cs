using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UnitedStates : MonoBehaviour
{
    private inventory_controller invC = inventory_controller.getInstance();
    private Interact_Distance ID = Interact_Distance.GetInsance();
    private void OnMouseDown()
    {
        if(ID.checkDistance(5, gameObject))
        {
            string SItem = invC.selectedItem();

            if(SItem != null)
            {
                for(int i = 0; i < gameObject.transform.childCount; i++)
                {
                    if(SItem == (gameObject.transform.GetChild(i).name + "_Inv")){
                        //popup info about states
                        //enable mesh renderer
                        gameObject.transform.GetChild(i).GetComponent<MeshRenderer>().enabled = true;
                        invC.useItem();
                    }
                }
            }
        }

    }
}
