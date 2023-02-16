using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public static class Inventory
{
    //Collectable Object Inventory
    private static List <Collectable_Obj> inventory = new List<Collectable_Obj>();

    //Selected Collectable Object
    private static Collectable_Obj selected;
    private static int selected_pos;

    public static void Add_inv(Collectable_Obj CO)
    {
        inventory.Add(CO);
        Debug.Log("Added " + CO + " to the list!!!!!");
    }
    
    public static void Use_inv(Collectable_Obj CO)
    {
        selected= null;
        inventory.Remove(CO);
    }
    public static Collectable_Obj GetSelected()
    {
        return selected;
    }
    public static int GetSelectedPos()
    {
        return selected_pos;
    }
    public static void SetSelected(int position)
    {
        // If the player wants the item in slot 1,
        // the position in the list will be index 0
        selected = inventory[position - 1];
        selected_pos = position;
    }
    public static List<Collectable_Obj> GetInventory()
    {
        return inventory;
    }
    
}
