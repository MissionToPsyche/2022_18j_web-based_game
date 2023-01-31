using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class tesetmove_UI : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {

        this.transform.position += GetBaseInput() * .5f;
        
    }

    private Vector3 GetBaseInput()
    {
        Vector3 velocity = new Vector3();
        if (Input.GetKey(KeyCode.W))
        {
            velocity += new Vector3(0, 1, 0);
        }
        if (Input.GetKey(KeyCode.S))
        {
            velocity += new Vector3(0, -1, 0);
        }
        if (Input.GetKey(KeyCode.A))
        {
            velocity += new Vector3(-1, 0, 0);
        }
        if (Input.GetKey(KeyCode.D))
        {
            velocity += new Vector3(1, 0, 0);
        }
        return velocity;
    }
}
