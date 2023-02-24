using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class scene_controller
{
    // Start is called before the first frame update
    private static scene_controller sceneC = new scene_controller();
    private List<Scene> scenes = new List<Scene>();
    private Scene currentScene;
    private scene_controller() {
    }
    public static scene_controller getInstance() { return sceneC; }
    public void setScene(Scene scene)
    {
        bool found = false;
        foreach(Scene sn in scenes)
        {
            if(scene.name == sn.name)
            {
                currentScene= sn;
                found = true;
                break;
            }
        }
        if(!found)
        {
            scenes.Add(scene);
            currentScene = scene;
        }
    }
    public void loadScene()
    {
        SceneManager.LoadScene(currentScene.name);
    }

}
