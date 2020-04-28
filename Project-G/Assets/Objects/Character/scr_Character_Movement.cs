using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class scr_Character_Movement : MonoBehaviour
{

    //CharacterController characterController = gameObject.GetComponent("Character Controller");
    
    

    public Transform playerBody;

    //Movement Attributes
    public CharacterController controller;
    public float movementSpeed = 9f;
    private float verticalSpeed = 0f;
    public float forceOfGravity = .05f;
    private float maxFallSpeed = 8f;


    //Camera Attributes
    public float lookSensitivity = 150f;
    public Transform playerCamera;
    float xRotation = 0f;
    


    // Start is called before the first frame update
    void Start()
    {

        //Keeps the cursor locked to the screen
        Cursor.lockState = CursorLockMode.Locked;


    }

    // Update is called once per frame
    void Update()
    {
        
        //Allow the player to look around
        Look();
        Movement();

    }


    void Movement(){
        
        //Get the movement input
        float xMovement = Input.GetAxis("Horizontal");
        float zMovement = Input.GetAxis("Vertical");

        //Gravity helper function
        Gravity();

        //Create the Movement Vector
        Vector3 move = transform.right * xMovement + transform.forward * zMovement + -transform.up * verticalSpeed;

        //Move the player
        controller.Move(move * movementSpeed * Time.deltaTime);
       

    }


    //Allows the player to look around using the mouse.
    void Look(){
    
        //Retrieve input from the mouse.
        float mouseX = Input.GetAxis("Mouse X") * lookSensitivity * Time.deltaTime;
        float mouseY = Input.GetAxis("Mouse Y") * lookSensitivity * Time.deltaTime;

        //Clamp the vertical rotation
        xRotation -= mouseY;
        xRotation = Mathf.Clamp(xRotation, -90f, 90f);

        //Rotate the players body horizontally & the camera vertically
        playerCamera.localRotation = Quaternion.Euler(xRotation, 0f, 0f);
        playerBody.Rotate(Vector3.up, mouseX);



	}

    void Gravity()
    {
        Debug.Log(controller.isGrounded);
        //If the character is not grounded, accelerate
        if (!controller.isGrounded)
        {
            verticalSpeed += forceOfGravity;
            verticalSpeed = Mathf.Clamp(verticalSpeed, 
        }

        //If they are grounded, set vertical speed to 0.
        else verticalSpeed = 0;
    }


}
