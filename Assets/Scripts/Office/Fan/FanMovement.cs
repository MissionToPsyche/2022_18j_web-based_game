using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FanMovement : MonoBehaviour
{
    // The code that controls fan rotation including speed,
    // and how long the code will pause for
    public float fan_angle_z = 0;
    public float rotation = .001f;
    public float wait_secs = .09f;
    void Start()
    {
        StartCoroutine(FanCouroutine());
    }

    // Update is called once per frame
    void Update()
    {
    }

    IEnumerator FanCouroutine()
    {
        while (true)
        {
            if(fan_angle_z >= 45)
            {
                fan_angle_z = 0;
            }
            yield return new WaitForSeconds(wait_secs);
            transform.Rotate(0, 0, fan_angle_z += rotation, Space.Self);
        }
    }
}
