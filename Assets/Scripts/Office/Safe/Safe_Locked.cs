using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public static class Safe_Locked
{
    // The safe is pre-defined to be locked and can be set to false,
    // or unlocked after event completion
    private static bool locked = true;

    public static bool IsLocked
    {
        get { return locked; }
        set { locked = value; }
    }
}
