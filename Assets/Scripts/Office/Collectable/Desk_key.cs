using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UI;

public class Desk_key : MonoBehaviour
{

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
        Vector3 camerapos = OfficeSpawning.CameraPos;
        float diff_z = Mathf.Abs(transform.position.z - camerapos.z);
        float diff_x = Mathf.Abs(transform.position.x - camerapos.x);
        Debug.Log(diff_x+ " " + diff_z);

        if(diff_z < 5 && diff_x < 5)
        {
            //add item to inventory 

            //remove item from scene
            Destroy(gameObject);
        }
    }
}
