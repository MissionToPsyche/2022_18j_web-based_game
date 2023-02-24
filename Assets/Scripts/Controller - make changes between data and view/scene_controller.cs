using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class scene_controller
{
    // Start is called before the first frame update
    private static scene_controller sceneC = new scene_controller();

    private List<save_scene> scenes = new List<save_scene>();
    private save_scene currentScene;
    private scene_controller() {
    }
    public static scene_controller getInstance() { return sceneC; }
    public void setScene(string sceneName)
    {
        bool found = false;
        foreach(save_scene sn in scenes)
        {
            if(sceneName == sn.getScene())
            {
                currentScene= sn;
                found = true;
            }
        }
        if(!found)
        {
            save_scene temporary = new save_scene(sceneName);
            scenes.Add(temporary);
            currentScene = temporary;
        }
    }

    public void addData(string name, Vector3 position, Vector3 angle, bool meshEnabled = true, bool boxColliderEnabled = true)
    {
        currentScene.addItemData(name, position, angle, meshEnabled, boxColliderEnabled);
    }
    public void changeData(string name, Vector3 position, Vector3 angle, bool meshEnabled = true, bool boxColliderEnabled = true)
    {
        currentScene.changeData(name, position, angle, meshEnabled, boxColliderEnabled);
    }
    public Vector3 getPos(string name)
    {
        return currentScene.getData(name).getPos();
    }
    public Vector3 getAng(string name)
    {
        return currentScene.getData(name).getAngle();
    }
    public bool getMesh(string name)
    {
        return currentScene.getData(name).getMeshEnabled();
    }
    public bool getCollider(string name)
    {
        return currentScene.getData(name).getBoxColliderEnabled();
    }
    public bool startDataExists(string name)
    {
        if (currentScene.getData(name) == null)
        {
            return false;
        }
        return true;
    }
}
