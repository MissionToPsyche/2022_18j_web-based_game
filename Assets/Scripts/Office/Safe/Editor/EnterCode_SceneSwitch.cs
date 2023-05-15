using PlasticPipe.PlasticProtocol.Messages;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class EnterCode_SceneSwitch : MonoBehaviour
{
    private Interact_Distance ID = Interact_Distance.GetInsance();
    private scene_controller sceneC = scene_controller.getInstance();
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

                sceneC.changeData("safe_door", safe_door.transform.position, safe_door.transform.eulerAngles, true, true);

            }

            // Need to disable the safe's boxcollider after successfully opening safe 
            // in order to interact with any objects within the safe
            GameObject safe = GameObject.Find("office_safe");
            if(safe != null)
            {
                safe.GetComponent<BoxCollider>().enabled = false;
                sceneC.changeData("office_safe", safe.transform.position, safe.transform.eulerAngles, true, false);
            }

        }
    }
    void Update()
    {
        
    }

    private void OnMouseDown()
    {
        // if the player is within a certain horizontal distance from the safe
        // they can interact with it
        if (ID.checkDistance(5, gameObject))
        {
            // if the safe is still locked and this puzzle piece is the current one in sequence
            // switch scenes to enter code
            if (Safe_Locked.IsLocked == true)
            {
                SceneManager.LoadScene("Safe Code");
            }
        }

    }
}