using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class inventory_view : MonoBehaviour
{
    private inventory_controller invC = inventory_controller.getInstance();
    void Start()
    {
        invC.setInventory(gameObject.scene.name);
    }

    // Update is called once per frame
    void Update()
    {
        int keycode = 49;
        for(int i = 0; i < 5; i++)
        {
            if((Input.GetKey((KeyCode)(keycode + i)))) {
                invC.updateSelection(keycode + i);
            }
        }
    }
}
