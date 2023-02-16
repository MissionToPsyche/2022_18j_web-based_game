using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WallCollision : MonoBehaviour
{
    private Renderer renderer;
    private float BoundaryBuffer = 1f;
    private float[] Boundaries = new float[5];
    camera_controller camC;
    // Start is called before the first frame update
    void Start()
    {
        camC = camera_controller.getInstance();
        renderer = GetComponent<Renderer>();
        Boundaries[0] = renderer.bounds.min.z;
        Boundaries[1] = renderer.bounds.max.z;
        Boundaries[2] = renderer.bounds.min.x;
        Boundaries[3] = renderer.bounds.max.x;
        camC.setBoundaries(Boundaries, BoundaryBuffer, this.name);

    }
    // Update is called once per frame
    void Update()
    {
        
    }
}
