using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour {
    CharacterController characterController;
    public float movementSpeed = 5;
    public float gravity = 2f;
    private Vector3 overallVelocity = Vector3.zero;
    private float yVelocity = 0;
    public float jumpVelocity = 0.5f;
    public bool regularGravityEnabled = true;
 
    private void Start()
    {
        characterController = GetComponent<CharacterController>();
    }
 
    void Update()
    {
        overallVelocity = Vector3.zero;
        // player movement - forward, backward, left, right
        float horizontal = Input.GetAxis("Horizontal") * movementSpeed;
        float vertical = Input.GetAxis("Vertical") * movementSpeed;
        overallVelocity += (transform.right * horizontal + transform.forward * vertical) * Time.deltaTime;
 
        // Gravity
        if(characterController.isGrounded)
        {
            Debug.Log("Grounded");
            yVelocity = 0;
            if (Input.GetKey(KeyCode.Space)) {
                Debug.Log("Pressed space");
                yVelocity += jumpVelocity;
            }
        }
        else if (regularGravityEnabled)
        {
            yVelocity -= gravity * Time.deltaTime;

        }
        overallVelocity.y += yVelocity;
        characterController.Move(overallVelocity);
    }
}
