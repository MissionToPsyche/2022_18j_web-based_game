using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WhiteBoard_Popup : MonoBehaviour
{
    // Start is called before the first frame update
    GameObject wb_pop;
    private void Awake()
    {
        wb_pop = GameObject.Find("WB popup");

    }
    void Start()
    {
        wb_pop.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKey(KeyCode.Space) & wb_pop.activeSelf)
        {
            wb_pop.SetActive(false);
        }
    }
    private void OnMouseDown()
    {
        //When clicked, show popup information
        Vector3 campos = FindObjectOfType<OfficeCamera>().getPosition();
        Vector3 camang = FindObjectOfType<OfficeCamera>().getAngle();

        // the player cannot interact with the object at any distance
        float x_diff = Mathf.Abs(transform.position.x - campos.x);
        float z_diff = Mathf.Abs(transform.position.z - campos.z);

        // if the player is within a certain horizontal distance from the safe
        // they can interact with it
        if (z_diff < 5 && x_diff < 5)
        {
            wb_pop.SetActive(true);
        }
    }
}
