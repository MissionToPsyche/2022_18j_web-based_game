using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Calendar_Info : MonoBehaviour
{
    // Start is called before the first frame update
    bool isvisible = true;
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void visible()
    {
        isvisible=true;
        gameObject.SetActive(true);
    }
    public void invisible()
    {
        isvisible=false;
        gameObject.SetActive(false);
    }
    public bool getvisibility()
    {
        return isvisible;
    }
}
