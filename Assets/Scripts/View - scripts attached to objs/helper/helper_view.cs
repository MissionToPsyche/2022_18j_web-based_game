using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class helper_view : MonoBehaviour
{
    private scene_controller sceneC = scene_controller.getInstance();
    private helper_controller helpC = helper_controller.getInstance();
    // Start is called before the first frame update
    void Start()
    {
        Cursor.lockState = CursorLockMode.Confined;
        helpC.OnclickBtns();
    }

    // Update is called once per frame
    void Update()
    {
        if(Input.GetKeyDown(KeyCode.Space))
        {
            sceneC.reloadMainScene();
        }
    }
}
