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
        // I was able to finish with ~1:15, so make <=1:30 a gold medal, <1:50 silver, and >1:50 bronze 
        if(collision.gameObject.tag == "Finish")
        {
            Debug.Log(timerText.text);
            double time = TimeSpan.ParseExact(timerText.text, "mm':'ss':'ff", null, 0).TotalSeconds;
            Debug.Log(time);
            int tspent = (int)Math.Ceiling(time);
            
            if (tspent <= 90){
                pointC.timerMission(1000);
            }           
            else if (tspent <= 110){
                pointC.timerMission(750);
            }
            else{
                pointC.timerMission(500);
            }
            
            // int tpoints = 1000 - tspent;
            // pointC.timerMission(tpoints);

            Debug.Log("Win!");
            SceneManager.LoadScene("ConferenceRoom");
        }
    }
}
