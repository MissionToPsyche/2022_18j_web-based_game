using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class inventory_controller
{
    private static inventory_controller inventoryC = new inventory_controller();
    private inventory officeInv;
    private inventory conferenceInv;
    private inventory currentInv;

    private inventory_controller() {
        officeInv = new inventory();
        conferenceInv = new inventory();
        currentInv = officeInv;
    }
    public static inventory_controller getInstance() { 
        return inventoryC; 
    }

    public void setInventory(string sceneName)
    {
        if(sceneName == "Office")
        {
            currentInv = officeInv;
        }else if(sceneName == "ConferenceRoom")
        {
            currentInv = conferenceInv;
        }
        updateHud();
    }
    public void addInventory(GameObject item)
    {
        if (currentInv.hasSpace())
        {
            currentInv.addInv(item);
        }
        updateHud();
    }
    private void removeInventory(GameObject item)
    {
        currentInv.removeInv(item);
        updateHud();
    }
    public void updateSelection(int keyCode)
    {
        int subtractkey = 48;
        for(int i = 1; i < 6; i++)
        {//ranges from 1-5
            if(i == (keyCode - subtractkey))
            {
                GameObject.Find("background_" + i).GetComponent<Image>().color = Color.white;

                if (selectItem(i))
                {
                    GameObject.Find("background_" + i).GetComponent<Image>().color = Color.gray;
                }

            }
        }
    }
    private void updateHud()
    {
        int counter = 1; 
        foreach (GameObject GO in currentInv.getInv())
        {
            GameObject.Find("background_" + counter).GetComponent<Image>().sprite =
                GameObject.Find(GO.name).GetComponent<Image>().sprite;
        }
    }
    public bool selectItem(int position)
    {
        return currentInv.selectItem(position);
    }
    public void useItem()
    {
        currentInv.removeInv(currentInv.useItem());
    }
}
