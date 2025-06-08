using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    private Vector3 velocity;
    private Vector3 playerMovementInput;
    private Vector2 playerMouseInput;
    private float xRot;

    [SerializeField] private Transform playerCamera;
    [SerializeField] private CharacterController controller;
    [Space]
    [SerializeField] private float speed;
    [SerializeField] private float sensitivity;

    private void Update()
    {
        playerMovementInput = new Vector3(Input.GetAxisRaw("Horizontal"), 0f, Input.GetAxisRaw("Vertical"));
        playerMouseInput = new Vector2(Input.GetAxis("Mouse X"), Input.GetAxis("Mouse Y"));

        MovePlayer();
        MovePlayerCamera();
    }

    private void MovePlayer()
    {
        Vector3 MoveVector = transform.TransformDirection(playerMovementInput);

        if (Input.GetKey(KeyCode.Space))
        {
            velocity.y = 1f;
        }
        else if (Input.GetKey(KeyCode.LeftShift))
        {
            velocity.y = -1f;
        }

        controller.Move(MoveVector * speed * Time.deltaTime);
        controller.Move(velocity * speed * Time.deltaTime);

        velocity.y = 0f;
    }

    private void MovePlayerCamera()
    {
        xRot -= playerMouseInput.y * sensitivity;
        transform.Rotate(0f, playerMouseInput.x * sensitivity, 0f);
        playerCamera.transform.localRotation = Quaternion.Euler(xRot, 0f, 0f);
    }

}
