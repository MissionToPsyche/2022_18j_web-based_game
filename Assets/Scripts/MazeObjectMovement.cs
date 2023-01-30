using UnityEngine;

public class MazeObjectMovement : MonoBehaviour
{
    // Update is called once per frame
    void Update()
    {
        
        float xDirection = Input.GetAxis("Horizontal");
        float yDirection = Input.GetAxis("Vertical");

        Vector3 moveDirection = new Vector3(xDirection, yDirection, 0.0f);

        transform.position += moveDirection;
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if(collision.gameObject.tag == "Walls")
        {
            Debug.Log("Wall hit");
        }
    }
}
