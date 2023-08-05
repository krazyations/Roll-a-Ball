using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BALL : MonoBehaviour
{
    Rigidbody body;
    public int speed = 2;
    public int jumpForce = 10;

    private bool isGrounded = false;

    // Start is called before the first frame update
    void Start()
    {
        body = GetComponent<Rigidbody>();
    }

    // Update is called once per frame
    void Update()
    {
        float horizontal = Input.GetAxis("Horizontal");
        body.velocity = new Vector3(horizontal * speed, body.velocity.y, body.velocity.z);
        if(Input.GetButtonDown("Jump") && isGrounded)
        {
         body.AddForce(Vector3.up * jumpForce, ForceMode.Impulse);
            float vertical = Input.GetAxis("vertical");
            body.velocity = new Vector3(vertical * speed, body.velocity.z, body.velocity.z);
        }

    }
    
    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Floor"))
        {
            isGrounded = true;
        }
    }

    private void OnCollisionExit(Collision collision)
    {
        if (collision.gameObject.CompareTag("Floor"))
        {
            isGrounded = false;
        }
    }
}
