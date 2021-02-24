using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour {
    float walkSpeed = 10f;
    bool shouldMove = false;
    Rigidbody rb;

    // Start is called before the first frame update
    void Start() {
        rb = gameObject.GetComponent<Rigidbody>();
    }

    // Update is called once per frame
    void Update() {
        shouldMove = false;
        if (Input.GetKey(KeyCode.W)) {
            shouldMove = true;
        }
    }

    private void FixedUpdate() {
        if (shouldMove) {
            Vector3 dir = transform.forward * walkSpeed * Time.fixedDeltaTime;
            rb.AddForce(dir, ForceMode.VelocityChange);
        }
    }
}
