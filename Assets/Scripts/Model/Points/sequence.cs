using System.Collections;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using UnityEngine;

public class sequence
{
    // list containing the order that the player needs to follow
    // to obtain points in the game 
    private List<string> order;
    private int currentposition = 0;

    public sequence(string[] roomseq)
    {
        order = new List<string>(roomseq);
    }

    public bool incrementSeq(string parentObjName)
    {
        // if the parent object (object containing the puzzle piece), 
        // is equal to the piece in sequence the function will return true

        Debug.Log(order[currentposition]);
        if (parentObjName == order[currentposition])
        {
            // if the currentposition is not the last index in the list,
            // it can be incremented
            if(currentposition != order.Count - 1)
            {
                currentposition++;
            }
            return true;
        }
        return false;
    }

    public string getCurrentSeq()
    {
        return order[currentposition];
    }

    public int getPos()
    {
        return currentposition;
    }


}
