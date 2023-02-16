using CodiceApp;
using GitHub.Unity;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class inventory
{
    private List<GameObject> inv = new List<GameObject>();
    private int maxSize = 5;
    private GameObject selectedItem;

    public List<GameObject> getInv()
    {
        return inv;
    }
    public void addInv(GameObject item)
    {
        inv.Add(item);
    }
    public void removeInv(GameObject item)
    {
        inv.Remove(item);
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
    public GameObject useItem()
    {
        return selectedItem;
    }
    
}
