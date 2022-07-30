using Mirror;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : NetworkBehaviour
{

    Vector3 movementVector;
    private Rigidbody rb;

    // Start is called before the first frame update
    void Start()
    {
        movementVector = new Vector3(0.0f, 0.0f, 0.0f);
        rb = GetComponent<Rigidbody>();
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
            
        }
    }
}
