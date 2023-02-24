using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class save_object : MonoBehaviour
{
    private scene_controller sceneC = scene_controller.getInstance();
    // Start is called before the first frame update
    void Start()
    {
        //if the data is already stored, set the object's values
        if(sceneC.startDataExists(gameObject.name))
        {
            transform.position = sceneC.getPos(gameObject.name);
            transform.eulerAngles = sceneC.getAng(gameObject.name);
            gameObject.GetComponent<MeshRenderer>().enabled = sceneC.getMesh(gameObject.name);
            gameObject.GetComponent<BoxCollider>().enabled = sceneC.getCollider(gameObject.name);
        }
        //if the data is not stored, create a new data item
        else
        {
            sceneC.addData(gameObject.name, transform.position, transform.eulerAngles, 
                gameObject.GetComponent<MeshRenderer>().enabled, gameObject.GetComponent<BoxCollider>().enabled);
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
