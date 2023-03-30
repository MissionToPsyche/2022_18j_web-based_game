using UnityEngine;
using UnityEngine.SceneManagement;
using TMPro;
using System;

public class MazeObjectMovement : MonoBehaviour
{

    [Header("Component")]
    public TextMeshProUGUI timerText;

    private point_controller pointC = point_controller.getInstance();

    public Rigidbody rb;
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

        MoveAstroid(input,rb);


    //    transform.Translate( moveSpeed * Input.GetAxis("Horizontal") * Time.fixedDeltaTime, 0, 
    //                         moveSpeed * Input.GetAxis("Vertical") * Time.fixedDeltaTime); 
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.tag == "Finish")
        {
            float time = float.Parse(timerText.text);
            int tspent = (int)Math.Round(time);
            int tpoints = 1000 - tspent;
            pointC.timerMission(tpoints);

            FinishLine();
        }
    }

    public void MoveAstroid(Vector3 input, Rigidbody rb)
    {
        rb.AddForce(input * force);
    }

    public void FinishLine()
    {
        Debug.Log("Win!");
        SceneManager.LoadScene("Office");
    }
}
