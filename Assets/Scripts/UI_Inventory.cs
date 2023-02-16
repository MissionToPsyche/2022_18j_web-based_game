using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Android;
using UnityEngine.UI;

public class UI_Inventory : MonoBehaviour
{
    // This script is for the "player inventory"
    // UI element under Canvas in the Unity scene
    List<Collectable_Obj> inv;

    // Start is called before the first frame update
    void Start()
    {
        // Fill out the displayed inventory if player has items
        inv = Inventory.GetInventory();
        for (int i = 0; i < inv.Count; i++)
        {
            string itemslot = "background_" + (i + 1);
            GameObject.Find(itemslot).GetComponent<Image>().sprite 
                = GameObject.Find(inv[i].Obj_name).GetComponent<Image>().sprite;
        }
    }

    // Update is called once per frame
    void Update()
    {
        // "listen" to the position selected by the user to
        // set the selected object
        int position = 1;
        string itemslot = "background_";
        int listsize = Inventory.GetInventory().Count;
        if ((Input.GetKey(KeyCode.Alpha1) || Input.GetKey(KeyCode.Keypad1)) & (listsize > 0))
        {
            itemslot += "1";
            GameObject.Find(itemslot).GetComponent<Image>().color = Color.gray;
            position = 1;
        }
        else if ((Input.GetKey(KeyCode.Alpha2) || Input.GetKey(KeyCode.Keypad2)) & (listsize > 1))
        {
            itemslot += "2";
            GameObject.Find(itemslot).GetComponent<Image>().color = Color.gray;
            position = 2;
        }
        else if ((Input.GetKey(KeyCode.Alpha3) || Input.GetKey(KeyCode.Keypad3)) & (listsize > 2))
        {
            itemslot += "3";
            GameObject.Find(itemslot).GetComponent<Image>().color = Color.gray;
            position = 3;
        }
        else if ((Input.GetKey(KeyCode.Alpha4) || Input.GetKey(KeyCode.Keypad4)) & (listsize > 3))
        {
            itemslot += "4";
            GameObject.Find(itemslot).GetComponent<Image>().color = Color.gray;
            position = 4;
        }
        else if ((Input.GetKey(KeyCode.Alpha5) || Input.GetKey(KeyCode.Keypad5)) & (listsize > 4))
        {
            itemslot += "5";
            GameObject.Find(itemslot).GetComponent<Image>().color = Color.gray;
            position = 5;
        }
        else
        {
            //returns if nothing is selected
            return;
        }

        // Clears/unselects all of the slots in the UI inventory except
        // the recently chosen item slot
        for(int i = 0; i < 5; i++)
        {
            if((i+1) != position)
            {
                itemslot = "background_" + (i + 1);
                GameObject.Find(itemslot).GetComponent<Image>().color = Color.white;
            }
        }
        Inventory.SetSelected(position);
    }



    // Called when another collectable object is found
    public void add_to_inv()
    {
        inv = Inventory.GetInventory();
        for (int i = 0; i < inv.Count; i++)
        {
            string itemslot = "background_" + (i + 1);
            GameObject.Find(itemslot).GetComponent<Image>().sprite
                = GameObject.Find(inv[i].Obj_name).GetComponent<Image>().sprite;
        }
    }
}
