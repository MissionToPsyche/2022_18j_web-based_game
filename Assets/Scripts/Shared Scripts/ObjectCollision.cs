using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObjectCollision : MonoBehaviour
{
    private GameObject camera;
    private Renderer renderer;
    public float BoundaryBuffer = .2f;
    private float[] Boundaries = new float[5];
    // Start is called before the first frame update
    void Start()
    {
        renderer= GetComponent<Renderer>();
        Boundaries[0] = renderer.bounds.max.z;
        Boundaries[1] = renderer.bounds.min.z;
        Boundaries[2] = renderer.bounds.max.x;
        Boundaries[3] = renderer.bounds.min.x;
        Boundaries[4] = BoundaryBuffer;
        camera = GameObject.Find("OfficeCamera");
        camera.GetComponent<OfficeCamera>().addCamBoundaries(Boundaries);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
