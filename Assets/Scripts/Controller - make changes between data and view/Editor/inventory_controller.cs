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
            currentInv.addInv(item.name);
            Debug.Log(item.gameObject.name);
        }
        updateHud();
    }
    public void updateSelection(int keyCode)
    {
        clearSelection();
        int subtractkey = 48;
        for(int i = 1; i < 6; i++)
        {//ranges from 1-5
            if(i == (keyCode - subtractkey))
            {
                if (selectItem(i))
                {
                    GameObject.Find("background_" + i).GetComponent<Image>().color = Color.gray;
                }

            }
        }
    }
    private void clearSelection()
    {
        for(int i = 1; i < 6; i++)
        {
            Image bck = GameObject.Find("background_" + i).GetComponent<Image>();
            bck.color = new Color(1, 1, 1, .5f);
        }
    }
    private void updateHud()
    {
        int counter = 1; 
        foreach (string GO in currentInv.getInv())
        {
            if(GO != null)
            {
                Image bck = GameObject.Find("background_" + counter).GetComponent<Image>();
                bck.sprite = GameObject.Find(GO).GetComponent<Image>().sprite;
                bck.color = new Color(1, 1, 1, 1);
                counter++;
            }
        }
        //when removing an object, the image of furthest collectable item may not be removed
        //the for loop starts off at the next position that should not have an image and updates the image to be blank
        for(int i = counter; i < 5; i++)
        {
            GameObject.Find("background_" + i).GetComponent<Image>().sprite = null;
        }
    }
    public bool selectItem(int position)
    {
        return currentInv.selectItem(position);
    }
    public void useItem()
    {
        currentInv.removeInv(currentInv.selectItem());
        clearSelection();
        updateHud();
    }
    public string selectedItem()
    {
        return currentInv.selectItem();
    }
}
