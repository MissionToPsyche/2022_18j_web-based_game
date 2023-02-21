using UnityEngine;

public class SpaceshipMovement : MonoBehaviour
{
    [SerializeField] private float moveSpeed = 5f;

    private void Update()
    {
        // Get the horizontal and vertical input axes
        float horizontalInput = Input.GetAxis("Horizontal");
        float verticalInput = Input.GetAxis("Vertical");

        // Calculate the movement direction in the X-Z plane
        Vector3 movementDirection = new Vector3(horizontalInput, 0f, verticalInput).normalized;

        // Move the object in the X-Z plane
        transform.Translate(movementDirection * moveSpeed * Time.deltaTime);
    }
}
