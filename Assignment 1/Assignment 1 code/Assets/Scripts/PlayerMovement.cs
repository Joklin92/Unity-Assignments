using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour {

    public float speed = 10f;
    Rigidbody rb;

    void Start() {
        rb = GetComponent<Rigidbody>();
    }


    void Update() {
        transform.Translate(speed * Input.GetAxis("Horizontal") * Time.deltaTime, 
            0f, speed * Input.GetAxis("Vertical") * Time.deltaTime);
        rb.constraints = RigidbodyConstraints.FreezeRotation;
    }
}
