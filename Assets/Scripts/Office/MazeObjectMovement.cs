using UnityEngine;

public class MazeObjectMovement : MonoBehaviour
{
    // Update is called once per frame
    void Update()
    {
        float xDirection = Input.GetAxis("Horizontal");
        float yDirection = Input.GetAxis("Vertical");

        Vector3 moveDirection = new Vector3(xDirection, 0.0f, yDirection);

        transform.position += moveDirection;
    }

    void fixedUpdate()
    {
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if(collision.gameObject.tag == "Walls")
        {
            Debug.Log("Wall hit");
        }
    }
}
