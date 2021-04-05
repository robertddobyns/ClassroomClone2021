using System;
using System.Collections;
using System.Collections.Generic;
using System.Net.Http.Headers;
using System.Runtime.CompilerServices;
using UnityEngine;

public class Player : MonoBehaviour
{
    [SerializeField] private float speed = 3.0f;
    private Vector3 jump;
    
    [SerializeField]
    private float jumpForce = 2.0f;

    [SerializeField] private bool isGrounded = true;
    private Rigidbody rb;
    
    void Start()
    {
        this.GetComponent<Renderer>().material.SetColor("_Color", Color.blue);
        this.GetComponent<Rigidbody>().freezeRotation = true;
        rb = this.GetComponent<Rigidbody>();
        jump = new Vector3(0.0f, 1.0f, 0.0f);
    }

    private void OnCollisionStay(Collision other)
    {
        isGrounded = true;
    }

    // Update is called once per frame
    void FixedUpdate()
    {
       Moving();
       Jumping();
       if (Input.GetKeyDown(KeyCode.Space))
       {
           Debug.Log("jump");
       }
    }

    private void Moving()
    {
        float horizontalInput = Input.GetAxis("Horizontal");
        float verticalInput = Input.GetAxis("Vertical");

        Vector3 direction = new Vector3(horizontalInput, 0, verticalInput);
        
        transform.Translate(direction * (speed * Time.deltaTime));

        if (Input.GetKeyDown(KeyCode.Space) && isGrounded)
        {
            rb.AddForce(jump *jumpForce, ForceMode.Impulse);
            isGrounded = false;
        }
    }

    private void Jumping()
    {
        if (Input.GetKeyDown(KeyCode.Space) && isGrounded)
        {
            rb.AddForce(jump *jumpForce, ForceMode.Impulse);
            isGrounded = false;
        }
    }
}
