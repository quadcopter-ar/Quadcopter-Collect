using Mirror;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;


/*
This script is responsible for moving and/or rotating the player using keyboard input. This script is attached to the player prefab.\

Which keys corresponding to which movements are:
W - move forward
A - move left
S - move backward
D-  move right
E - move up
C - move down
J - rotate left
L - rotate right

*/

public class PlayerMovement : NetworkBehaviour
{

    Vector3 movementVector;


    // Start is called before the first frame update
    void Start()
    {
        movementVector = new Vector3(0.0f, 0.0f, 0.0f);

        //transparency of the playere prefab can be set
        Color tempcolor = this.GetComponent<MeshRenderer>().material.color;
        tempcolor.a = 1.0f;
        GetComponent<MeshRenderer>().material.color = tempcolor;



    }

    // Update is called once per frame
    void Update()
    {
        if(isLocalPlayer){//This if statement ensures that a player cannot move the other pplayer.
            

            if(Input.GetKey(KeyCode.W))//move forward
            {
                movementVector = new Vector3(0.0f, 0.0f, 0.1f);
                this.transform.Translate(movementVector);

            }

            if(Input.GetKey(KeyCode.A))//move left
            {
                movementVector = new Vector3(-0.1f, 0.0f, 0.0f);
                this.transform.Translate(movementVector);
            }

            if(Input.GetKey(KeyCode.S))//move backward
            {
                movementVector = new Vector3(0.0f, 0.0f, -0.1f);
                this.transform.Translate(movementVector);
                
            }

            if(Input.GetKey(KeyCode.D))//move right
            {
                movementVector = new Vector3(0.1f, 0.0f, 0.0f);
                this.transform.Translate(movementVector);
                
            }

            if(Input.GetKey(KeyCode.E))//move up
            {
                movementVector = new Vector3(0.0f, 0.1f, 0.0f);
                this.transform.Translate(movementVector);
                
            }

            if(Input.GetKey(KeyCode.C))//move down
            {
                movementVector = new Vector3(0.0f, -0.1f, 0.0f);
                this.transform.Translate(movementVector);
                
            }
            if(Input.GetKey(KeyCode.J))//rotate left
            {
                 transform.Rotate(Vector3.down * 0.5f);
            }
            if(Input.GetKey(KeyCode.L))//rotate right
            {
                 transform.Rotate(Vector3.up * 0.5f);
            }

            CheckBoundaries();
            
        }
    }

    //This function ensures that players cannot go outside of the play area
    void CheckBoundaries()
    {
        this.transform.position = new Vector3(Mathf.Clamp(this.transform.position.x, -15.0f, 15.0f), Mathf.Clamp(this.transform.position.y, 0.5f, 15.0f), Mathf.Clamp(this.transform.position.z, -15.0f, 15.0f));
    }
}
