using PlasticGui.WorkspaceWindow.BrowseRepository;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class save_scene
{
    private List<scene_data> scene_Data= new List<scene_data>();
    private string sceneName;
    public save_scene(string name) {
        this.sceneName = name;
    }
    
    public void addItemData(string name, Vector3 position, Vector3 angle, bool meshEnabled = true, bool boxColliderEnabled = true)
    {
        scene_Data.Add(new scene_data(name, position, angle, meshEnabled, boxColliderEnabled));
    }
    public string getScene() { return sceneName; }

    public scene_data getData(string objName)
    {
        foreach(scene_data data in scene_Data)
        {
            if(data.getObjName() == objName)
            {
                return data;
            }
        }
        return null;
    }

    public void changeData(string objName, Vector3 position, Vector3 angle, bool meshEnabled = true, bool boxColliderEnabled = true)
    {
        foreach(scene_data data in scene_Data)
        {
            if (data.getObjName() == objName)
            {
                // update all the values saved 
                data.setPos(position);
                data.setAngle(angle);
                data.changeCollider(boxColliderEnabled);
                data.changeMesh(meshEnabled);
            }
        }
    }

    public List<scene_data> getSceneData()
    {
        return scene_Data;
    }
}
