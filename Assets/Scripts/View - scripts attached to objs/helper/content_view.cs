using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class content_view : MonoBehaviour
{
    //--------------------this script should only be attached to the content UI element within the glossary scene!--------------------

    private helper_controller helpC = helper_controller.getInstance();
    // Start is called before the first frame update
    void Start()
    {
        // sets the glossary content object
        // which will then be used for adding content to the glossary
        helpC.setGlossaryContent(gameObject);
        helpC.createContent();
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
