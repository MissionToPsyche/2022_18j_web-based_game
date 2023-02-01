using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChairPuzzleColliders : MonoBehaviour
{
    private Renderer renderer;
    float[] boundaries = new float[5];
    float boundarybuffer = 25f;


    // Start is called before the first frame update
    void Start()
    {
        renderer= GetComponent<Renderer>();
        boundaries[0] = renderer.bounds.max.z;
        boundaries[1] = renderer.bounds.min.z;
        boundaries[2] = renderer.bounds.max.x;
        boundaries[3] = renderer.bounds.min.x;
        boundaries[4] = boundarybuffer;

        //Access asteroid behavior class
        AsteroidBehavior asteroid = AsteroidBehavior.getInstance();
        asteroid.add_boundary(boundaries);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
