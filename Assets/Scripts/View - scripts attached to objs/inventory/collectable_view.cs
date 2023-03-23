using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class collectable_view : MonoBehaviour

    // attach script to object to be collected
    // object needs to be contained in empty object with an image referencing the collectable object
{
    private inventory_controller invC = inventory_controller.getInstance();
    private Interact_Distance ID = Interact_Distance.GetInsance();
    private scene_controller sceneC = scene_controller.getInstance();
    [SerializeField] private AudioSource myAudioSource;

    private void Start()
    {
        Debug.Log(gameObject.name);
    }
    private void OnMouseDown()
    {
        // find parent object containing image for inventory and add it to the inventory
        // make collectable object disappear when clicked
        if (ID.checkDistance(5, gameObject) & gameObject.GetComponent<MeshRenderer>().enabled)
        {
            for(int i = 0; i < gameObject.transform.childCount; i++)
            {
                if (gameObject.transform.GetChild(i).GetComponent<Image>() != null)
                {
                    myAudioSource.Play();
                    GameObject childImage = gameObject.transform.GetChild(i).gameObject;
                    invC.addInventory(childImage);
                    gameObject.GetComponent<MeshRenderer>().enabled= false;
                    gameObject.GetComponent<BoxCollider>().enabled= false;
                    sceneC.changeData(gameObject.name, transform.position, transform.eulerAngles, false, false);
                }
            }
            
        }
    }
}
