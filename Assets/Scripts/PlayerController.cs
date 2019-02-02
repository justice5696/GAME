using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour {

    public float movementSpeed;

    Rigidbody rb;
    Vector3 movement;
    Vector3 jump;
    bool isGrounded;
    //public int stepSize;
    public int jumpHeight;

  void OnCollisionStay()
  {
    isGrounded = true;
  }
	// Use this for initialization
	void Start () {
        rb = GetComponent<Rigidbody>();
        jump = new Vector3(0, jumpHeight, 0);
    }

    // Update is called once per frame
    void Update () {
/*
     var x = Input.GetAxis("Horizontal") * Time.deltaTime * 150.0f;
     var z = Input.GetAxis("Vertical") * Time.deltaTime * 3.0f;
     transform.Rotate(0, x, 0);
     transform.Translate(0, 0, z);
*/

        float moveHorizontal = Input.GetAxis("Horizontal");
        float moveVertical = Input.GetAxis("Vertical");
        movement = new Vector3(moveHorizontal, 0.0f, moveVertical);
        rb.AddForce(movement * movementSpeed);

        if(Input.GetKeyDown(KeyCode.Space) && isGrounded)
        {
          rb.AddForce(jump * movementSpeed, ForceMode.Impulse);
          isGrounded = false;
        }

        /*
        if(Input.GetKeyDown(KeyCode.W))
        {
          movement = new Vector3(stepSize, 0.0f, stepSize);
          rb.AddForce(movement * walkSpeed, ForceMode.Force);
          isGrounded = true;
        }
        if(Input.GetKeyDown(KeyCode.S))
        {
          movement = new Vector3(0, 0.0f, -stepSize);
          rb.AddForce(movement * walkSpeed, ForceMode.Force);
          isGrounded = true;
        }
        if(Input.GetKeyDown(KeyCode.D))
        {
          movement = new Vector3(stepSize, 0.0f, 0);
          rb.AddForce(movement * walkSpeed, ForceMode.Force);
          isGrounded = true;
        }

        if(Input.GetKeyDown(KeyCode.A))
        {
          movement = new Vector3(-stepSize, 0.0f, 0);
          rb.AddForce(movement * walkSpeed, ForceMode.Force);
          isGrounded = true;
        }
        */
    }

    /*void FixedUpdate() {
        Move();
    }

    void Move() {

        Vector3 yVelFix = new Vector3(0, rb.velocity.y, 0);
        rb.velocity = moveDirection * walkSpeed * Time.deltaTime;
        rb.velocity += yVelFix;
    }*/
}
