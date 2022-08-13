using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Mirror;

public class MoveCamera : NetworkBehaviour
{

    public GameObject camera;
    Vector3 cameraOffset;
    Quaternion cameraRotation;
    Vector3 movementVector;

    // Start is called before the first frame update
    void Start()
    {
        camera = GameObject.Find("XRRig");
        cameraOffset = new Vector3(0.0f, 0.0f, 0.0f);
        camera.transform.rotation = Quaternion.Euler(0.0f, 0.0f, 0.0f);
        movementVector = new Vector3(0.0f, 0.0f, 0.0f);
        AdjustCamera();
        SetTransparency();
    }

    // Update is called once per frame
    void Update()
    {
        if(isLocalPlayer)
        {

            AdjustCamera();

            if(Input.GetKey(KeyCode.I))
            {
                movementVector = new Vector3(-0.5f, 0.0f, 0.0f);
                camera.transform.Rotate(movementVector);
                //this.transform.position = this.transform.position + movementVector;
            }

            if(Input.GetKey(KeyCode.J))
            {
                movementVector = new Vector3(0.0f, -0.5f, 0.0f);
                camera.transform.Rotate(movementVector);
                //this.transform.position = this.transform.position + movementVector;
            }

            if(Input.GetKey(KeyCode.K))
            {
                movementVector = new Vector3(0.5f, 0.0f, 0.0f);
                camera.transform.Rotate(movementVector);
                //this.transform.position = this.transform.position + movementVector;
            }

            if(Input.GetKey(KeyCode.L))
            {
                movementVector = new Vector3(0.0f, 0.5f, 0.0f);
                camera.transform.Rotate(movementVector);
                //this.transform.position = this.transform.position + movementVector;
            }

            if(Input.GetKey(KeyCode.U))
            {
                movementVector = new Vector3(0.0f, 0.0f, 0.5f);
                camera.transform.Rotate(movementVector);
                //this.transform.position = this.transform.position + movementVector;
            }

            if(Input.GetKey(KeyCode.O))
            {
                movementVector = new Vector3(0.0f, 0.0f, -0.5f);
                camera.transform.Rotate(movementVector);
                //this.transform.position = this.transform.position + movementVector;
            }
        }
        
    }

    void AdjustCamera()
    {
        camera.transform.position = this.transform.position + cameraOffset;
    }

    [Command]
    public void SetTransparency()
    {
        /*GameObject[] players = GameObject.FindGameObjectsWithTag("Player");
        foreach(GameObject player in players)
        {
            Color tempcolor = player.GetComponent<MeshRenderer>().material.color;
            tempcolor.a = 0.1f;
            player.GetComponent<MeshRenderer>().material.color = tempcolor;
        }*/
    }
}
