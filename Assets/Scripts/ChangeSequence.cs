using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ChangeSequence : MonoBehaviour
{
    private point_controller pointC = point_controller.getInstance();

    private void Start()
    {
        Scene currentScene = SceneManager.GetActiveScene();
        string sceneName = currentScene.name;
        if(sceneName == "Office")
        {
            pointC.changeToOffSequence();
        }
        if(sceneName == "ConferenceRoom")
        {
            Debug.Log("Changed to Conference Sequence");
            pointC.changeToConSequence();
        }
    }

}
