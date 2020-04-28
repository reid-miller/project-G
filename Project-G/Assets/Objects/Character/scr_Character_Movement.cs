using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class scr_Character_Movement : MonoBehaviour
{

    //CharacterController characterController = gameObject.GetComponent("Character Controller");
    
    

    public Transform playerBody;

    //Camera Attributes
    public float lookSensitivity = 100f;
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


}
