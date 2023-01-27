using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Desk : MonoBehaviour
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
        if (Inventory.GetSelected().Obj_name == "desk_key")
        {
            Debug.Log("Desk unlocks now");
            StartCoroutine(DeskOpenCouroutine());
        }
    }

    IEnumerator DeskOpenCouroutine()
    {
        float new_z = transform.localPosition.z;
        Debug.Log(new_z);
        while(new_z < 2)
        {
            new_z += .01f;
            yield return new WaitForSeconds(.05f);
            transform.localPosition = new Vector3(transform.localPosition.x, transform.localPosition.y, new_z);
            Debug.Log("new z: " + new_z);
        }
    }
}
