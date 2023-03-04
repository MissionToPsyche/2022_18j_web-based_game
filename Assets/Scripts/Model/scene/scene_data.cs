using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class scene_data
{
    private string objName;
    private Vector3 position;
    private Vector3 angle;
    private bool meshEnabled;
    private bool boxColliderEnabled;

    public scene_data(string objName, Vector3 position, Vector3 angle, bool meshEnabled = true, bool boxColliderEnabled = true)
    {
        this.objName = objName;
        this.position = position;
        this.angle = angle;
        this.meshEnabled = meshEnabled;
        this.boxColliderEnabled = boxColliderEnabled;
        this.objName = objName;
    }

    public Vector3 getPos() { return position; }
    public Vector3 getAngle() { return angle; }
    public bool getMeshEnabled() { return meshEnabled; }
    public bool getBoxColliderEnabled() { return boxColliderEnabled; }
    public void setPos(Vector3 pos) { this.position= pos; }
    public void setAngle(Vector3 angle) { this.angle=angle; }
    public void changeMesh(bool mesh) { meshEnabled = mesh; }
    public void changeCollider(bool collide) { boxColliderEnabled= collide; }
    public string getObjName() { return objName; }


}
