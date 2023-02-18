using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Desk : MonoBehaviour
{
    private Interact_Distance ID = Interact_Distance.GetInsance();
    private inventory_controller invC = inventory_controller.getInstance();
    void Start()
    {
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnMouseDown()
    {
        GameObject SItem = invC.selectedItem();
        if (ID.checkDistance(5, gameObject))
        {
            if (SItem != null)
            {
                if (SItem.name == "desk_key")
                {
                    invC.useItem();
                    StartCoroutine(DeskOpenCouroutine());
                }
                gameObject.GetComponent<BoxCollider>().enabled = false;
            }
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
