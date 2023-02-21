using UnityEngine;
using UnityEngine.SceneManagement;

public class SpaceRaceMovement : MonoBehaviour
{

    private Rigidbody rb;
    public float force = 30f;
    public Transform target;
    public float damping;

    void Start()
    {
        rb = GetComponent<Rigidbody>();
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
            Debug.Log("Win!");
            SceneManager.LoadScene("Office");
        }
    }
}
