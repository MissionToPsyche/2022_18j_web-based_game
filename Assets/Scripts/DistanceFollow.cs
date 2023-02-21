using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// Simple script to be used on Camera objects when the camera should follow the object from a static displacement
public class DistanceFollow : MonoBehaviour
{

    public Transform follow;
    private Vector3 distance;
    // Start is called before the first frame update
    void Start()
    {
        distance = transform.position - follow.position;
    }

    // Update is called once per frame
    void Update()
    {
        transform.position = follow.position + distance;
    }
}
