using System;
using System.Collections;
using System.Collections.Generic;
using UnityEditorInternal;
using UnityEngine;

public class AsteroidBehavior
{
    // singleton class design
    // makes sure only one instance of the class can be created

    private static AsteroidBehavior instance = new AsteroidBehavior();
    private AsteroidBehavior() { }
    public static AsteroidBehavior getInstance() { 
        return instance; 
    }

    private ArrayList puzzle_boundaries = new ArrayList();

    public void add_boundary(float[] boundary)
    {
        puzzle_boundaries.Add(boundary);
    }

    public bool valid_movement(Vector3 newpos)
    {
        // get moving object's next position
        float x_pos = newpos.x;
        float z_pos = newpos.z;

        for (int i = 0; i < puzzle_boundaries.Count; i++)
        {
            // Change values based on boundary indexes passed through
            float[] Arr = (float[])puzzle_boundaries[i];
            double Zmax = Math.Round((Arr[0] + Arr[4]), 2);
            double Zmin = Math.Round((Arr[1] - Arr[4]), 2);
            double Xmax = Math.Round((Arr[2] + Arr[4]), 2);
            double Xmin = Math.Round((Arr[3] - Arr[4]), 2);
            // check if the next position is valid
            if ((z_pos > Zmin && z_pos < Zmax) && (x_pos > Xmin && x_pos < Xmax))
            {
                return false;
            }
        }
        return true;
    }

}
