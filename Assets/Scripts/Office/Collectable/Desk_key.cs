using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UI;

public class Desk_key : MonoBehaviour, Collectable_Obj
{
    private Interact_Distance ID = Interact_Distance.GetInsance();
    public string Obj_name { 
        get => "desk_key";
    }

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnMouseDown()
    {
        if(ID.checkDistance(5, gameObject))
        {
            //add item to inventory 
            Inventory.Add_inv(this);
            FindObjectOfType<UI_Inventory>().add_to_inv();

            //remove item from scene
            gameObject.SetActive(false);
        }
    }
}
