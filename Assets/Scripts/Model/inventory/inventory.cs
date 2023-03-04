using CodiceApp;
using GitHub.Unity;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class inventory
{
    private List<string> inv = new List<string>();
    private int maxSize = 5;
    private string selectedItem;

    public List<string> getInv()
    {
        return inv;
    }
    public void addInv(string itemName)
    {
        inv.Add(itemName);
    }
    public void removeInv(string itemName)
    {
        inv.Remove(itemName);
    }
    public bool hasSpace()
    {
        return inv.Count < maxSize;
    }
    public bool selectItem(int position)
    {
        if(position > 0 && position <= inv.Count)
        {
            selectedItem = inv[position - 1];
            return true;
        }
        return false;
    }
    public string selectItem()
    {
        return selectedItem;
    }
    
}
