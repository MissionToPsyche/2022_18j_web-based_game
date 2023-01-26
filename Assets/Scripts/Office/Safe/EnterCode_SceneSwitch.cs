using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class EnterCode_SceneSwitch : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        Cursor.lockState = CursorLockMode.Locked;
        // if the safe is unlocked, when the office scene reloads,
        // the safe will be open
        if(Safe_Locked.IsLocked == false)
        {
            GameObject safe_door = GameObject.Find("safe_door");
            if(safe_door != null)
            {
                safe_door.transform.SetLocalPositionAndRotation(new Vector3((float)0.01149002, (float)-0.004848823),
                                new Quaternion(0, 0, (float)-30, 40));
                                //value of 40 is what opens the safe door
                
            }

            // Need to disable the safe's boxcollider after successfully opening safe 
            // in order to interact with any objects within the safe
            GameObject safe = GameObject.Find("office_safe");
            if(safe != null)
            {
                safe.GetComponent<BoxCollider>().enabled = false;
            }
        }
    }
    void Update()
    {
        
    }

    private void OnMouseDown()
    {
        Vector3 campos = FindObjectOfType<OfficeCamera>().getPosition();
        Vector3 camang = FindObjectOfType<OfficeCamera>().getAngle();

        // the player cannot interact with the object at any distance
        float x_diff = Mathf.Abs(transform.position.x - campos.x);
        float z_diff = Mathf.Abs(transform.position.z - campos.z);

        // if the player is within a certain horizontal distance from the safe
        // they can interact with it
        if(z_diff < 5 && x_diff < 5)
        {
            // if the safe is still locked, switch scenes to
            // enter code
            if(Safe_Locked.IsLocked == true)
            {
                // save position & angle of camera before entering scene
                OfficeSpawning.CameraAngle = FindObjectOfType<OfficeCamera>().getAngle();
                OfficeSpawning.CameraPos = FindObjectOfType<OfficeCamera>().getPosition();

                SceneManager.LoadScene("Safe Code");
            }
        }

    }
}
