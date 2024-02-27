using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    public float moveSpeed = 5;
    private float speedH = 2;
    private float yaw = 5;

    void Update()
    {
        HandleMovement();

        HandleRotation();
    }

    private void HandleMovement()
    {
        float horizontalInput = Input.GetAxis("Horizontal");
        float verticalInput = Input.GetAxis("Vertical");

        Vector3 movement = new Vector3(horizontalInput, 0, verticalInput) * moveSpeed * Time.deltaTime;

        transform.position += transform.TransformDirection(movement);
    }

    private void HandleRotation()
    {
        yaw += speedH * Input.GetAxis("Mouse X");

        transform.eulerAngles = new Vector3(0, yaw, 0);
    }
}
