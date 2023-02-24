using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class set_scene : MonoBehaviour
{
    private scene_controller sceneC = scene_controller.getInstance();
    // Start is called before the first frame update
    private void Awake()
    {
        sceneC.setScene(gameObject.scene.name);
    }
    void Start()
    {
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
