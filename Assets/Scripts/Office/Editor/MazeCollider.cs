using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MazeCollider : MonoBehaviour
{
    private GameObject Asteroid;
    private Renderer renderer;
    public float BoundaryBuffer = 1f;
    private float[] Boundaries = new float[5];

    // Start is called before the first frame update
    void Start()
    {
        renderer = GetComponent<Renderer>();
        Boundaries[0] = renderer.bounds.max.z;
        Boundaries[1] = renderer.bounds.min.z;
        Boundaries[2] = renderer.bounds.max.x;
        Boundaries[3] = renderer.bounds.min.x;
        Boundaries[4] = BoundaryBuffer;
       // Asteroid = GameObject.Find("Asteroid");
       // Asteroid.GetComponent<Asteroid>().addCamBoundaries(Boundaries);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
