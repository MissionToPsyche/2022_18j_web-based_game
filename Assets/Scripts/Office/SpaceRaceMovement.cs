using UnityEngine;
using UnityEngine.SceneManagement;
using TMPro;
using System;

public class SpaceRaceMovement : MonoBehaviour
{

    [Header("Component")]
    public TextMeshProUGUI timerText;

    private point_controller pointC = point_controller.getInstance();

    private Rigidbody rb;
    public float force = 30f;
    public Transform target;
    public float damping;

    void Start()
    {
        rb = GetComponent<Rigidbody>();
        rb.centerOfMass = Vector3.zero;
        rb.inertiaTensorRotation = Quaternion.identity;
    }

    // Update is called once per frame
    void Update()
    {

    }

    // WIP TODO: Make ship face the direction of movement
    // Simple control script to "push" the ship in the direction pressed. 
    void FixedUpdate()
    {
        Vector3 input = new Vector3(Input.GetAxis("Horizontal"), 0, Input.GetAxis("Vertical"));

        if(input == Vector3.zero){
            return;
        }

        Quaternion targetRotation = Quaternion.LookRotation(input);

        targetRotation = Quaternion.Slerp(target.rotation, targetRotation, damping * Time.fixedDeltaTime);
        
        rb.AddForce(input * force);

        rb.MoveRotation(targetRotation);
    }

    private void OnCollisionEnter(Collision collision)
    {
        if(collision.gameObject.tag == "Finish")
        {
            float time = float.Parse(timerText.text);
            int tspent = (int)Math.Round(time);
            int tpoints = 1000 - tspent;
            pointC.timerMission(tpoints);

            Debug.Log("Win!");
            SceneManager.LoadScene("Office");
        }
    }
}
