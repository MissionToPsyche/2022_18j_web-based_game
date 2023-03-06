using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class helper_loadscene: MonoBehaviour
{
    private scene_controller sceneC = scene_controller.getInstance();
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if(Input.GetKeyDown(KeyCode.Space))
        {
            sceneC.loadSideScene("helper_menu");
        }
    }
}
