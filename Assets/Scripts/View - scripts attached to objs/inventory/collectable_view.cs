using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class collectable_view : MonoBehaviour

    // attach script to object to be collected
    // object needs to be contained in empty object with an image referencing the collectable object
{
    private inventory_controller invC = inventory_controller.getInstance();
    private Interact_Distance ID = Interact_Distance.GetInsance();

    private void OnMouseDown()
    {
        // find parent object containing image for inventory and add it to the inventory
        // make collectable object disappear when clicked
        if (ID.checkDistance(5, gameObject))
        {
            GameObject parent = gameObject.transform.parent.gameObject;
            invC.addInventory(parent);
            gameObject.SetActive(false);
        }
    }
}
