using Mirror;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : NetworkBehaviour
{

    Vector3 movementVector;
    //private Rigidbody rb;


    // Start is called before the first frame update
    void Start()
    {
        movementVector = new Vector3(0.0f, 0.0f, 0.0f);
        //rb = GetComponent<Rigidbody>();
    }

    // Update is called once per frame
    void Update()
    {
        if(isLocalPlayer){
            if(Input.GetKey(KeyCode.W))
            {
                movementVector = new Vector3(0.0f, 0.0f, 0.1f);
                this.transform.position = this.transform.position + movementVector;
            }

            if(Input.GetKey(KeyCode.A))
            {
                movementVector = new Vector3(-0.1f, 0.0f, 0.0f);
                this.transform.position = this.transform.position + movementVector;
            }

            if(Input.GetKey(KeyCode.S))
            {
                movementVector = new Vector3(0.0f, 0.0f, -0.1f);
                this.transform.position = this.transform.position + movementVector;
            }

            if(Input.GetKey(KeyCode.D))
            {
                movementVector = new Vector3(0.1f, 0.0f, 0.0f);
                this.transform.position = this.transform.position + movementVector;
            }

            if(Input.GetKey(KeyCode.R))
            {
                movementVector = new Vector3(0.0f, 0.1f, 0.0f);
                this.transform.position = this.transform.position + movementVector;
            }

            if(Input.GetKey(KeyCode.V))
            {
                movementVector = new Vector3(0.0f, -0.1f, 0.0f);
                this.transform.position = this.transform.position + movementVector;
            }

            CheckBoundaries();
            
        }
    }

    void CheckBoundaries()
    {
        this.transform.position = new Vector3(Mathf.Clamp(this.transform.position.x, -15.0f, 15.0f), Mathf.Clamp(this.transform.position.y, 0.5f, 15.0f), Mathf.Clamp(this.transform.position.z, -15.0f, 15.0f));
    }
}
