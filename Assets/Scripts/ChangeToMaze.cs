using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ChangeToMaze : MonoBehaviour
{
    private Interact_Distance ID = Interact_Distance.GetInsance();
    private inventory_controller invC = inventory_controller.getInstance();
    private scene_controller sceneC = scene_controller.getInstance();
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnMouseDown()
    {
        LoadMaze();
    }

    public void LoadMaze()
    {
        if (ID.checkDistance(5, gameObject))
        {
            SceneManager.LoadScene("MazePuzzle");
            gameObject.GetComponent<BoxCollider>().enabled = false;
            //sceneC.changeData(name, transform.position, transform.position, true, false);
        }

    }
}
