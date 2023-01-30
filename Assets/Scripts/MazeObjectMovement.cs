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
}
