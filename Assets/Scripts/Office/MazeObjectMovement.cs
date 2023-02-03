using UnityEngine;
using UnityEngine.SceneManagement;

public class MazeObjectMovement : MonoBehaviour
{

    private Rigidbody rb;
    public float force = 5f;

    void Start()
    {
        rb = GetComponent<Rigidbody>();
    }

    // Update is called once per frame
    void Update()
    {
        /* float xDirection = Input.GetAxis("Horizontal");
        float yDirection = Input.GetAxis("Vertical");

        Vector3 moveDirection = new Vector3(xDirection, 0.0f, yDirection);

        transform.position += moveDirection; */
    }

    void FixedUpdate()
    {
        Vector3 input = new Vector3(Input.GetAxis("Horizontal"), 0, Input.GetAxis("Vertical"));
        
        rb.AddForce(input * force);


    //    transform.Translate( moveSpeed * Input.GetAxis("Horizontal") * Time.fixedDeltaTime, 0, 
    //                         moveSpeed * Input.GetAxis("Vertical") * Time.fixedDeltaTime); 
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
