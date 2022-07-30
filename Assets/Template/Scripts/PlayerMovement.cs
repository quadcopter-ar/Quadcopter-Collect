using Mirror;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : NetworkBehaviour
{

    Vector3 movementVector;
    //Vector3 cameraRotation;
    Quaternion cameraRotation;
    private Rigidbody rb;

    public GameObject camera;
    Vector3 cameraOffset;


    // Start is called before the first frame update
    void Start()
    {
        movementVector = new Vector3(0.0f, 0.0f, 0.0f);
        

        rb = GetComponent<Rigidbody>();
        camera = GameObject.Find("Main Camera");


        cameraOffset = new Vector3(0.0f, 10.0f, -10.0f);

        //cameraRotation = new Vector3(45.0f, 0.0f, 0.0f);
        //cameraRotation = Quaternion.Euler(0.0f, 45.0f, 0.0f);
        //camera.transform.rotation = cameraRotation;
        camera.transform.rotation = Quaternion.Euler(45.0f, 0.0f, 0.0f);
        AdjustCamera();



        //cameraOffset
    }

    // Update is called once per frame
    void Update()
    {
        if(isLocalPlayer){
            if(Input.GetKeyDown(KeyCode.W))
            {
                movementVector = new Vector3(0.0f, 0.0f, 100.0f);
                rb.AddForce(movementVector);
            }

            if(Input.GetKeyDown(KeyCode.A))
            {
                movementVector = new Vector3(-100.0f, 0.0f, 0.0f);
                rb.AddForce(movementVector);
            }

            if(Input.GetKeyDown(KeyCode.S))
            {
                movementVector = new Vector3(0.0f, 0.0f, -100.0f);
                rb.AddForce(movementVector);
            }

            if(Input.GetKeyDown(KeyCode.D))
            {
                movementVector = new Vector3(100.0f, 0.0f, 0.0f);
                rb.AddForce(movementVector);
            }
            AdjustCamera();
        }
    }

    void AdjustCamera()
    {
        camera.transform.position = this.transform.position + cameraOffset;
    }
}
