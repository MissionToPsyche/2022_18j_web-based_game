using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class EnterCode_SceneSwitch : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        Cursor.lockState = CursorLockMode.Locked;
    }
    void Update()
    {
        
    }

    private void OnMouseDown()
    {
        Vector3 campos = FindObjectOfType<OfficeCamera>().getPosition();
        Vector3 camang = FindObjectOfType<OfficeCamera>().getAngle();

        // the player cannot interact with the object at any distance
        float x_diff = Mathf.Abs(transform.position.x - campos.x);
        float z_diff = Mathf.Abs(transform.position.z - campos.z);

        if(z_diff < 5 && x_diff < 5)
        {
            // save position & angle of camera before entering scene
            OfficeSpawning.CameraAngle = FindObjectOfType<OfficeCamera>().getAngle();
            OfficeSpawning.CameraPos = FindObjectOfType<OfficeCamera>().getPosition();

            SceneManager.LoadScene("Safe Code");
        }

    }
}
