using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class collectable_view : MonoBehaviour
{
    private inventory_controller invC = inventory_controller.getInstance();
    private Interact_Distance ID = Interact_Distance.GetInsance();
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnMouseDown()
    {
        //add distance
        if(ID.checkDistance(5, gameObject))
        {
            invC.addInventory(gameObject);
            gameObject.SetActive(false);
        }
    }
}
