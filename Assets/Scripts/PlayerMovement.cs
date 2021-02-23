using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour {
    float walkSpeed = 10f;

    // Start is called before the first frame update
    void Start() {

    }

    // Update is called once per frame
    void Update() {
        if (Input.GetKey(KeyCode.W)) {

            Vector3 newPos = transform.position + (transform.forward * walkSpeed * Time.deltaTime);
            transform.position = newPos;
        }
    }
}
