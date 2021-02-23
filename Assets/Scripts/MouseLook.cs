using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MouseLook : MonoBehaviour
{
    float rotX = 0;
    float rotY = 0;
    float mouseSensitivity = 30f;
    float snappiness = 100f;
    float xVelocity = 10f;
    float yVelocity = 10f;
    bool lockMouseMovement = false;
    float upDownRange = 90f;
    GameObject mainCamera;

    void Start()
    {
        mainCamera = Camera.main.gameObject;
    }

    void Update()
    {
        rotX = Input.GetAxis("Mouse X") * mouseSensitivity;
        rotY -= Input.GetAxis("Mouse Y") * mouseSensitivity;

        xVelocity = Mathf.Lerp(xVelocity, rotX, snappiness * Time.deltaTime);
        yVelocity = Mathf.Lerp(yVelocity, rotY, snappiness * Time.deltaTime);

        if (!lockMouseMovement) {
            //RotY
            rotY = Mathf.Clamp(rotY, -upDownRange, upDownRange);
            mainCamera.transform.localRotation = Quaternion.Euler(yVelocity, 0, 0);

            //RotX
            transform.Rotate(0, xVelocity, 0);
        }
    }
}
